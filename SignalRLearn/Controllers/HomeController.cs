using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRLearn.Business;
using System.Threading.Tasks;

namespace SignalRLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly MyBusiness _myBusiness;

        public HomeController(MyBusiness myBusiness)
        {
            _myBusiness = myBusiness;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
    }
}

// Storngly Typed Hubs özelliği ile türü kesin belirlenmiş hublar tanımlanarak , metinsel yapılanmanın yarattığı handikaplardan bir nebze olsun arınabilmeyi ve client'ta tetiklenecek olan metot bildiriminin server'da derleme zamanındaki denetimini etkinleştirmeyi sağlayabiliriz.
