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
    public class SurveyResponsesController : Controller
    {
        private readonly SurveyContext _context;

        public SurveyResponsesController(SurveyContext context)
        {
            _context = context;
        }
        public IActionResult SelectSurvey()
        {
            var surveys = _context.Surveys.ToList();
            if (surveys != null)
            {
                ViewBag.data1 = surveys;
            }

            return View();
        }

        public async Task<IActionResult> SaveResponses(string? userName, string? Title, string? response0, string? response1, string? response2, string? response3, string? response4)
        {
            if (Title == null)
            {
                return View();
            }
            else
            {
                TempData["Title"] = Title;

                var survey = await _context.Surveys.FirstOrDefaultAsync(i => i.Title == Title);

                var surveyQuestionsIds = _context.SurveyQuestions.Where(i => i.SurveyID == survey.ID).ToList();

                List<String> responses = new List<string>();
                responses.Add(response0);
                responses.Add(response1);
                responses.Add(response2);
                responses.Add(response3);

                for (int i = 0; i < surveyQuestionsIds.Count; i++)
                {
                    SurveyResponse surveyResponse = new SurveyResponse();
                    surveyResponse.Response = responses.ElementAt(i);
                    surveyResponse.FilledBy = userName;
                    surveyResponse.SurveyID = survey.ID;
                    surveyResponse.QuestionID = surveyQuestionsIds[i].QuestionID;
                    _context.Add(surveyResponse);
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SolveSurvey(string? Title)
        {
            if (Title == null)
            {
                return View();
            }
            else
            {
                TempData["Title"] = Title;

                var survey = await _context.Surveys.FirstOrDefaultAsync(i => i.Title == Title);

                var surveyQuestionsIds = _context.SurveyQuestions.Where(i => i.SurveyID == survey.ID).ToList();

                List<Question> questions = new List<Question>();

                for (int i = 0; i < surveyQuestionsIds.Count; i++)
                {
                    questions.Add(_context.Questions.FirstOrDefault(x => x.ID == surveyQuestionsIds[i].QuestionID));
                }

                ViewBag.data3 = questions;

                return View();
            }
        }

        // GET: SurveyResponses
        public async Task<IActionResult> Index()
        {
            return View(await _context.SurveyResponses.ToListAsync());
        }

        // GET: SurveyResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyResponse = await _context.SurveyResponses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (surveyResponse == null)
            {
                return NotFound();
            }

            return View(surveyResponse);
        }

        // GET: SurveyResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SurveyResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SurveyID,QuestionID,Response,FilledBy")] SurveyResponse surveyResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surveyResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(surveyResponse);
        }

        // GET: SurveyResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyResponse = await _context.SurveyResponses.FindAsync(id);
            if (surveyResponse == null)
            {
                return NotFound();
            }
            return View(surveyResponse);
        }

        // POST: SurveyResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SurveyID,QuestionID,Response,FilledBy")] SurveyResponse surveyResponse)
        {
            if (id != surveyResponse.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surveyResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyResponseExists(surveyResponse.ID))
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
            return View(surveyResponse);
        }

        // GET: SurveyResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyResponse = await _context.SurveyResponses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (surveyResponse == null)
            {
                return NotFound();
            }

            return View(surveyResponse);
        }

        // POST: SurveyResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surveyResponse = await _context.SurveyResponses.FindAsync(id);
            _context.SurveyResponses.Remove(surveyResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurveyResponseExists(int id)
        {
            return _context.SurveyResponses.Any(e => e.ID == id);
        }
    }
}
