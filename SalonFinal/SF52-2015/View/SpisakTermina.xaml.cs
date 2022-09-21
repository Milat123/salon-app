using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using SF52_2015.Model;

namespace SF52_2015.View
{
	/// <summary>
	/// Interaction logic for SpisakKorisnika.xaml
	/// </summary>
	public partial class SpisakTermina : Window
	{
		private string tipZaBrisanje = "TERMIN";

		public SpisakTermina()
		{
			InitializeComponent();
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
			string query = String.Format("SELECT * FROM TERMIN WHERE obrisan = '0'  "); //

			SQLiteConnection connection = new SQLiteConnection(database_connection);
			connection.Open();

			SQLiteCommand command = new SQLiteCommand(query, connection);
			SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			dataAdapter.Fill(data);

			List<Termin> userList = new List<Termin>();
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

				Termin termin = new Termin(Int32.Parse(termin_id), sifra_termina, vreme_zauzeca, dan, tip_tretmana, Int32.Parse(radnik_zauzeo_termin_id), Int32.Parse(soba_termina_id), obrisan, Int32.Parse(salon_termina_id), radnik_ime_prezime, Int32.Parse(broj_sobe), Int32.Parse(musterija_id), musterija_ime_prezime);
				userList.Add(termin);
			}
			terminiDataGrid.ItemsSource = userList;
		}

		private void txtName_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox t = (TextBox)sender;
			string filter = t.Text;
			ICollectionView cv = CollectionViewSource.GetDefaultView(terminiDataGrid.ItemsSource);
			if (filter == "")
			{
				cv.Filter = null;
			}
			else
			{
				cv.Filter = o =>
				{
					Termin p = o as Termin;
					if (t.Name == "txtId")
					{
						return (p.termin_id == Convert.ToInt32(filter));
					}
					else if (t.Name == "txtIdRadnik_zauzeo_termi_id")
					{
						return (p.radnik_zauzeo_termin_id == Convert.ToInt32(filter));
					}
					else if (t.Name == "txtIdSoba_termina_id")
					{
						return (p.broj_sobe == Convert.ToInt32(filter));
					}
					else if (t.Name == "txtIdSifra_termina")
					{
						return (p.sifra_termina.Contains(filter));
					}
					else if (t.Name == "txtIdVreme_zauzeca")
					{
						return (p.vreme_zauzeca.Contains(filter));
					}
					else if (t.Name == "txtIdDan")
					{
						return (p.dan.Contains(filter));
					}
					else if (t.Name == "txtIdTip_tretmana")
					{
						return (p.tip_tretmana.Contains(filter));
					}
					else if (t.Name == "txtMusterija")
					{
						return (p.musterija_ime_prezime.Contains(filter));
					}
					else if (t.Name == "txtSalonID")
					{
						return (p.salon_termina_id == Convert.ToInt32(filter));
					}

					

					return (p.sifra_termina.ToUpper().StartsWith(filter.ToUpper()));
				};
			}
		}

		//dozvoljavanje samo brojeva za kucanje kod pretrage po ID
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}

		private void DodajBtnSpisakTermina_Click(object sender, RoutedEventArgs e)
		{
			DodajTermin dt = new DodajTermin();
			this.Close();
			dt.ShowDialog();
		}

		private void IzmeniBtnSpisakTermina_Click(object sender, RoutedEventArgs e)
		{
			if (terminiDataGrid.SelectedItem == null)
			{
				GreskaSelektovanja n = new GreskaSelektovanja();
				n.ShowDialog();
			}
			else
			{
				try
				{
					Termin row = (Termin)terminiDataGrid.SelectedItem;
					if (row == null)
					{
						GreskaSelektovanja n = new GreskaSelektovanja();
						n.ShowDialog();
					}
					else
					{
						int idr = row.termin_id;//Nadji id selektovanog termina
						string id = idr.ToString();
						IzmenaTermina it = new IzmenaTermina(id);
						this.Close();
						it.ShowDialog();
					}
				}
				catch (Exception e1)
				{
					Console.WriteLine("Error" + e1.Message);
					GreskaSelektovanja n = new GreskaSelektovanja();
					n.ShowDialog();
				}
			}
		}

		private void ObrisiBtnSpisakTermina_Click(object sender, RoutedEventArgs e)
		{
			if (terminiDataGrid.SelectedItem == null)
			{
				GreskaSelektovanja n = new GreskaSelektovanja();
				n.ShowDialog();
			}
			else
			{
				SQLiteCommand dataCommandBrisanje = new SQLiteCommand();
				using (SQLiteConnection dataConnection = new SQLiteConnection())
					try
					{
						DataRowView drv = terminiDataGrid.SelectedItems[0] as DataRowView;
						Termin row = (Termin)terminiDataGrid.SelectedItems[0];

						if (row == null)
						{
							GreskaSelektovanja n = new GreskaSelektovanja();
							n.ShowDialog();
						}
						else
						{
							string id = row.termin_id.ToString();
							string query = "UPDATE TERMIN SET obrisan ='" + 1 + "' WHERE termin_id = '" + id + "'";
							dataConnection.ConnectionString = BazaCommon.ConnectionString;
							dataConnection.Open();
							dataCommandBrisanje = new SQLiteCommand(query, dataConnection);
							if (dataCommandBrisanje.ExecuteNonQuery() == 1)
							{
								terminiDataGrid.Items.Refresh();
								this.Close();
								ObavestenjeBrisanja ob = new ObavestenjeBrisanja(tipZaBrisanje);
								ob.ShowDialog();
							}
							else
							{
								MessageBox.Show("Nije moguce obrisati!");
							}
						}
					}
					catch (SQLiteException ex)
					{
						MessageBox.Show(ex.ToString());
					}
					finally
					{
						dataConnection.Close();
					}
			}
		}

		private void Refresh_Click(object sender, RoutedEventArgs e)
		{
			SpisakTermina s = new SpisakTermina();
			this.Close();
			s.ShowDialog();
		}
	}
}