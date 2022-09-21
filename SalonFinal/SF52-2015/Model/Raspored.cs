using System.Collections.Generic;

namespace SF52_2015.Model
{
	class Raspored
	{
		public int raspored_id { get; set; }
		public int salon_id { get; set; }
		public string termini { get; set; }

		public string obrisan { get; set; }

		public Raspored()
		{
		}

		public Raspored(int raspored_id, int salon_id, string termini, string obrisan)
		{
			this.raspored_id = raspored_id;
			this.salon_id = salon_id;
			this.obrisan = obrisan;
			this.termini = termini;
		}
	}
}