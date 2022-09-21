using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using SF52_2015.Model;

namespace SF52_2015.View
{
	/// <summary>
	/// Interaction logic for IzmenaTermina.xaml
	/// </summary>
	public partial class IzmenaTermina : Window
	{
		private int broj;
		private int selektovanaSoba = 1;
		private int selektovanKorisnik = 1;
		private Termin terminZaIzmenu;
		private string zaIzmenuTerminId;

		public IzmenaTermina(string id)
		{
			InitializeComponent();
			UnesiVrednostUTextBox(id);
			//DODAVNJE SOBE U COMBOBOX
			zaIzmenuTerminId = id;
			string connection = BazaCommon.ConnectionString;
			string query = String.Format("SELECT * FROM SOBA WHERE obrisan ='0'");
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

			//DODAVANJE RADNIKA U COMBO BOX
			string connection1 = BazaCommon.ConnectionString;
			string query1 = String.Format("SELECT * FROM KORISNIK WHERE obrisan ='0' AND tip='RADNIK'");
			SQLiteConnection cn1 = new SQLiteConnection(connection1);
			cn1.Open();

			SQLiteCommand command1 = new SQLiteCommand(query1, cn1);
			SQLiteDataAdapter da1 = new SQLiteDataAdapter(command1);

			DataTable data1 = new DataTable();
			da1.Fill(data1);

			foreach (DataRow row in data1.Rows)
			{
				string korisnicko_ime = row["korisnicko_ime"].ToString();
				radnik_zauzeo_termin_idComboBox.Items.Add(korisnicko_ime);
			}

			//DODAVANJE MUSTERIJE U COMBO BOX
			string query2 = String.Format("SELECT * FROM KORISNIK WHERE obrisan ='0' AND tip='MUSTERIJA'");
			SQLiteConnection cn2 = new SQLiteConnection(connection1);
			cn2.Open();

			SQLiteCommand command2 = new SQLiteCommand(query2, cn2);
			SQLiteDataAdapter da2 = new SQLiteDataAdapter(command2);

			DataTable data2 = new DataTable();
			da2.Fill(data2);

			foreach (DataRow row in data2.Rows)
			{
				string korisnicko_ime = row["korisnicko_ime"].ToString();
				musterija_zauzela_termin_idComboBox.Items.Add(korisnicko_ime);
			}

			
		}

		private void UnesiVrednostUTextBox(string id)
		{
			string connection = BazaCommon.ConnectionString;
			string query = String.Format($"SELECT * FROM TERMIN WHERE termin_id={id}");
			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				string termin_id = row["termin_id"].ToString();
				string sifra_termina = row["sifra_termina"].ToString();
				string vreme_zauzeca = row["vreme_zauzeca"].ToString();
				string dan = row["dan"].ToString();
				string tip_tretmana = row["tip_tretmana"].ToString();
				string radnik_zauzeo_termin_id = row["radnik_zauzeo_termin_id"].ToString();
				string soba_termina_id = row["soba_termina_id"].ToString();
				string salon_termina_id = row["salon_termina_id"].ToString();
				string radnik_ime_prezime = row["radnik_ime_prezime"].ToString();
				string broj_sobe = row["broj_sobe"].ToString();
				string musterija_id = row["musterija_id"].ToString();
				string musterija_ime_prezime = row["musterija_ime_prezime"].ToString();

				string obrisan = row["obrisan"].ToString();

				terminZaIzmenu = new Termin(Int32.Parse(termin_id), sifra_termina, vreme_zauzeca, dan, tip_tretmana, Int32.Parse(radnik_zauzeo_termin_id), Int32.Parse(soba_termina_id), obrisan, Int32.Parse(salon_termina_id), radnik_ime_prezime, Int32.Parse(broj_sobe), Int32.Parse(musterija_id), musterija_ime_prezime);
			}
			sifra_terminaTextBox.Text = terminZaIzmenu.sifra_termina;
			vreme_zauzecaTextBox.Text = terminZaIzmenu.vreme_zauzeca;
			danTextBox.Text = terminZaIzmenu.dan;
			tip_masazeComboBox.Text = terminZaIzmenu.tip_tretmana;
		}

		private void IzmeniBtn_Click(object sender, RoutedEventArgs e)
		{
			int selSoba = PronadjiIdSelektovanuSobu();
			int selRadnik = PronadjiIdSelektovanogRadnika();
			int selMusterija = PronadjiIdSelektovaneMusterije();

			string query = " UPDATE TERMIN SET sifra_termina = '" + sifra_terminaTextBox.Text + "', vreme_zauzeca = '" + vreme_zauzecaTextBox.Text + "',dan = '" + danTextBox.Text + "',tip_tretmana = '" + tip_masazeComboBox.Text + "', radnik_zauzeo_termin_id = '" + selRadnik + "', musterija_id = '" + selMusterija + "',soba_termina_id = '" + selSoba + "',obrisan = '" + 0 + "' WHERE termin_id = '" + zaIzmenuTerminId + "' ";

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
				SpisakTermina sk = new SpisakTermina();
				this.Close();
				sk.ShowDialog();
			}
		}

		private int PronadjiIdSelektovanuSobu()
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

		private int PronadjiIdSelektovanogRadnika()
		{
			string sifraSelektovanogKorisnika = radnik_zauzeo_termin_idComboBox.Text;
			string connection = BazaCommon.ConnectionString;
			string query = String.Format($"SELECT * FROM KORISNIK WHERE obrisan = '0' AND korisnicko_ime = '{sifraSelektovanogKorisnika}'");
			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				string korisnik_id = row["korisnik_id"].ToString();
				selektovanKorisnik = Int32.Parse(korisnik_id);
			}
			return selektovanKorisnik;
		}

		private int PronadjiIdSelektovaneMusterije()
		{
			string sifraSelektovanogKorisnika = musterija_zauzela_termin_idComboBox.Text;
			string connection = BazaCommon.ConnectionString;
			string query = String.Format($"SELECT * FROM KORISNIK WHERE obrisan = '0' AND korisnicko_ime = '{sifraSelektovanogKorisnika}'");
			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				string korisnik_id = row["korisnik_id"].ToString();
				selektovanKorisnik = Int32.Parse(korisnik_id);
			}
			return selektovanKorisnik;
		}


		private void OtkaziBtn_Click(object sender, RoutedEventArgs e)
		{

			this.Close();

		}
	}
}