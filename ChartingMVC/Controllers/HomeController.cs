using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;

namespace ChartingMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var student = new Student();
            student.FirstName = "Brian";
            student.LastName = "Smith";
            student.ReadingLevel = 6;
            student.WritingLevel = 5;
            student.MathLevel = 8;

            Session["myStudent"] = student;
            // see MVC.RazorTools.Charts in NuGet
            // see System.Web.Helpers, Chart, AddSeries
            var type = SeriesChartType.Line;
            return View();
        }

        public ActionResult About()
        {
            var student = (Student)Session["myStudent"];
            ViewBag.Message = string.Format("Session variable 'myStudent' has profile for: {0} {1}", student.FirstName, student.LastName);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}