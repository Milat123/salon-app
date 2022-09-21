namespace SF52_2015.Model
{
	class Termin
	{
		public int termin_id { get; set; }
		public string sifra_termina { get; set; }
		public string vreme_zauzeca { get; set; }
		public string dan { get; set; }
		public string tip_tretmana { get; set; } // antistres masaza ili terapeutska masaza
		public int radnik_zauzeo_termin_id { get; set; }
		public string obrisan { get; set; }
		public int soba_termina_id { get; set; }
		public int salon_termina_id { get; set; }
		public string radnik_ime_prezime { get; set; }
		public int broj_sobe { get; set; }
		public int musterija_id { get; set; }

		public string musterija_ime_prezime { get; set; }

		public Termin()
		{
		}

		public Termin(int termin_id, string sifra_termina, string vreme_zauzeca, string dan, string tip_tretmana, int radnik_zauzeo_termin_id, int soba_termina_id, string obrisan, int salon_termina_id, string radnik_ime_prezime, int broj_sobe, int musterija_id, string musterija_ime_prezime)
		{
			this.termin_id = termin_id;
			this.sifra_termina = sifra_termina;
			this.vreme_zauzeca = vreme_zauzeca;
			this.dan = dan;
			this.tip_tretmana = tip_tretmana;
			this.radnik_zauzeo_termin_id = radnik_zauzeo_termin_id;
			this.obrisan = obrisan;
			this.soba_termina_id = soba_termina_id;
			this.salon_termina_id = salon_termina_id;
			this.radnik_ime_prezime = radnik_ime_prezime;
			this.broj_sobe = broj_sobe;
			this.musterija_id = musterija_id;
			this.musterija_ime_prezime = musterija_ime_prezime;
		}
	}
}