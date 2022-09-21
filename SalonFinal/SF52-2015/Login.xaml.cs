using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using SF52_2015.Model;

namespace SF52_2015
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		private string korisnickoImeUnos;
		private string lozinkaUnos;

		public event PropertyChangedEventHandler PropertyChanged;

		public Login()
		{
			InitializeComponent();
			korisnickoImeUnos = "";
		}

		//Trenutno se ne koristi
		protected virtual void OnPropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		public string korisnickoImeUnosPath
		{
			get { return korisnickoImeUnos; }
			set
			{
				if (value != korisnickoImeUnos)
				{
					korisnickoImeUnos = value;
					OnPropertyChanged("korisnickoImeUnosPath");
				}
			}
		}

		public string lozinkaUnosPath
		{
			get { return lozinkaUnos; }
			set
			{
				if (value != lozinkaUnos)
				{
					lozinkaUnos = value;
					OnPropertyChanged("lozinkaUnosPath");
				}
			}
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Otkazi_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
		}

		private void UlogujSe_Click(object sender, RoutedEventArgs e)
		{
			string connection = BazaCommon.ConnectionString;

			string query = String.Format("SELECT * FROM KORISNIK WHERE obrisan='0'"); // korsnici koji nisu obrisani imaju obrisan=0

			SQLiteConnection cn = new SQLiteConnection(connection);
			cn.Open();

			SQLiteCommand command = new SQLiteCommand(query, cn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			da.Fill(data);

			// fill list with users
			List<Korisnik> userList = new List<Korisnik>();
			foreach (DataRow row in data.Rows)
			{
				string id = row["korisnik_id"].ToString();
				string ime = row["ime"].ToString();
				string prezime = row["prezime"].ToString();
				string email = row["email"].ToString();

				string korisnicko_ime = row["korisnicko_ime"].ToString();
				string lozinka = row["lozinka"].ToString();
				string tip = row["tip"].ToString();
				string ulogovan = row["ulogovan"].ToString();
				string obrisan = row["obrisan"].ToString();
				string id_salona_zaposlenog_radnika = row["id_salona_zaposlenog_radnika"].ToString();

				Korisnik newUser = new Korisnik(Int32.Parse(id), ime, prezime, email, korisnicko_ime, lozinka, tip, ulogovan, obrisan, Int32.Parse(id_salona_zaposlenog_radnika));
				userList.Add(newUser);
			}
			// check if user exists
			foreach (Korisnik kor in userList)
			{
				//PROveravanje korisnicko imena i lozinke iz baze sa unetim podacima

				if (KorisnickoImeTextBox.Text.Equals(kor.korisnicko_ime))
				{
					if (LozinkaTextBox.Password.Equals(kor.lozinka))
					{// uspesno ulogovan
						string database_connection = BazaCommon.ConnectionString;

						SQLiteConnection connectionUpdateUlogovan = new SQLiteConnection(database_connection);
						connectionUpdateUlogovan.Open();

						string queryUpdateUlogovan = String.Format($"UPDATE korisnik SET ulogovan ='1' WHERE korisnik_id=" + kor.korisnik_id + " ");

						SQLiteCommand commandUpdateUlogovan = new SQLiteCommand(queryUpdateUlogovan, connectionUpdateUlogovan);
						commandUpdateUlogovan.ExecuteNonQuery();
						connectionUpdateUlogovan.Close();
						MainWindow mw = new MainWindow();
						kor.ulogovan = "1";
						mw.SetLogin(kor);

						mw.Show();
						this.Close();
						return;
					}
				}
			}

			LozinkaTextBox.Password = "";
			KorisnickoImeTextBox.Text = "";
			MessageBox.Show("Pogresan unos!");
		}
	}
}