using AngularWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularWebApplication.Controllers
{
    public class PlayerController : Controller
    {
        //DbContext
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Player
        public ActionResult Index()
        {
            return View();
        }

        //Get Player record by ID
        [HttpGet]
        public JsonResult GetPlayerById(int? id)
        {
            if(id.HasValue && id.Value >0) // check Id has value or null
            {
                var player = db.Players.Where(a => a.PlayerId == id).SingleOrDefault();
                if (player != null)
                {
                    return Json(player, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { Status = "Failure" });

        }

        //Get All Player Records
        [HttpGet]
        public JsonResult GetAllPlayer()
        {
            var player = db.Players.OrderBy(p => p.PlayerId).ToList();
            return Json(player, JsonRequestBehavior.AllowGet);
        }

        //Create View Page
        public ActionResult Create()
        {
            return View();
        }

        //Add new Player record
        [HttpPost]
        public JsonResult Create(Player p)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                var player = db.Players.Where(a => a.PlayerId == p.PlayerId).FirstOrDefault();
                if (player == null)
                {
                    db.Players.Add(p);
                    db.SaveChanges();
                    message = "Success";
                }
                else
                {
                    message = "This id is already saved";
                }
            }
            

            else
            {
                message = "Please fill the form clearly";

            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        //Delete Record
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            var player = db.Players.Where(a => a.PlayerId == id).FirstOrDefault();
            if (player != null)
            {
                db.Players.Remove(player);
                db.SaveChanges();
            }

            return Json(player, JsonRequestBehavior.AllowGet);
        }

        //Return Player Edit Record View Page
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        //Update Player record
        [HttpPost]
        public JsonResult UpdatePlayer(Player player)
        {
            string message = " ";
            if (player !=null && player.PlayerId > 0)
            {
                var CurrentPLayer = db.Players.Where(a => a.PlayerId == player.PlayerId).SingleOrDefault();
                if (CurrentPLayer != null)
                {
                    CurrentPLayer.PlayerId = player.PlayerId;
                    CurrentPLayer.PlayerName = player.PlayerName;
                    CurrentPLayer.Club = player.Club;
                    CurrentPLayer.Position = player.Position;
                    CurrentPLayer.JoinedClubOn = player.JoinedClubOn;

                    //Save
                    db.Players.Attach(CurrentPLayer);
                    db.Entry(CurrentPLayer).State = EntityState.Modified;
                    db.SaveChanges();
                    message = "Success";

                }
                else
                {
                    message = "Player Id is not found";
                }
            }
            return Json(new { Status = "Failure" });
        }

        //return Player Detail View Page
        [HttpGet]
        public ActionResult Detail()
        {
            return View();
        }
    }
}