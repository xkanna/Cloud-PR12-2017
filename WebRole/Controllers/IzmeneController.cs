
using StageData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRole.Controllers
{
    public class IzmeneController : Controller
    {
        // GET: Izmene
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Izmene()
        {
            return View();
        }
        public ActionResult AddStage(string Name, int Id)
        {
            Stage s = new Stage(Name, Id);
            StageDatabase sd = new StageDatabase();
            s.RowKey = Id.ToString();
            sd.AddStage(s);

            return RedirectToAction("Ispisi");
        }
        public ActionResult AddTimeSlot(string Description, DateTime From, DateTime To, int Id)
        {
            TimeSlot ts = new TimeSlot(Description, From, To, Id);
            StageDatabase sd = new StageDatabase();
            ts.RowKey = Id.ToString();
            sd.AddTimeSlot(ts);
            return RedirectToAction("TimeSlots");
        }
        public ActionResult AddArtist( string Name, string Surname, string Genre, int Id)
        {
            Artist a = new Artist(Genre, Name, Surname, Id);
            StageDatabase sd = new StageDatabase();
            a.RowKey = Id.ToString();
            sd.AddArtist(a);
            return RedirectToAction("Artists");
        }
        public ActionResult Ispisi()
        {
            StageDatabase sd = new StageDatabase();
            
            var stages = sd.RetrieveAllStages();
            
            return View(stages);
        }
        public ActionResult Artists()
        {
            StageDatabase sd = new StageDatabase();

            var stages = sd.RetrieveAllArtists();

            return View(stages);
        }
        public ActionResult TimeSlots()
        {
            StageDatabase sd = new StageDatabase();

            var stages = sd.RetrieveAllTimeSlots();

            return View(stages);
        }
        public ActionResult DeleteArtist(int Id)
        {
            StageDatabase sd = new StageDatabase();
            sd.RemoveArtist(Id);
            return RedirectToAction("Artists");
        }
        public ActionResult DeleteStage(int Id)
        {
            StageDatabase sd = new StageDatabase();
            sd.RemoveStage(Id);
            return RedirectToAction("Ispisi");
        }
        public ActionResult DeleteTimeSlot(int Id)
        {
            StageDatabase sd = new StageDatabase();
            sd.RemoveTimeSlot(Id);
            return RedirectToAction("TimeSlots");
        }
        public ActionResult UpdateTimeSlot(string Description, DateTime From, DateTime To, int Id)
        {
            TimeSlot ts = new TimeSlot(Description, From, To, Id);
            StageDatabase sd = new StageDatabase();
            ts.RowKey = Id.ToString();
            sd.UpdateTimeSlot(ts);
            return RedirectToAction("TimeSlots");
        }
        public ActionResult UpdateTimeSlots(int Id)
        {

            return View();
        }
        public ActionResult UpdateStage(string Name, int Id)
        {
            Stage s = new Stage(Name, Id);
            StageDatabase sd = new StageDatabase();
            s.RowKey = Id.ToString();
            sd.UpdateStage(s);

            return RedirectToAction("Ispisi");
        }
        public ActionResult UpdateStages(int Id)
        {

            return View();
        }
        public ActionResult UpdateArtist(string Name, string Surname, string Genre, int Id)
        {
            Artist a = new Artist(Genre, Name, Surname, Id);
            StageDatabase sd = new StageDatabase();
            a.RowKey = Id.ToString();
            sd.UpdateArtist(a);
            return RedirectToAction("Artists");
        }
        public ActionResult UpdateArtists(int Id)
        {

            return View();
        }

    }
}