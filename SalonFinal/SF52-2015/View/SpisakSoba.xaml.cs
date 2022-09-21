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
	/// Interaction logic for SpisakSoba.xaml
	/// </summary>
	public partial class SpisakSoba : Window
	{
		private string tipZaBrisanje = "SOBA";

		public SpisakSoba()
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
			string query = String.Format("SELECT * FROM SOBA WHERE obrisan = '0'  "); //

			SQLiteConnection connection = new SQLiteConnection(database_connection);
			connection.Open();

			SQLiteCommand command = new SQLiteCommand(query, connection);
			SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			dataAdapter.Fill(data);

			List<Soba> userList = new List<Soba>();
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
				userList.Add(newUser);
			}
			sobaDataGrid.ItemsSource = userList;
		}

		private void txtName_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox t = (TextBox)sender;
			string filter = t.Text;
			ICollectionView cv = CollectionViewSource.GetDefaultView(sobaDataGrid.ItemsSource);
			if (filter == "")
			{
				cv.Filter = null;
			}
			else
			{
				cv.Filter = o =>
				{
					Soba p = o as Soba;
					if (t.Name == "txtId")
					{
						return (p.soba_id == Convert.ToInt32(filter));
					}
					else if (t.Name == "txtIdSalon_id")
					{
						return (p.salon_id == Convert.ToInt32(filter));
					}
					else if (t.Name == "txtIdSifra")
					{
						return (p.sifra.Contains(filter));
					}
					else if (t.Name == "txtIdBroj_sobe")
					{
						return (p.broj_sobe.Contains(filter));
					}
					else if (t.Name == "txtIdBroj_kreveta")
					{
						return (p.broj_kreveta == Convert.ToInt32(filter));
					}
					else if (t.Name == "txtIdTip_sobe")
					{
						return (p.tip_sobe.Contains(filter));
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

		private void DodajBtnSpisakSoba_Click(object sender, RoutedEventArgs e)
		{
			DodajSobu du = new DodajSobu();
			this.Close();
			du.ShowDialog();
		}

		private void IzmeniBtnSpisakSoba_Click(object sender, RoutedEventArgs e)
		{
			if (sobaDataGrid.SelectedItem == null)
			{
				Console.WriteLine("Error000");

				GreskaSelektovanja n = new GreskaSelektovanja();
				n.ShowDialog();
			}
			else
			{
				try
				{
					Soba row = (Soba)sobaDataGrid.SelectedItem;
					if (row == null)
					{

						GreskaSelektovanja n = new GreskaSelektovanja();
						n.ShowDialog();
					}
					else
					{
						int idr = row.soba_id;
						string id = idr.ToString();
						IzmeniSobu iu = new IzmeniSobu(id);
						this.Close();
						iu.ShowDialog();
					}
				}
				catch (Exception e1)
				{
					Console.WriteLine("Error 555" + e1.Message);
					GreskaSelektovanja n = new GreskaSelektovanja();
					n.ShowDialog();
				}
			}
		}

		private void ObrisiBtnSpisakSoba_Click(object sender, RoutedEventArgs e)
		{
			if (sobaDataGrid.SelectedItem == null)
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
						Soba row = (Soba)sobaDataGrid.SelectedItem;

						if (row == null)
						{
							GreskaSelektovanja n = new GreskaSelektovanja();
							n.ShowDialog();
						}
						else
						{
							string id = row.soba_id.ToString();
							string query = "UPDATE SOBA SET obrisan ='" + 1 + "' WHERE soba_id = '" + id + "'";
							dataConnection.ConnectionString = BazaCommon.ConnectionString;
							dataConnection.Open();
							dataCommandBrisanje = new SQLiteCommand(query, dataConnection);
							if (dataCommandBrisanje.ExecuteNonQuery() == 1)
							{
								sobaDataGrid.Items.Refresh();
							}

							string queryZaTermine = "UPDATE TERMIN SET obrisan ='" + 1 + "' WHERE soba_termina_id = '" + id + "'";
							dataCommandBrisanje = new SQLiteCommand(queryZaTermine, dataConnection);
							if (dataCommandBrisanje.ExecuteNonQuery() == 1)
							{
								sobaDataGrid.Items.Refresh();
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
			SpisakSoba s = new SpisakSoba();
			this.Close();
			s.ShowDialog();
		}
	}
}