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
	/// Interaction logic for IzmeniSobu.xaml
	/// </summary>
	public partial class IzmeniSobu : Window
	{
		private Dictionary<string, int> imeSalonaNaId = new Dictionary<string, int>();

		private Soba sobaZaIzmenu;
		private string zaIzmenu;

		public IzmeniSobu(string id)
		{
			InitializeComponent();
			UnesiVrednostUTextBox(id);
			//DODAVNJE SALONA U COMBOBOX
			zaIzmenu = id;
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
				string salonId = row["salon_id"].ToString();

				salon_idComboBox.Items.Add(naziv + "-" + sifra);

				imeSalonaNaId.Add(naziv + "-" + sifra, Int32.Parse(salonId));
			}
		}

		private void UnesiVrednostUTextBox(string id)
		{
			string connection = BazaCommon.ConnectionString;
			string query = String.Format($"SELECT * FROM SOBA WHERE soba_id={id}");
			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				string soba_id = row["soba_id"].ToString();
				string sifra = row["sifra"].ToString();
				string broj_sobe = row["broj_sobe"].ToString();
				string broj_kreveta = row["broj_kreveta"].ToString();
				string tip_sobe = row["tip_sobe"].ToString();
				string salon_id = row["salon_id"].ToString();

				string obrisan = row["obrisan"].ToString();

				sobaZaIzmenu = new Soba(Int32.Parse(soba_id), sifra, broj_sobe, Int32.Parse(broj_kreveta), tip_sobe, Int32.Parse(salon_id), obrisan);
			}
			sifraTextBox.Text = sobaZaIzmenu.sifra;
			broj_sobeTextBox.Text = sobaZaIzmenu.broj_sobe;
			broj_krevetaTextBox.Text = sobaZaIzmenu.broj_kreveta.ToString();
			tip_sobeComboBox.Text = sobaZaIzmenu.tip_sobe;
		}

		private void IzmeniBtn_Click(object sender, RoutedEventArgs e)
		{
			int selSalon = imeSalonaNaId[salon_idComboBox.SelectedItem.ToString()];

			string query = " UPDATE SOBA SET sifra = '" + sifraTextBox.Text + "', broj_sobe = '" + broj_sobeTextBox.Text + "',broj_kreveta = '" + broj_krevetaTextBox.Text + "',tip_sobe = '" + tip_sobeComboBox.Text + "', salon_id = '" + selSalon + "',obrisan = '" + 0 + "' WHERE soba_id = '" + zaIzmenu + "' ";

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
				SpisakSoba su = new SpisakSoba();
				this.Close();
				su.ShowDialog();
			}
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
	}
}