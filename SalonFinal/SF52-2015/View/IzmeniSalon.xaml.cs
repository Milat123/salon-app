using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using SF52_2015.Model;

namespace SF52_2015.View
{
	/// <summary>
	/// Interaction logic for IzmeniSalon.xaml
	/// </summary>
	public partial class IzmeniSalon : Window
	{
		private int broj;
		private Salon korisnikZaIzmenu;
		private string zaIzmenu;

		public IzmeniSalon(string id)
		{
			InitializeComponent();
			UnesiVrednostUTextBox(id);
			zaIzmenu = id;
		}

		private void UnesiVrednostUTextBox(string id)
		{
			string connection = BazaCommon.ConnectionString;
			string query = String.Format($"SELECT * FROM SALON WHERE salon_id={id}");
			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				string ustanova_id = row["salon_id"].ToString();
				string sifra = row["sifra"].ToString();
				string naziv = row["naziv"].ToString();
				string adresa = row["adresa"].ToString();

				string obrisan = row["obrisan"].ToString();

				korisnikZaIzmenu = new Salon(Int32.Parse(ustanova_id), sifra, naziv, adresa, obrisan);
			}
			sifraTextBox.Text = korisnikZaIzmenu.sifra;
			nazivTextBox.Text = korisnikZaIzmenu.naziv;
			adresaTextBox.Text = korisnikZaIzmenu.adresa;
		}

		private void IzmeniBtn_Click(object sender, RoutedEventArgs e)
		{
			string query = " UPDATE SALON SET sifra = '" + sifraTextBox.Text + "', naziv = '" + nazivTextBox.Text + "',adresa = '" + adresaTextBox.Text + "',obrisan = '" + 0 + "' WHERE salon_id = '" + zaIzmenu + "' ";

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
				SpisakSalona su = new SpisakSalona();
				this.Close();
				su.ShowDialog();
			}
		}


		private void OtkaziBtn_Click(object sender, RoutedEventArgs e)
		{
			SpisakSalona st = new SpisakSalona();
			this.Close();
			st.ShowDialog();
		}
	}
}