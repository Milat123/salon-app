using System.Collections.Generic;

namespace SF52_2015.Model
{
	public class Korisnik
	{
		public int korisnik_id { get; set; }
		public string ime { get; set; }
		public string prezime { get; set; }
		public string email { get; set; }
		public string korisnicko_ime { get; set; }
		public string lozinka { get; set; }
		public string tip { get; set; }
		public string ulogovan { get; set; }
		public string obrisan { get; set; }

		public int id_salona_zaposlenog_radnika { get; set; }

		public Korisnik()
		{
		}

		public Korisnik(int korisnik_id, string ime, string prezime, string email, string korisnicko_ime, string lozinka, string tip, string ulogovan, string obrisan, int id_salona_zaposlenog_radnika)
		{
			this.korisnik_id = korisnik_id;
			this.ime = ime;
			this.prezime = prezime;
			this.email = email;
			this.korisnicko_ime = korisnicko_ime;
			this.lozinka = lozinka;
			this.tip = tip;
			this.id_salona_zaposlenog_radnika = id_salona_zaposlenog_radnika;

			this.ulogovan = ulogovan;
			this.obrisan = obrisan;
		}
	}
}