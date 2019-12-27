using Microsoft.AspNetCore.Mvc;

namespace Gemini.Core.Api.Controllers
{
    /// <summary>
    /// 一系列简单的测试接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController :ControllerBase
    {
        /// <summary>
        /// 一个简单的测试接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index() {
            return Ok(new { name = "maaici", age = 27 });
        }
    }
}
