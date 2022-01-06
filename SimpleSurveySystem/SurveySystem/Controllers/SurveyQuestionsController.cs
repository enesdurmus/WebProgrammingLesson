using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurveySystem.Data;
using SurveySystem.Models;

namespace SurveySystem.Controllers
{
    public class SurveyQuestionsController : Controller
    {
        private readonly SurveyContext _context;

        public SurveyQuestionsController(SurveyContext context)
        {
            _context = context;
        }

        // GET: SurveyQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.SurveyQuestions.ToListAsync());
        }

        // GET: SurveyQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyQuestion = await _context.SurveyQuestions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (surveyQuestion == null)
            {
                return NotFound();
            }

            return View(surveyQuestion);
        }

        // GET: SurveyQuestions/Create
        public IActionResult Create()
        {
            var questions = _context.Questions.ToList();
            var surveys = _context.Surveys.ToList();
            if (questions != null)
            {
                ViewBag.data1 = questions;
            }

            if (surveys != null)
            {
                ViewBag.data2 = surveys;
            }

            return View();
        }

        // POST: SurveyQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SurveyID,QuestionID,OrderID")] SurveyQuestion surveyQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surveyQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(surveyQuestion);
        }

        // GET: SurveyQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyQuestion = await _context.SurveyQuestions.FindAsync(id);
            if (surveyQuestion == null)
            {
                return NotFound();
            }
            return View(surveyQuestion);
        }

        // POST: SurveyQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SurveyID,QuestionID,OrderID")] SurveyQuestion surveyQuestion)
        {
            if (id != surveyQuestion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surveyQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyQuestionExists(surveyQuestion.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(surveyQuestion);
        }

        // GET: SurveyQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyQuestion = await _context.SurveyQuestions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (surveyQuestion == null)
            {
                return NotFound();
            }

            return View(surveyQuestion);
        }

        // POST: SurveyQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surveyQuestion = await _context.SurveyQuestions.FindAsync(id);
            _context.SurveyQuestions.Remove(surveyQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurveyQuestionExists(int id)
        {
            return _context.SurveyQuestions.Any(e => e.ID == id);
        }
    }
}
