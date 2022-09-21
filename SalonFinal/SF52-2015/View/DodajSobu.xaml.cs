using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using SF52_2015.Model;

namespace SF52_2015.View
{
	/// <summary>
	/// Interaction logic for DodajKorisnika.xaml
	/// </summary>
	public partial class DodajSobu : Window
	{
		private int broj;
		private int selektovaniSalon = 1;

		public DodajSobu()
		{
			//DODAVANJE SALONA U COMBO BOX
			InitializeComponent();
			string connection = BazaCommon.ConnectionString;
			string query = String.Format("SELECT * FROM SALON WHERE obrisan ='0' ");
			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				string sifra = row["sifra"].ToString();
				string naziv = row["naziv"].ToString();

				salon_idComboBox.Items.Add(naziv + "-" + sifra);
			}
		}

		private void DodajBtn_Click(object sender, RoutedEventArgs e)
		{
			int selSalon = PronadjiIdSelektovanogSalona();
			bool broj_sobeNijePonovljen = false;
			broj_sobeNijePonovljen = ProveraPonavljanjaBrojaSobe(broj_sobeTextBox.Text, selSalon);

			if (broj_sobeNijePonovljen)
			{
				string query = String.Format($"INSERT INTO SOBA ('sifra','broj_sobe','broj_kreveta','tip_sobe','salon_id','obrisan') " +
					$"VALUES ('{sifraTextBox.Text}','{broj_sobeTextBox.Text}','{broj_krevetaTextBox.Text}','{tip_sobeComboBox.Text}',{selSalon},'0')");

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
					SpisakSoba su = new SpisakSoba();
					this.Close();
					su.ShowDialog();
				}
			}
			else
			{
				MessageBox.Show("Broj sobe u okviru jednog salona ne sme biti isti!");
			}
		}

		private int PronadjiIdSelektovanogSalona()
		{
			int position = salon_idComboBox.Text.IndexOf("-");
			string sifraSelektovanogSalona = salon_idComboBox.Text.Substring(position + 1); // 2ccb
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
			SpisakSoba st = new SpisakSoba();
			this.Close();
			st.ShowDialog();
		}

		//Validacija za broj mesta,samo brojevi!
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}

		private bool ProveraPonavljanjaBrojaSobe(string noviBrojSobe, int selSalon)
		{
			using (SQLiteConnection dataConnection = new SQLiteConnection())
			{
				try
				{
					dataConnection.ConnectionString = BazaCommon.ConnectionString;
					dataConnection.Open();
					SQLiteCommand dataCommand = new SQLiteCommand();
					dataCommand.Connection = dataConnection;
				}
				catch (Exception e)
				{
					Console.WriteLine("Error dataConnection..." + e.Message);
				}
			}

			string database_connection = BazaCommon.ConnectionString;
			string query = String.Format("SELECT * FROM SOBA WHERE obrisan = '0' AND salon_id =" + selSalon + "  "); //

			SQLiteConnection connection = new SQLiteConnection(database_connection);
			connection.Open();

			SQLiteCommand command = new SQLiteCommand(query, connection);
			SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			dataAdapter.Fill(data);

			List<Soba> sobaList = new List<Soba>();
			foreach (DataRow row in data.Rows)
			{
				string soba_id = row["soba_id"].ToString();
				string sifra = row["sifra"].ToString();
				string broj_sobe = row["broj_sobe"].ToString();
				string broj_kreveta = row["broj_kreveta"].ToString();
				string tip_sobe = row["tip_sobe"].ToString();
				string salon_id = row["salon_id"].ToString();

				string obrisan = row["obrisan"].ToString();

				Soba newUser = new Soba(Int32.Parse(soba_id), sifra, broj_sobe, Int32.Parse(broj_kreveta), tip_sobe, Int32.Parse(salon_id), obrisan);
				sobaList.Add(newUser);
			}

			foreach (Soba u in sobaList)
			{
				if (u.broj_sobe.Equals(noviBrojSobe))
				{
					return false;
				}
			}

			return true;
		}
	}
}