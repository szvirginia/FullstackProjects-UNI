using CheckPaymentSystem_API.Models;

namespace CheckPaymentSystem_API.Data
{
    public class CheckPaymentRepository : ICheckPaymentRepository
    {
        readonly CheckPaymentDbContext _dbContext;

        public CheckPaymentRepository(CheckPaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(CheckEntity entity)
        {
            this._dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            CheckEntity toDelete = this.ReadById(id);
            if (toDelete != null) {this._dbContext.Remove(toDelete); }
            _dbContext.SaveChanges();
        }

        public IEnumerable<CheckEntity> Read()
        {
            return this._dbContext.Checks;
        }

        public CheckEntity? ReadById(int id)
        {
            return this._dbContext.Checks.FirstOrDefault(x => x.Id == id);
        }

        public int SumAllPayment()
        {
            return this._dbContext.Checks
                .Where(x => x.IsProcessed == true)
                .Sum(s => s.Paid);
        }

        public void Update(CheckEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
