namespace AracWebApi
{
    public class AracDeposu : IAracDeposu
    {
        public List<Arac> araclar;

        public AracDeposu()
        {
            araclar = new List<Arac>
        {
            new Araba { Id = 1, Renk = "kırmızı", FarlarAcik = false, Tekerlekler = 4 },
            new Araba { Id = 2, Renk = "mavi", FarlarAcik = true, Tekerlekler = 4 },
            new Otobus { Id = 3, Renk = "kırmızı", FarlarAcik = true, Tekerlekler = 6 },
            new Otobus { Id = 4, Renk = "beyaz", FarlarAcik = false, Tekerlekler = 6 },
            new Tekne { Id = 5, Renk = "mavi", FarlarAcik = false, Tekerlekler = 0 },
            new Tekne { Id = 6, Renk = "siyah", FarlarAcik = true, Tekerlekler = 0 }
        };
        }

        public IEnumerable<Arac> RengeGoreAraclariGetir(string renk)
        {
            return araclar.Where(a => a.Renk.Equals(renk, System.StringComparison.OrdinalIgnoreCase));
        }

        public void FarlariAcKapa(int aracId, bool farlarAcik)
        {
            var arac = araclar.FirstOrDefault(a => a.Id == aracId);
            if (arac != null)
            {
                arac.FarlarAcik = farlarAcik;
            }
        }

        public void AraciSil(int aracId)
        {
            var arac = araclar.FirstOrDefault(a => a.Id == aracId);
            if (arac != null)
            {
                araclar.Remove(arac);
            }
        }
    }

}
