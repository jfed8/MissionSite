﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MissionSite.DAL;
using MissionSite.Models;


/*
 * Project 2 Mission Site
 * Date: 12/08/16
 * Authors: Klynt Yardley, Jess Clapier, Jaden Feddock, Matthew Christensen
 * Description:  A mission website for users to ask question for specific question for a mission.  
 * The user must be authenticated before seeing the FAQ page. These users, missions, and questions are saved to the local Missionary Database
 * 
 */

namespace MissionSite.Controllers
{
    public class HomeController : Controller
    {

        private MissionaryContext db = new MissionaryContext();


        public ActionResult Index()
        {
           
            return View(db.Mission.ToList()); //List to be used in dropdown list
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //Returns contact page to ask questions that are not related to a specific mission
            List<SelectListItem> subjects = new List<SelectListItem>();
            subjects.Add(new SelectListItem { Text = "Missionary Life", Value = "0" });
            subjects.Add(new SelectListItem { Text = "Teaching", Value = "1" });
            subjects.Add(new SelectListItem { Text = "Companions", Value = "3" });
            subjects.Add(new SelectListItem { Text = "Culture", Value = "4" });
            subjects.Add(new SelectListItem { Text = "Choose a Subject", Value = "5", Selected = true });
            ViewBag.subjectNames = subjects;
      
            return View();
        }
    }
}