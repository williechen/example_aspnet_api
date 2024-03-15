using Microsoft.AspNetCore.Mvc;
using QADemo.Areas.Question.Service;

namespace QADemo.Areas.Question.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _service;
        public QuestionController(QuestionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Domain.Entities.Question> questions = await _service.GetQuestions();
            return Ok(questions);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Domain.Entities.Question obj)
        {
            int id = await _service.CreateQuestion(obj);
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Domain.Entities.Question obj)
        {
            int id = await _service.UpdateQuestion(obj);
            return Ok(obj);
        }

        [HttpPost]
        public async Task Delete(int? id)
        {
            await _service.DeleteQuestion(id);
        }

    }
}
