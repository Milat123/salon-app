namespace SF52_2015.Model
{
	class Salon

	{
		public int salon_id { get; set; }
		public string sifra { get; set; }
		public string naziv { get; set; }
		public string adresa { get; set; }
		public string obrisan { get; set; }

		public Salon()
		{
		}

		public Salon(int salon_id, string sifra, string naziv, string adresa, string obrisan)
		{
			this.salon_id = salon_id;
			this.sifra = sifra;
			this.naziv = naziv;
			this.adresa = adresa;
			this.obrisan = obrisan;
		}
	}
}