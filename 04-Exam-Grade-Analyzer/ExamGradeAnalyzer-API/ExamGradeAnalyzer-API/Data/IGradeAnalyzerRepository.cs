using ExamGradeAnalyzer_API.Models;

namespace ExamGradeAnalyzer_API.Data
{
    public interface IGradeAnalyzerRepository
    {
        IEnumerable<Grade> Read();
        Grade? ReadById(int id);
        void Create(Grade grade);
        void Update(Grade grade);
        void Delete(int id);

        //NON_CRUD
        decimal? GetAverage();
    }
}
