using Microsoft.AspNetCore.Mvc;

namespace AracWebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class AraclarController : ControllerBase
    {
        private readonly IAracDeposu aracDeposu;

        public AraclarController(IAracDeposu aracDeposu)
        {
            this.aracDeposu = aracDeposu;
        }

        [HttpGet("arabalar")]
        public ActionResult<IEnumerable<Arac>> RengeGoreArabalarGetir(string renk)
        {
            var arabalar = aracDeposu.RengeGoreAraclariGetir(renk)
                                       .OfType<Araba>()
                                       .ToList();
            return Ok(arabalar);
        }

        [HttpGet("otobusler")]
        public ActionResult<IEnumerable<Arac>> RengeGoreOtobuslerGetir(string renk)
        {
            var otobusler = aracDeposu.RengeGoreAraclariGetir(renk)
                                        .OfType<Otobus>()
                                        .ToList();
            return Ok(otobusler);
        }

        [HttpGet("tekneler")]
        public ActionResult<IEnumerable<Arac>> RengeGoreTeknelerGetir(string renk)
        {
            var tekneler = aracDeposu.RengeGoreAraclariGetir(renk)
                                        .OfType<Tekne>()
                                        .ToList();
            return Ok(tekneler);
        }

        [HttpPost("{aracId}/farlar")]
        public IActionResult FarlariAcKapa(int aracId, [FromBody] bool farlarAcik)
        {
            aracDeposu.FarlariAcKapa(aracId, farlarAcik);
            return NoContent();
        }

        [HttpDelete("{aracId}")]
        public IActionResult AraciSil(int aracId)
        {
            aracDeposu.AraciSil(aracId);
            return NoContent();
        }
    }

}
