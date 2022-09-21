using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace SF52_2015.View
{
	/// <summary>
	/// Interaction logic for DodajKorisnika.xaml
	/// </summary>
	public partial class DodajKorisnika : Window
	{
		private int selektovaniSalon = 1;

		public DodajKorisnika()
		{
			InitializeComponent();
			string connection = BazaCommon.ConnectionString;

			//DODAVANJE SALONA U COMBOBOX
			string query2 = String.Format("SELECT * FROM SALON WHERE obrisan ='0'");
			SQLiteConnection cn2 = new SQLiteConnection(connection);
			cn2.Open();

			SQLiteCommand command2 = new SQLiteCommand(query2, cn2);
			SQLiteDataAdapter da2 = new SQLiteDataAdapter(command2);

			DataTable data2 = new DataTable();
			da2.Fill(data2);

			foreach (DataRow row in data2.Rows)
			{
				string sifra = row["sifra"].ToString();
				string naziv = row["naziv"].ToString();

				saloni_idComboBox.Items.Add(naziv + "-" + sifra);
			}
		}

		private void DodajBtn_Click(object sender, RoutedEventArgs e)
		{
			if(!emailTextBox.Text.Contains("@") || !emailTextBox.Text.Contains(".com"))
			{
				MessageBox.Show("Neispravan mejl!");
				return;
			}
			int selSalon = PronadjiIdSelektovanogSalona();
		
			string query = String.Format($"INSERT INTO KORISNIK ('ime','prezime','email','korisnicko_ime','lozinka','tip','id_salona_zaposlenog_radnika','ulogovan','obrisan') " +
				$"VALUES ('{imeTextBox.Text}','{prezimeTextBox.Text}','{emailTextBox.Text}','{korisnicko_imeTextBox.Text}','{lozinkaTextBox.Text}','{tipComboBox.Text}',{selSalon}, '0','0')");

			using (SQLiteConnection dataConnection = new SQLiteConnection())
			{
				try
				{
					dataConnection.ConnectionString = BazaCommon.ConnectionString;
					dataConnection.Open();

					SQLiteCommand dataCommand = new SQLiteCommand(query, dataConnection);
					if (dataCommand.ExecuteNonQuery() == 1)
					{
						MessageBox.Show("Dodato!");
					}
					else
					{
						MessageBox.Show("Nije moguce dodati!");
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

		private int PronadjiIdSelektovanogSalona()
		{
			int position = saloni_idComboBox.Text.IndexOf("-");
			string sifraSelektovanogSalona = saloni_idComboBox.Text.Substring(position + 1); // 2ccb
			string connection = BazaCommon.ConnectionString;
			string query = String.Format($"SELECT * FROM SALON WHERE obrisan = '0' AND sifra = '{sifraSelektovanogSalona}'");
			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				string salon_id = row["salon_id"].ToString();

				selektovaniSalon = Int32.Parse(salon_id);
			}
			return selektovaniSalon;
		}


		private void OtkaziBtn_Click(object sender, RoutedEventArgs e)
		{
			SpisakKorisnika skk = new SpisakKorisnika();
			this.Close();
			skk.ShowDialog();
		}

		private void tipComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (saloni_idComboBox != null) {
				if (tipComboBox.SelectedItem.ToString().Equals("System.Windows.Controls.ComboBoxItem: RADNIK"))
				{
					saloni_idComboBox.Visibility = Visibility.Visible;
					Saloni.Visibility = Visibility.Visible;
				}
				else
				{
					saloni_idComboBox.Visibility = Visibility.Hidden;
					Saloni.Visibility = Visibility.Hidden;
					saloni_idComboBox.Text = " ";

				}
			}
		}
	}
}