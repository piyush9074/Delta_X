
using Delta_XDAL;
using Delta_XDataAccessLayer.Models;
using Delta_XDataAccessLayer.Custom_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Delta_XServiceLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Delta_XController : Controller
    {
        DeltaXRepository res;

        public Delta_XController()
        {
            res = new DeltaXRepository();
        }

        [HttpGet]
        public JsonResult GetAllMovies()
        {
            List<AddMovieWithActorList> movlst = new List<AddMovieWithActorList>();

            movlst = res.GetAllMovies();

            return Json(movlst);
        }

        [HttpGet]
        public JsonResult GetAllActors()
        {
            List<Actor> actlst = new List<Actor>();

            actlst = res.GetAllActors();
            return Json(actlst);
        }

        [HttpGet]
        public JsonResult GetAllProducer()
        {
            List<Producer> prodlst = new List<Producer>();

            prodlst = res.GetAllProducer();
            return Json(prodlst);
        }

        [HttpPost]

        public JsonResult AddMovie(MovieRequest cr)
        {
            bool result = false;

            List<string> acta = cr.Act.Split(',').ToList();
            List<string> date = cr.Dor.Split('/').ToList();
            DateTime dt = new DateTime(Int32.Parse(date[2]), Int32.Parse(date[1]), Int32.Parse(date[0]));


            Movie mo = new Movie();

            mo.Name = cr.Name;
            mo.DateOfRelease = dt;

            mo.FkProducer = cr.Producer;
            mo.Plot = cr.Plot;

            result = res.AddMovie(mo, acta);
            return Json(result);
        }

        [HttpPost]
        public JsonResult EditMovie(EditMovieRequest mr)
        {
            bool result = false;
            List<string> acta = mr.Act.Split(',').ToList();
            Movie mov = new Movie();
            mov.Name = mr.Name;
            mov.Plot = mr.Plot;
            mov.FkProducer = mr.Producer;
            List<string> date = mr.Dor.Split('/').ToList();
            DateTime dt = new DateTime(Int32.Parse(date[2]), Int32.Parse(date[1]), Int32.Parse(date[0]));
            mov.DateOfRelease = dt;
            result = res.EditMovie(mr.Id,mov,acta);
       
            return Json(result);
        }
    }
}
