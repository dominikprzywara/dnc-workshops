using Microsoft.AspNetCore.Mvc;

namespace Store.Services.Products.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        public IActionResult Get() => Content("Store products service.");
    }
}
