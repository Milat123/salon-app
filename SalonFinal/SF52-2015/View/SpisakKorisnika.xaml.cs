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
	public partial class SpisakKorisnika : Window
	{
		private string tipZaBrisanje = "KORISNIK";

		public SpisakKorisnika()
		{
			Korisnik ulogovaniKorisnik = MainWindow.AppWindow.Ulogovan;
			InitializeComponent();
			if (ulogovaniKorisnik == null || ulogovaniKorisnik.tip != "ADMIN")
			{
				DodajBtnSpisakKorisnika.Visibility = Visibility.Hidden;
				ObrisiBtnSpisakKorisnika.Visibility = Visibility.Hidden;
				IzmeniBtnSpisakKorisnika.Visibility = Visibility.Hidden;
			}
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
			string query = String.Format("SELECT * FROM KORISNIK WHERE obrisan = '0'  "); //

			SQLiteConnection connection = new SQLiteConnection(database_connection);
			connection.Open();

			SQLiteCommand command = new SQLiteCommand(query, connection);
			SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			dataAdapter.Fill(data);

			List<Korisnik> userList = new List<Korisnik>();
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

				Korisnik newUser = new Korisnik(Int32.Parse(korisnik_id), ime, prezime, email, korisnicko_ime, lozinka, tip, ulogovan, obrisan, Int32.Parse(id_salona_zaposlenog_radnika));

				if (ulogovaniKorisnik == null || ulogovaniKorisnik.tip != "ADMIN")
				{
					// Musterija i neregistrovani korisnik vide samo radnike
					if (newUser.tip == "RADNIK")
					{
						userList.Add(newUser);
					}
				}
				else
				{
					userList.Add(newUser);
				}
			}
			korisniciDataGrid.ItemsSource = userList;
		}

		private void txtName_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox t = (TextBox)sender;
			string filter = t.Text;
			ICollectionView cv = CollectionViewSource.GetDefaultView(korisniciDataGrid.ItemsSource);
			if (filter == "")
			{
				cv.Filter = null;
			}
			else
			{
				cv.Filter = o =>
				{
					Korisnik p = o as Korisnik;
					if (t.Name == "txtId")
					{
						return (p.korisnik_id == Convert.ToInt32(filter));
					}
					else if (t.Name == "txtIdIme")
					{
						return (p.ime.Contains(filter));
					}
					else if (t.Name == "txtIdPrezime")
					{
						return (p.prezime.Contains(filter));
					}
					else if (t.Name == "txtIdKorisnickoIme")
					{
						return (p.korisnicko_ime.Contains(filter));
					}
					else if (t.Name == "txtIdTip")
					{
						return (p.tip.Contains(filter));
					}
					else if (t.Name == "txtEmail")
					{
						return (p.email.Contains(filter));
					}
					return (p.korisnicko_ime.ToUpper().StartsWith(filter.ToUpper()));
				};
			}
		}

		//dozvoljavanje samo brojeva za kucanje kod pretrage po ID
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}

		private void DodajBtnSpisakKorisnika_Click(object sender, RoutedEventArgs e)
		{
			DodajKorisnika dk = new DodajKorisnika();
			this.Close();
			dk.ShowDialog();
		}

		private void IzmeniBtnSpisakKorisnika_Click(object sender, RoutedEventArgs e)
		{
			if (korisniciDataGrid.SelectedItem == null)
			{
				GreskaSelektovanja n = new GreskaSelektovanja();
				n.ShowDialog();
			}
			else
			{
				try
				{
					Korisnik row = (Korisnik)korisniciDataGrid.SelectedItems[0];
					if (row == null)
					{
						GreskaSelektovanja n = new GreskaSelektovanja();
						n.ShowDialog();
					}
					else
					{
						int idr = row.korisnik_id;
						string id = idr.ToString();
						IzmenaKorisnika ik = new IzmenaKorisnika(id);
						this.Close();
						ik.ShowDialog();
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

		private void ObrisiBtnSpisakKorisnika_Click(object sender, RoutedEventArgs e)
		{
			if (korisniciDataGrid.SelectedItem == null)
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
						DataRowView drv = korisniciDataGrid.SelectedItems[0] as DataRowView;
						Korisnik row = (Korisnik)korisniciDataGrid.SelectedItems[0];

						if (row == null)
						{
							GreskaSelektovanja n = new GreskaSelektovanja();
							n.ShowDialog();
						}
						else
						{
							string id = row.korisnik_id.ToString();
							//Logicko brisanje atribut obrisan se postavlja na 1!
							string query = "UPDATE KORISNIK SET obrisan ='" + 1 + "' WHERE korisnik_id = '" + id + "'";
							dataConnection.ConnectionString = BazaCommon.ConnectionString;
							dataConnection.Open();
							dataCommandBrisanje = new SQLiteCommand(query, dataConnection);
							if (dataCommandBrisanje.ExecuteNonQuery() == 1)
							{
								korisniciDataGrid.Items.Refresh();

							}

							string queryZaMusterijineTermine = "UPDATE TERMIN SET obrisan ='" + 1 + "' WHERE musterija_id = '" + id + "'";
							dataCommandBrisanje = new SQLiteCommand(queryZaMusterijineTermine, dataConnection);
							if (dataCommandBrisanje.ExecuteNonQuery() == 1)
							{
								korisniciDataGrid.Items.Refresh();
							}


							string queryZaTermineRadnika = "UPDATE TERMIN SET obrisan ='" + 1 + "' WHERE radnik_zauzeo_termin_id = '" + id + "'";
							dataCommandBrisanje = new SQLiteCommand(queryZaTermineRadnika, dataConnection);
							if (dataCommandBrisanje.ExecuteNonQuery() == 1)
							{
								korisniciDataGrid.Items.Refresh();
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
			SpisakKorisnika s = new SpisakKorisnika();
			this.Close();
			s.ShowDialog();
		}
	}
}