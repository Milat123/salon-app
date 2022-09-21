using System;
using System.Data.SQLite;
using System.Windows;

namespace SF52_2015.View
{
	/// <summary>
	/// Interaction logic for DodajSalon.xaml
	/// </summary>
	public partial class DodajSalon : Window
	{
		private int broj;

		public DodajSalon()
		{
			InitializeComponent();
		}

		private void DodajBtn_Click(object sender, RoutedEventArgs e)
		{
			string query = String.Format($"INSERT INTO SALON ('sifra','naziv','adresa','obrisan') " +
				$"VALUES ('{sifraTextBox.Text}','{nazivTextBox.Text}','{adresaTextBox.Text}','0')");

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
				SpisakSalona su = new SpisakSalona();
				this.Close();
				su.ShowDialog();
			}
		}

		private void OtkaziBtn_Click(object sender, RoutedEventArgs e)
		{
			SpisakSalona suu = new SpisakSalona();

			this.Close();
			suu.ShowDialog();
		}
	}
}