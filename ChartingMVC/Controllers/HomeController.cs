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
            student.StudentWholeName = "Smith, Brian";
            student.GoalLevels = new[] { "0", "20", "70", "80", "100" };
            student.GoalDates = new[] { "03/01", "04/01", "05/01", "06/01", "07/01" };

            Session["myStudent"] = student;
            // see MVC.RazorTools.Charts in NuGet
            // see System.Web.Helpers, Chart, AddSeries
            var type = SeriesChartType.Line;
            return View();
        }

        public ActionResult GoalHelperChart()
        {
            var student = (Student)Session["myStudent"];
            System.Web.Helpers.Chart chart = new System.Web.Helpers.Chart(width: 400, height: 200)
                .AddTitle("Reading Goal Achievement")
                .AddSeries(
                    chartType: "line",
                    legend: "Rainfall",
                    xValue: student.GoalDates,
                    yValues: student.GoalLevels
                )
                .SetYAxis(
                    title: "Achievement"
                )
                .SetXAxis(
                    title: "Assessment Dates"
                );

            return File(chart.GetBytes("png"), "image/png");
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