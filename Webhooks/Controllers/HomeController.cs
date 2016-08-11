using System.IO;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Webhooks.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {
            using (var reader = new StreamReader(Request.InputStream))
            {
                var text = reader.ReadToEnd();
                MessageBox.Show(text);

                return Content(text);
            }
        }
    }
}