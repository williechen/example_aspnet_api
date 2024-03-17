using QADemo.Bases;
using QADemo.Module.SftpMod.Service;

namespace QADemo.Areas.Question.Service;

public class QuestionService
{
    private readonly DbUnitOfWork _dbUnitOfWork;

    private readonly SftpService _sftpService;

    public QuestionService(DbUnitOfWork dbUnitOfWork, SftpService sftpService)
    {
        _dbUnitOfWork = dbUnitOfWork;
        _sftpService = sftpService;
    }

    public async Task<IEnumerable<Domain.Entities.Question>> GetQuestions()
    {
        await _dbUnitOfWork.dbRawExecute.GetCount("SELECT * FROM questions", null, 60);
        return await _dbUnitOfWork.questionDao.GetAll();
    }

    public async Task<Domain.Entities.Question?> GetQuestion(int? id)
    {
        _sftpService.GetFileList("/");

        return await _dbUnitOfWork.questionDao.GetOneAsync(id);
    }

    public async Task<int> CreateQuestion(Domain.Entities.Question question)
    {
        return await _dbUnitOfWork.questionDao.CreateAsync(question);
    }

    public async Task<int> UpdateQuestion(Domain.Entities.Question question)
    {
        return await _dbUnitOfWork.questionDao.UpdateAsync(question);
    }

    public async Task<int> DeleteQuestion(int? id)
    {
        Domain.Entities.Question? question = await GetQuestion(id);
        if (question != null)
        {
            await _dbUnitOfWork.questionDao.DeleteAsync(question);
        }
        return id ?? 0;
    }


}