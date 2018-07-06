using Common;
using NLog;
using Service;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly ITestService _testService = DependecyFactory.GetInstance<ItestService>();
        
        public ActionResult Index()
        {
            _logger.Info("Comenzo el método Index");
            var value = Parameters.TaxValue;
            var courses = _testService.getall();

            _logger.Info("Obtuvo un parametro de app parametrs. config");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}