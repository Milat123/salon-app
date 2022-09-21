using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using SF52_2015.Model;

namespace SF52_2015.View
{
	/// <summary>
	/// Interaction logic for DodajTermin.xaml
	/// </summary>
	public partial class DodajTermin : Window
	{
		private int broj;
		private int selektovanaSoba = 1;
		private int selektovanKorisnik = 1;
		private Dictionary<string, int> nazivNaIdSalona = new Dictionary<string, int>();
		private Dictionary<string, int> imeNaIdRadnika = new Dictionary<string, int>();
		private Korisnik ulogovan;

		public DodajTermin()
		{
			InitializeComponent();

			ulogovan = MainWindow.AppWindow.Ulogovan;
			if (ulogovan.tip == "RADNIK")
			{
				radnik_termin_idComboBox.Visibility = Visibility.Hidden;
				RadnikLabela.Visibility = Visibility.Hidden;
				radnik_termin_idComboBox.Text = " ";
			}
			
				DodavanjeSalonaUComboBox();
		}

		private void DodavanjeRadnikaUComboBox(string salondID)
		{
			radnik_termin_idComboBox.Items.Clear();
			//DODAVANJE KORISNIKA U KOMBO BOX
			string connection1 = BazaCommon.ConnectionString;
			string query1 = String.Format("SELECT * FROM KORISNIK WHERE obrisan ='0' and tip = 'RADNIK' and id_salona_zaposlenog_radnika =" + salondID);
			SQLiteConnection cn1 = new SQLiteConnection(connection1);
			cn1.Open();

			SQLiteCommand command1 = new SQLiteCommand(query1, cn1);
			SQLiteDataAdapter da1 = new SQLiteDataAdapter(command1);

			DataTable data1 = new DataTable();
			da1.Fill(data1);

			foreach (DataRow row in data1.Rows)
			{
				string korisnicko_ime = row["ime"].ToString();
				string korisnik_id = row["korisnik_id"].ToString();
				radnik_termin_idComboBox.Items.Add(korisnicko_ime);
				imeNaIdRadnika.Add(korisnicko_ime, Int32.Parse(korisnik_id));
			}
		}

		private void DodavanjeSobaUComboBox(string salondID)
		{
			soba_termina_idComboBox.Items.Clear();
			//DODAVANJE SOBE U KOMBO BOX
			string connection = BazaCommon.ConnectionString;
			string query = String.Format("SELECT * FROM SOBA WHERE obrisan ='0' and salon_id =" + salondID);
			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				string sifra = row["sifra"].ToString();
				soba_termina_idComboBox.Items.Add(sifra);
			}
		}

		private void DodavanjeSalonaUComboBox()
		{
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
				string salon_id = row["salon_id"].ToString();

				salon_idComboBox.Items.Add(naziv + "-" + sifra);

				nazivNaIdSalona.Add(string.Format(naziv + "-" + sifra), Int32.Parse(salon_id));
			}
		}

		private void DodajBtn_Click(object sender, RoutedEventArgs e)
		{
			int selSoba = PronadjiIdSelektovaneSobe();
			int brojsobe = PronadjiBrojSobe();
			int salon_id = nazivNaIdSalona[salon_idComboBox.SelectedItem.ToString()];
			string query = "";
			if (ulogovan.tip == "RADNIK")
			{
				query = String.Format($"INSERT INTO TERMIN ('sifra_termina','vreme_zauzeca','dan','tip_tretmana','radnik_zauzeo_termin_id','soba_termina_id','obrisan', salon_termina_id, 'radnik_ime_prezime', 'broj_sobe', 'musterija_id', 'musterija_ime_prezime') " +
				   $"VALUES ('{sifra_terminaTextBox.Text}','{vreme_zauzecaTextBox.Text}','{danTextBox.Text}','{tip_masazeComboBox.Text}',{ulogovan.korisnik_id},{selSoba},'0', {salon_id}, '{ulogovan.ime + ulogovan.prezime}', {brojsobe}, '0', '')");
			}
			else if (ulogovan.tip == "MUSTERIJA")
			{
				query = String.Format($"INSERT INTO TERMIN ('sifra_termina','vreme_zauzeca','dan','tip_tretmana','radnik_zauzeo_termin_id','soba_termina_id','obrisan', salon_termina_id, 'radnik_ime_prezime', 'broj_sobe', 'musterija_id', 'musterija_ime_prezime') " +
					$"VALUES ('{sifra_terminaTextBox.Text}','{vreme_zauzecaTextBox.Text}','{danTextBox.Text}','{tip_masazeComboBox.Text}',{imeNaIdRadnika[radnik_termin_idComboBox.Text]},{selSoba},'0', {salon_id}, '{radnik_termin_idComboBox.Text}', {brojsobe}, {ulogovan.korisnik_id}, '{ulogovan.ime + " " + ulogovan.prezime}')");
			}
			else if (ulogovan.tip == "ADMIN")
			{
				query = String.Format($"INSERT INTO TERMIN ('sifra_termina','vreme_zauzeca','dan','tip_tretmana','radnik_zauzeo_termin_id','soba_termina_id','obrisan', salon_termina_id, 'radnik_ime_prezime', 'broj_sobe', 'musterija_id', 'musterija_ime_prezime') " +
					$"VALUES ('{sifra_terminaTextBox.Text}','{vreme_zauzecaTextBox.Text}','{danTextBox.Text}','{tip_masazeComboBox.Text}',{imeNaIdRadnika[radnik_termin_idComboBox.Text]},{selSoba},'0', {salon_id}, '{radnik_termin_idComboBox.Text}', {brojsobe}, '0', '')");
			}

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
				this.Close();
			}
		}

		private int PronadjiBrojSobe()
		{
			string sifraSelektovaneSobe = soba_termina_idComboBox.Text;
			string connection = "Data Source=bazaSalon.sqlite;Version=3;";
			string query = String.Format($"SELECT * FROM SOBA WHERE obrisan = '0' AND sifra = '{sifraSelektovaneSobe}'");
			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				string broj_sobe = row["broj_sobe"].ToString();
				return Int32.Parse(broj_sobe);
			}
			return 0;
		}

		private int PronadjiIdSelektovaneSobe()
		{
			string sifraSelektovaneSobe = soba_termina_idComboBox.Text;
			string connection = BazaCommon.ConnectionString;
			string query = String.Format($"SELECT * FROM SOBA WHERE obrisan = '0' AND sifra = '{sifraSelektovaneSobe}'");
			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				string soba_id = row["soba_id"].ToString();
				selektovanaSoba = Int32.Parse(soba_id);
			}
			return selektovanaSoba;
		}

		private void OtkaziBtn_Click(object sender, RoutedEventArgs e)
		{
			SpisakTermina st = new SpisakTermina();
			this.Close();
			st.ShowDialog();
		}

		private void salon_idComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (salon_idComboBox.SelectedItem != null)
			{
				DodavanjeRadnikaUComboBox(nazivNaIdSalona[salon_idComboBox.SelectedItem.ToString()].ToString());
				DodavanjeSobaUComboBox(nazivNaIdSalona[salon_idComboBox.SelectedItem.ToString()].ToString());
			}
		}
	}
}