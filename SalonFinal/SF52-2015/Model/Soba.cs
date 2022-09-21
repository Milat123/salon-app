namespace SF52_2015.Model
{
	class Soba
	{
		public int soba_id { get; set; }
		public string sifra { get; set; }
		public string broj_sobe { get; set; }   // u okviru jednog salona broj sobe je jedinstven
		public int broj_kreveta { get; set; }
		public string tip_sobe { get; set; } //moze da bude sa televizorom i bez televizora
		public int salon_id { get; set; }
		public string obrisan { get; set; }

		public Soba()
		{
		}

		public Soba(int soba_id, string sifra, string broj_sobe, int broj_kreveta, string tip_sobe, int salon_id, string obrisan)
		{
			this.soba_id = soba_id;
			this.sifra = sifra;
			this.broj_sobe = broj_sobe;
			this.broj_kreveta = broj_kreveta;
			this.tip_sobe = tip_sobe;
			this.salon_id = salon_id;
			this.obrisan = obrisan;
		}
	}
}