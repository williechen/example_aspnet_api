using QADemo.Domain.TableDao;

namespace QADemo.Areas.Question.Service;

public class QuestionService
{
    private readonly QuestionDao _questionDao;
    private readonly DBRawExecute _rawExecute;

    public QuestionService(QuestionDao questionDao, DBRawExecute rawExecute)
    {
        _questionDao = questionDao;
        _rawExecute = rawExecute;
    }

    public async Task<IEnumerable<Domain.Entities.Question>> GetQuestions()
    {
        await _rawExecute.GetCount("SELECT * FROM questions", null);
        return await _questionDao.GetAll();
    }

    public async Task<Domain.Entities.Question?> GetQuestion(int? id)
    {
        return await _questionDao.GetOneAsync(id);
    }

    public async Task<int> CreateQuestion(Domain.Entities.Question question)
    {
        return await _questionDao.CreateAsync(question);
    }

    public async Task<int> UpdateQuestion(Domain.Entities.Question question)
    {
        return await _questionDao.UpdateAsync(question);
    }

    public async Task<int> DeleteQuestion(int? id)
    {
        Domain.Entities.Question? question = await GetQuestion(id);
        if (question != null)
        {
            await _questionDao.DeleteAsync(question);
        }
        return id ?? 0;
    }


}
