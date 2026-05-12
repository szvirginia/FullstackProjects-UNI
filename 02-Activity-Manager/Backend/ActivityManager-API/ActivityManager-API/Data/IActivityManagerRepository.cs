using ActivityManager_API.Models;

namespace ActivityManager_API.Data
{
    public interface IActivityManagerRepository
    {
        IEnumerable<Activity> Read();
        Activity ReadById(int id);
        void Create(Activity activity);
        void Update(Activity activity);
        void Delete(int id);

        //NONCRUD
        int SumHours();
    }
}
