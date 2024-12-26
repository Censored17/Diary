﻿using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDBContext _db;
        public DiaryEntriesController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries.ToList();
            return View(objDiaryEntryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title too short");
            }

            if (ModelState.IsValid) 
            {
                _db.DiaryEntries.Add(obj);//Adds diary entry to db
                _db.SaveChanges();//Saves the changes 
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }


            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null) 
            {
                return NotFound();
            }

            return View();

        }
        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title too short");
            }

            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Update(obj);//Update the diary entry
                _db.SaveChanges();//Saves the changes 
                return RedirectToAction("Index");
            }

            return View(obj);
        }

    }
}
