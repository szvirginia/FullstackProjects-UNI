using CheckPaymentSystem_API.Models;

namespace CheckPaymentSystem_API.Data
{
    public interface ICheckPaymentRepository
    {
        IEnumerable<CheckEntity> Read();
        CheckEntity? ReadById(int id);
        void Create(CheckEntity entity);
        void Update(CheckEntity entity);
        void Delete(int id);
        
        //NON-CRUD
        int SumAllPayment();

    }
}
