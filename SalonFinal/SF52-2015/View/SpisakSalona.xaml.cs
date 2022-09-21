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
	public partial class SpisakSalona : Window
	{
		private string tipZaBrisanje = "SALON";
		private int broj;
		private int brojac = 0;

		public SpisakSalona()
		{
			InitializeComponent();
			PostaviPravaPristupa();

			using (SQLiteConnection dataConnection = new SQLiteConnection())
			{
				try
				{
					dataConnection.ConnectionString = "Data Source=bazaSalon.sqlite;Version=3;";
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
			string query = String.Format("SELECT * FROM SALON WHERE obrisan = '0'  "); //

			SQLiteConnection connection = new SQLiteConnection(database_connection);
			connection.Open();

			SQLiteCommand command = new SQLiteCommand(query, connection);
			SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			dataAdapter.Fill(data);

			List<Salon> userList = new List<Salon>();
			foreach (DataRow row in data.Rows)
			{
				string salon_id = row["salon_id"].ToString();
				string sifra = row["sifra"].ToString();
				string naziv = row["naziv"].ToString();
				string adresa = row["adresa"].ToString();

				string obrisan = row["obrisan"].ToString();

				Salon newUser = new Salon(Int32.Parse(salon_id), sifra, naziv, adresa, obrisan);
				userList.Add(newUser);
			}
			salonDataGrid.ItemsSource = userList;
		}

		private void txtName_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox t = (TextBox)sender;
			string filter = t.Text;
			ICollectionView cv = CollectionViewSource.GetDefaultView(salonDataGrid.ItemsSource);
			if (filter == "")
			{
				cv.Filter = null;
			}
			else
			{
				cv.Filter = o =>
				{
					Salon p = o as Salon;
					if (t.Name == "txtId")
					{
						return (p.salon_id == Convert.ToInt32(filter));
					}
					else if (t.Name == "txtIdSifra")
					{
						return (p.sifra.Contains(filter));
					}
					else if (t.Name == "txtIdNaziv")
					{
						return (p.naziv.Contains(filter));
					}
					else if (t.Name == "txtIdAdresa")
					{
						return (p.adresa.Contains(filter));
					}

					return (p.sifra.ToUpper().StartsWith(filter.ToUpper()));
				};
			}
		}

		//dozvoljavanje samo brojeva za kucanje kod pretrage po ID
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}

		private void DodajBtnSpisakSalona_Click(object sender, RoutedEventArgs e)
		{
			DodajSalon du = new DodajSalon();
			this.Close();
			du.ShowDialog();
		}

		private void IzmeniBtnSpisakSalona_Click(object sender, RoutedEventArgs e)
		{
			if (salonDataGrid.SelectedItem == null)
			{
				GreskaSelektovanja n = new GreskaSelektovanja();
				n.ShowDialog();
			}
			else
			{
				try
				{
					Salon row = (Salon)salonDataGrid.SelectedItems[0];
					if (row == null)
					{
						GreskaSelektovanja n = new GreskaSelektovanja();
						n.ShowDialog();
					}
					else
					{
						int idr = row.salon_id;
						string id = idr.ToString();
						IzmeniSalon iu = new IzmeniSalon(id);
						this.Close();
						iu.ShowDialog();
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

		private void ObrisiBtnSpisakSalona_Click(object sender, RoutedEventArgs e)
		{
			if (salonDataGrid.SelectedItem == null)
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
						DataRowView drv = salonDataGrid.SelectedItems[0] as DataRowView;
						Salon row = (Salon)salonDataGrid.SelectedItem;

						if (row == null)
						{
							GreskaSelektovanja n = new GreskaSelektovanja();
							n.ShowDialog();
						}
						else
						{
							string id = row.salon_id.ToString();
							string query = "UPDATE SALON SET obrisan ='" + 1 + "' WHERE salon_id = '" + id + "'";
							dataConnection.ConnectionString = @"Data Source=bazaSalon.sqlite;Version=3;";
							dataConnection.Open();
							dataCommandBrisanje = new SQLiteCommand(query, dataConnection);
							if (dataCommandBrisanje.ExecuteNonQuery() == 1)
							{
								salonDataGrid.Items.Refresh();
							}

							string queryZaKorisnike = "UPDATE KORISNIK SET obrisan ='" + 1 + "' WHERE id_salona_zaposlenog_radnika = '" + id + "'";
							dataCommandBrisanje = new SQLiteCommand(queryZaKorisnike, dataConnection);
							if (dataCommandBrisanje.ExecuteNonQuery() == 1)
							{
								salonDataGrid.Items.Refresh();
							}

							string queryZaSobe = "UPDATE SOBA SET obrisan ='" + 1 + "' WHERE salon_id = '" + id + "'";
							dataCommandBrisanje = new SQLiteCommand(queryZaSobe, dataConnection);
							if (dataCommandBrisanje.ExecuteNonQuery() == 1)
							{
								salonDataGrid.Items.Refresh();
							}
			
							string queryZaTermine = "UPDATE TERMIN SET obrisan ='" + 1 + "' WHERE salon_termina_id = '" + id + "'";
							dataCommandBrisanje = new SQLiteCommand(queryZaTermine, dataConnection);
							if (dataCommandBrisanje.ExecuteNonQuery() == 1)
							{
								salonDataGrid.Items.Refresh();
							}

							string queryZaRasporede = "UPDATE RASPORED SET obrisan ='" + 1 + "' WHERE salon_id = '" + id + "'";
							dataCommandBrisanje = new SQLiteCommand(queryZaRasporede, dataConnection);
							if (dataCommandBrisanje.ExecuteNonQuery() == 1)
							{
								salonDataGrid.Items.Refresh();
							}

							this.Close();
							ObavestenjeBrisanja ob = new ObavestenjeBrisanja(tipZaBrisanje);
							ob.ShowDialog();

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
			SpisakSalona s = new SpisakSalona();
			this.Close();
			s.ShowDialog();
		}

		private void PostaviPravaPristupa()
		{//U zavisnosti od tipa ulogovanog videce se odredjeni dugmici
			Korisnik ulogovan = MainWindow.AppWindow.Ulogovan;

			if (ulogovan != null)
			{
				//Korisnik je ulogovan!
				if (ulogovan.tip.Equals("ADMIN"))
				{
					DodajBtnSpisakSalona.Visibility = Visibility.Visible;
					ObrisiBtnSpisakSalona.Visibility = Visibility.Visible;
					IzmeniBtnSpisakSalona.Visibility = Visibility.Visible;
					prikaziRasporedBtn.Visibility = Visibility.Visible;
					generisiBtn.Visibility = Visibility.Visible;
					obrisiRasporedBtn.Visibility = Visibility.Visible;
				}
				else if (ulogovan.tip.Equals("RADNIK"))
				{
					DodajBtnSpisakSalona.Visibility = Visibility.Hidden;
					ObrisiBtnSpisakSalona.Visibility = Visibility.Hidden;
					IzmeniBtnSpisakSalona.Visibility = Visibility.Hidden;
					prikaziRasporedBtn.Visibility = Visibility.Visible;
					generisiBtn.Visibility = Visibility.Hidden;
					obrisiRasporedBtn.Visibility = Visibility.Hidden;
				}
				else if (ulogovan.tip.Equals("MUSTERIJA"))
				{
					DodajBtnSpisakSalona.Visibility = Visibility.Hidden;
					ObrisiBtnSpisakSalona.Visibility = Visibility.Hidden;
					IzmeniBtnSpisakSalona.Visibility = Visibility.Hidden;

					prikaziRasporedBtn.Visibility = Visibility.Visible;
					generisiBtn.Visibility = Visibility.Hidden;
					obrisiRasporedBtn.Visibility = Visibility.Hidden;
				}
			}
			else
			{//Za neregistrovanog korisnika!
				DodajBtnSpisakSalona.Visibility = Visibility.Hidden;
				ObrisiBtnSpisakSalona.Visibility = Visibility.Hidden;
				IzmeniBtnSpisakSalona.Visibility = Visibility.Hidden;
				prikaziRasporedBtn.Visibility = Visibility.Visible;
				generisiBtn.Visibility = Visibility.Hidden;
				obrisiRasporedBtn.Visibility = Visibility.Hidden;
			}
		}

		//GENERISANJE RASPOREDA
		private void GenerisiBtn_Click(object sender, RoutedEventArgs e)
		{
			if (salonDataGrid.SelectedItem == null)
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
						DataRowView drv = salonDataGrid.SelectedItems[0] as DataRowView;
						Salon row = (Salon)salonDataGrid.SelectedItem;

						if (row == null)
						{
							GreskaSelektovanja n = new GreskaSelektovanja();
							n.ShowDialog();
						}
						else
						{//U zavisnosti od selektovang salona generisace se raspored
							string idSelektovaneSalona = row.salon_id.ToString();
							InsertRaspored(idSelektovaneSalona);
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

		private void InsertRaspored(string idSelektovanogSalona)
		{
			//Funckija u kojoj se kreira novi Raspored

			string database_connection = BazaCommon.ConnectionString;

			//PREUZIMANJE TERMINA IZ BAZE
			string queryTermin = String.Format("SELECT * FROM TERMIN WHERE obrisan = '0' AND salon_termina_id = " + Int32.Parse(idSelektovanogSalona)); //
			try
			{
				SQLiteConnection connectionTermin = new SQLiteConnection(database_connection);
				connectionTermin.Open();

				SQLiteCommand commandTermin = new SQLiteCommand(queryTermin, connectionTermin);
				SQLiteDataAdapter dataAdapterTermin = new SQLiteDataAdapter(commandTermin);

				DataTable dataTermin = new DataTable();
				dataAdapterTermin.Fill(dataTermin);

				string termini = "";
				foreach (DataRow row in dataTermin.Rows)
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
					if (musterija_ime_prezime == "")
					{
						musterija_ime_prezime = "NIJE ZAUZETO";
					}

					string obrisan = row["obrisan"].ToString();

					termini += dan + "-" + vreme_zauzeca + "; " + tip_tretmana + "; Radnik: " + radnik_ime_prezime + "; Soba:" + broj_sobe + "; Musterija: " + musterija_ime_prezime + "\n";
				}

				List<Raspored> rasporedList = new List<Raspored>();
				//proveriti da li postoji kreiran raspored u postojecem salonu
				int proveraRasporedaBr = PrebrojRasporede(idSelektovanogSalona);
				if (termini == "")
				{
					Console.WriteLine("\n Nema termina za odabrani salon!!! \n");
					MessageBox.Show("Nema termina za odabrani salon!!!");
					return;
				}

				if (proveraRasporedaBr != -1)

				{
					//Ubacujem raspored u bazu!
					string queryRaspored = String.Format($"INSERT INTO RASPORED ('salon_id','termini','obrisan') " +
					  $"VALUES ({Int32.Parse(idSelektovanogSalona)},'{termini}','0')");

					using (SQLiteConnection dataConnectionRaspored = new SQLiteConnection())
					{
						try
						{
							dataConnectionRaspored.ConnectionString = BazaCommon.ConnectionString;
							dataConnectionRaspored.Open();

							SQLiteCommand dataCommandRaspored = new SQLiteCommand(queryRaspored, dataConnectionRaspored);

							if (dataCommandRaspored.ExecuteNonQuery() == 1)
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
						}
						finally
						{
							dataConnectionRaspored.Close();
						}
					}
				}
				else
				{
					Console.WriteLine("\n Raspored za salon vec postoji!!! \n");
					MessageBox.Show("Raspored za salon vec postoji!!!");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error. . . " + ex.Message);
			}
		}

		private int PrebrojRasporede(string idSalona)
		{
			broj = 0;
			string connection = "Data Source=bazaSalon.sqlite;Version=3";
			string query = String.Format("SELECT * FROM RASPORED WHERE obrisan = '0' and salon_id = " + idSalona);
			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			if(data.Rows.Count > 0)
			{
				//raspored postoji, stavljamo -1
				broj = -1;
			}
			return broj;
		}

		private void PrikaziRasporedBtn_Click(object sender, RoutedEventArgs e)
		{
			//U zavisnosti od selektovanog salona da se prikaze njegov raspored

			if (salonDataGrid.SelectedItem == null)
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
						Salon row = (Salon)salonDataGrid.SelectedItem;

						if (row == null)
						{
							GreskaSelektovanja n = new GreskaSelektovanja();
							n.ShowDialog();
						}
						else
						{
							string idSelektovanogSalona = row.salon_id.ToString();
							PrikaziRaspored pr = new PrikaziRaspored(idSelektovanogSalona);
							pr.ShowDialog();
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

		private void ObrisiRasporedBtn_Click(object sender, RoutedEventArgs e)
		{
			if (salonDataGrid.SelectedItem == null)
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
						Salon row = (Salon)salonDataGrid.SelectedItem;

						if (row == null)
						{
							GreskaSelektovanja n = new GreskaSelektovanja();
							n.ShowDialog();
						}
						else
						{
							string id = row.salon_id.ToString();
							string query = "UPDATE RASPORED SET obrisan ='" + 1 + "' WHERE salon_id = '" + id + "'";
							dataConnection.ConnectionString = @"Data Source=bazaSalon.sqlite;Version=3;";
							dataConnection.Open();
							dataCommandBrisanje = new SQLiteCommand(query, dataConnection);
							if (dataCommandBrisanje.ExecuteNonQuery() == 1)
							{
								salonDataGrid.Items.Refresh();
								this.Close();
								ObavestenjeBrisanja ob = new ObavestenjeBrisanja("RASPORED");
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
	}
}