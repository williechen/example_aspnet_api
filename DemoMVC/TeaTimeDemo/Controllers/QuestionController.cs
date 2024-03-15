using Microsoft.AspNetCore.Mvc;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDemo.Models.Models;

namespace TeaTImeDemo.Controllers{
    public class QuestionController: Controller {
        private readonly ApplicationDbContext _db;
        public QuestionController(ApplicationDbContext db){
            _db = db;
        }


        public IActionResult Index(){
            List<Questions> objQuestions = _db.Questions.ToList();
            return View(objQuestions);
        }
 
        [HttpPost]
        public IActionResult Create(Questions questions){

            if (ModelState.IsValid){

            _db.Questions.Add(questions);
            _db.SaveChanges();
            return RedirectToAction("Index");
            } 
            return View();
        }

        public IActionResult Edit(int? id){
            if (id == null || id == 0){
                return NotFound();
            }
            Questions? questions = _db.Questions.Find(id);
            if (questions == null){
              return NotFound();
            }
            return View(questions);
        }

        [HttpPost]
        public IActionResult Edit(Questions questions){
            if (ModelState.IsValid) {
                _db.Questions.Update(questions);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }        

        

    }
}