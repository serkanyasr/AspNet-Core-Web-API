using empty_template.Models;
using Microsoft.AspNetCore.Mvc;

namespace empty_template.Controllers
{
    [ApiController] // Bu özellik, varsayılan hata sayfaları ve diğer API özelliklerinin bu sınıfa kazandırılmasını sağlar.
    [Route("/home")] // Bu sınıfa ait işlemlerin gönderileceği rota adresini belirler. *EndPoint*
    public class HomeController : ControllerBase // Bu sınıfın bir controller (denetleyici) olarak davranabilmesi için ControllerBase sınıfından miras alması gerekir.
    {
        [HttpGet]

        // IActionResult sayesinde, yapılan sorguların 200, 404, 501 gibi durum kodlarını geriye döndürmemiz mümkündür.
        public IActionResult GetMessage()
        {
            var result = new ResponseModel()
            {
                HttpStatus = 200,
                Message = "Hello ASP.NET API"
            };
            return Ok(result);
            // Alternatif olarak, aşağıdaki yapıları kullanarak farklı durum kodları döndürebiliriz:
            // return BadRequest(result); // 400 Durum kodu
            // return NotFound(result);   // 404 Durum kodu
        }
    }
}
