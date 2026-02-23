using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AbandonLogger.Controllers
{
    public class AbandonLogModel
    {
        public string UserId { get; set; }
        public string Reason { get; set; }
        public string Timestamp { get; set; }
    }

    public class AbandonLogController : Controller
    {
        [HttpPost]
        public ActionResult Receive()
        {
            try
            {
                Request.InputStream.Position = 0;
                var json = new StreamReader(Request.InputStream).ReadToEnd();

                var serializer = new JavaScriptSerializer();
                var data = serializer.Deserialize<AbandonLogModel>(json);

                var logText = $"{data.Timestamp} | {data.UserId} | {data.Reason}{Environment.NewLine}";
                var path = Server.MapPath("~/App_Data/abandon.log");
                System.IO.File.AppendAllText(path, logText);
				//test01

                return new HttpStatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }
    }
}
