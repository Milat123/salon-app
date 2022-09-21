using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using SF52_2015.Model;
using SF52_2015.View;

namespace SF52_2015
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static MainWindow AppWindow;

		public MainWindow()
		{
			InitializeComponent();
			AppWindow = this;
			SetWindow(ulogovan); //Dozvoljavanje prikaza u zavisnosti od korisnika
		}

		private Korisnik ulogovan;

		internal Korisnik Ulogovan
		{
			get
			{
				return ulogovan;
			}

			set
			{
				ulogovan = value;
			}
		}

		public void SetLogin(Korisnik kor)
		{//Postavljam ulogovanog korisnika kog je pronasao iz baze sa unetim username i lozinkom
			this.ulogovan = kor;
			SetWindow(kor);
		}

		private void SetWindow(Korisnik kor) //prozor koji se otvara nakon logina
		{//Dozvoljavanje prikaza u zavisnosti od tipa korisnika!
			if (this.ulogovan != null)
			{
				this.logoutBtn.Visibility = Visibility.Visible;
				this.LoginBtn.Visibility = Visibility.Hidden;
				if (kor.tip.Equals("ADMIN"))
				{
					this.spisakKorisnikaBtn.Visibility = Visibility.Visible;
					this.spisakSalonaBtn.Visibility = Visibility.Visible;
					this.spisakSobaBtn.Visibility = Visibility.Visible;
					this.spisakTerminaBtn.Visibility = Visibility.Visible;
					this.mojProfilBtn.Visibility = Visibility.Hidden;
					this.dodajTerminRadnikMusterijaBtn.Visibility = Visibility.Hidden;
					this.AutomatskiDodajTerminBtn.Visibility = Visibility.Hidden;
				}
				else if (kor.tip.Equals("MUSTERIJA"))
				{
					this.spisakKorisnikaBtn.Visibility = Visibility.Visible;
					this.spisakSalonaBtn.Visibility = Visibility.Hidden;
					this.spisakSobaBtn.Visibility = Visibility.Hidden;
					this.spisakTerminaBtn.Visibility = Visibility.Hidden;
					this.mojProfilBtn.Visibility = Visibility.Visible;
					this.dodajTerminRadnikMusterijaBtn.Visibility = Visibility.Visible;
					this.AutomatskiDodajTerminBtn.Visibility = Visibility.Visible;
				}
				else // radnik
				{
					this.spisakKorisnikaBtn.Visibility = Visibility.Hidden;
					this.spisakSalonaBtn.Visibility = Visibility.Hidden;
					this.spisakSobaBtn.Visibility = Visibility.Hidden;
					this.spisakTerminaBtn.Visibility = Visibility.Hidden;
					this.mojProfilBtn.Visibility = Visibility.Visible;
					this.dodajTerminRadnikMusterijaBtn.Visibility = Visibility.Visible;
					this.AutomatskiDodajTerminBtn.Visibility = Visibility.Hidden;
				}
			}
			else
			{//NEREGISTROVANI
				this.LoginBtn.Visibility = Visibility.Visible;
				this.logoutBtn.Visibility = Visibility.Hidden;
				this.spisakKorisnikaBtn.Visibility = Visibility.Visible;
				this.spisakSalonaBtn.Visibility = Visibility.Visible;
				this.spisakSobaBtn.Visibility = Visibility.Hidden;
				this.spisakTerminaBtn.Visibility = Visibility.Hidden;
				this.mojProfilBtn.Visibility = Visibility.Hidden;
				this.dodajTerminRadnikMusterijaBtn.Visibility = Visibility.Hidden;
				this.AutomatskiDodajTerminBtn.Visibility = Visibility.Hidden;
			}
		}

		private void Login_Click(object sender, RoutedEventArgs e)
		{
			Login login = new Login();
			login.ShowDialog();
			this.Close();
		}

		private void LogoutBtn_Click(object sender, RoutedEventArgs e)
		{
			string database_connection = BazaCommon.ConnectionString;

			SQLiteConnection connectionUpdateUlogovan = new SQLiteConnection(database_connection);
			connectionUpdateUlogovan.Open();

			string queryUpdateUlogovan = String.Format($"UPDATE korisnik SET ulogovan ='0' WHERE korisnik_id=" + this.ulogovan.korisnik_id + " ");

			SQLiteCommand commandUpdateUlogovan = new SQLiteCommand(queryUpdateUlogovan, connectionUpdateUlogovan);
			commandUpdateUlogovan.ExecuteNonQuery();
			connectionUpdateUlogovan.Close();
			Korisnik kor = this.ulogovan = null;

			SetWindow(kor);
		}

		private void SpisakKorisnikaBtn_Click(object sender, RoutedEventArgs e)
		{
			SpisakKorisnika s = new SpisakKorisnika();
			s.ShowDialog();
		}

		private void SpisakSalonaBtn_Click(object sender, RoutedEventArgs e)
		{
			SpisakSalona s = new SpisakSalona();
			s.ShowDialog();
		}

		private void SpisakSobaBtn_Click(object sender, RoutedEventArgs e)
		{
			SpisakSoba u = new SpisakSoba();
			u.ShowDialog();
		}

		private void SpisakTerminaBtn_Click(object sender, RoutedEventArgs e)
		{
			SpisakTermina s = new SpisakTermina();
			s.ShowDialog();
		}

		private void MojProfilBtn_Click(object sender, RoutedEventArgs e)
		{
			Profil p = new Profil();
			p.ShowDialog();
		}

		private void DodajTerminRadnikMusterijaBtn_Click(object sender, RoutedEventArgs e)
		{
			DodajTermin dtp = new DodajTermin();
			dtp.ShowDialog();
		}

		private void AutomatskiDodajTermin_Click(object sender, RoutedEventArgs e)
		{
			int slobodanTerminId = NadjiSlobodanTermin();
			if (slobodanTerminId == -1)
			{
				MessageBox.Show("Nema slobodnih napravljenih termina, dodajte rucno termin!");
			}
			else
			{
				string query = " UPDATE TERMIN SET musterija_id = '" + ulogovan.korisnik_id + "', musterija_ime_prezime = '" + ulogovan.ime + " " + ulogovan.prezime + "' WHERE termin_id = '" + slobodanTerminId + "' AND obrisan = '0'";

				using (SQLiteConnection dataConnection = new SQLiteConnection())
				{
					try
					{

						dataConnection.ConnectionString = BazaCommon.ConnectionString;
						dataConnection.Open();

						SQLiteCommand dataCommand = new SQLiteCommand(query, dataConnection);
						if (dataCommand.ExecuteNonQuery() == 1)
						{
							MessageBox.Show("Uspesno ste rezervisali termin!");
						}
						else
						{
							MessageBox.Show("Nije moguce dodati!");
						}
					}
					catch (Exception e1)
					{
						Console.WriteLine("Error dataConnection. . . " + e1.Message);
						MessageBox.Show("Doslo je do greske!");
					}
					finally
					{
						dataConnection.Close();
					}
				}
			}
		}

		private int NadjiSlobodanTermin()
		{
			string database_connection = BazaCommon.ConnectionString;
			string query = String.Format("SELECT * FROM TERMIN WHERE obrisan = '0' and  musterija_id = '0'"); // nadji prvi slobodan termin

			SQLiteConnection connection = new SQLiteConnection(database_connection);
			connection.Open();

			SQLiteCommand command = new SQLiteCommand(query, connection);
			SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			dataAdapter.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				string termin_id = row["termin_id"].ToString();
				return Int32.Parse(termin_id);
			}

			return -1; //NEMA SLOBODNOG TERMINA
		}
	}
}