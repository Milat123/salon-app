using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using SF52_2015.Model;

namespace SF52_2015.View
{
	/// <summary>
	/// Interaction logic for IzmenaKorisnika.xaml
	/// </summary>
	public partial class IzmenaKorisnika : Window
	{
		private Korisnik korisnikZaIzmenu;
		private string zaIzmenu;

		public IzmenaKorisnika(string id)
		{
			InitializeComponent();
			UnesiVrednostUTextBox(id);
			zaIzmenu = id;
		}

		private void UnesiVrednostUTextBox(string id)
		{
			string connection = BazaCommon.ConnectionString;
			string query = String.Format($"SELECT * FROM KORISNIK WHERE korisnik_id={id}");
			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				string korisnik_id = row["korisnik_id"].ToString();
				string ime = row["ime"].ToString();
				string prezime = row["prezime"].ToString();
				string email = row["email"].ToString();
				string korisnicko_ime = row["korisnicko_ime"].ToString();
				string lozinka = row["lozinka"].ToString();
				string tip = row["tip"].ToString();
				string ulogovan = row["ulogovan"].ToString();
				string obrisan = row["obrisan"].ToString();
				string id_salona_zaposlenog_radnika = row["id_salona_zaposlenog_radnika"].ToString();

				korisnikZaIzmenu = new Korisnik(Int32.Parse(id), ime, prezime, email, korisnicko_ime, lozinka, tip, ulogovan, obrisan, Int32.Parse(id_salona_zaposlenog_radnika));
			}
			imeTextBox.Text = korisnikZaIzmenu.ime;
			prezimeTextBox.Text = korisnikZaIzmenu.prezime;
			emailTextBox.Text = korisnikZaIzmenu.email;
			korisnicko_imeTextBox.Text = korisnikZaIzmenu.korisnicko_ime;
			lozinkaTextBox.Text = korisnikZaIzmenu.lozinka;
			tipComboBox.Text = korisnikZaIzmenu.tip;
		}

		private void IzmeniBtn_Click(object sender, RoutedEventArgs e)
		{

				string query = " UPDATE KORISNIK SET ime = '" + imeTextBox.Text + "', prezime = '" + prezimeTextBox.Text + "',email = '" + emailTextBox.Text + "',korisnicko_ime = '" + korisnicko_imeTextBox.Text + "', lozinka = '" + lozinkaTextBox.Text + "',tip = '" + tipComboBox.Text + "',ulogovan = '" + 0 + "',obrisan = '" + 0 + "' WHERE korisnik_id = '" + zaIzmenu + "' ";

				using (SQLiteConnection dataConnection = new SQLiteConnection())
				{
					try
					{
						dataConnection.ConnectionString = BazaCommon.ConnectionString;
						dataConnection.Open();

						SQLiteCommand dataCommand = new SQLiteCommand(query, dataConnection);
						if (dataCommand.ExecuteNonQuery() == 1)
						{
							MessageBox.Show("Izmenjen!");
						}
						else
						{
							MessageBox.Show("Nije moguce izmeniti!");
						}
					}
					catch (Exception e1)
					{
						Console.WriteLine("Error dataConnection. . . " + e1.Message);
						MessageBox.Show("Doslo je do greske prilikom unosa!");
					}
					finally
					{
						dataConnection.Close();
					}
					SpisakKorisnika sk = new SpisakKorisnika();
					this.Close();
					sk.ShowDialog();
				}
			
		}


		private void OtkaziBtn_Click(object sender, RoutedEventArgs e)
		{
			SpisakKorisnika sk = new SpisakKorisnika();
			this.Close();
			sk.ShowDialog();
		}
	}
}