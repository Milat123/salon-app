using System;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace SF52_2015.View
{
	/// <summary>
	/// Interaction logic for PrikaziRaspored.xaml
	/// </summary>
	public partial class PrikaziRaspored : Window
	{
		private string selektovaniSalonId;
		private int broj;
		public string Raspored { get; set; }

		public PrikaziRaspored(string id)
		{
			InitializeComponent();
			selektovaniSalonId = id;
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
			//Uzima rasporede iz baze koje ce prikazati u tabeli
			string database_connection = BazaCommon.ConnectionString;
			string query = String.Format("SELECT * FROM RASPORED WHERE obrisan = '0' AND salon_id=" + Int32.Parse(selektovaniSalonId)); //

			SQLiteConnection connection = new SQLiteConnection(database_connection);
			connection.Open();

			SQLiteCommand command = new SQLiteCommand(query, connection);
			SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

			DataTable data = new DataTable();
			dataAdapter.Fill(data);

			foreach (DataRow row in data.Rows)
			{
				raspored.Text = row["termini"].ToString();
			}
		}

	}
}