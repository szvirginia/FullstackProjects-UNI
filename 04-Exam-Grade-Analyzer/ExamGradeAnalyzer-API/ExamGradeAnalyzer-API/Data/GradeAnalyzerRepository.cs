using ExamGradeAnalyzer_API.Models;

namespace ExamGradeAnalyzer_API.Data
{
    public class GradeAnalyzerRepository : IGradeAnalyzerRepository
    {
        readonly GradeAnalyzerDbContext _dbContext;

        public GradeAnalyzerRepository(GradeAnalyzerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Grade grade)
        {
            this._dbContext.Add(grade);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Grade toDelete = this.ReadById(id);
            if (toDelete != null)
            {
                this._dbContext.Remove(toDelete);
            }
            _dbContext.SaveChanges();
        }

        public decimal? GetAverage()
        {
            return (decimal?)this._dbContext.Grades.Average(x => x.GradeType);
        }

        public IEnumerable<Grade> Read()
        {
            return this._dbContext.Grades;
        }

        public Grade? ReadById(int id)
        {
            return this._dbContext.Grades.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Grade grade)
        {
            this._dbContext.Update(grade);
            _dbContext.SaveChanges();
        }
    }
}
