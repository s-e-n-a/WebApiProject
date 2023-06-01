namespace AracWebApi
{
    public interface IAracDeposu
    {
        IEnumerable<Arac> RengeGoreAraclariGetir(string renk);
        void FarlariAcKapa(int aracId, bool farlarAcik);
        void AraciSil(int aracId);
    }

}
