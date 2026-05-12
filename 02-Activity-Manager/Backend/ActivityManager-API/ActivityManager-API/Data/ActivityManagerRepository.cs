using ActivityManager_API.Models;

namespace ActivityManager_API.Data
{
    public class ActivityManagerRepository : IActivityManagerRepository
    {
        readonly ActivityManagerDbContext _dbcontext;

        public ActivityManagerRepository(ActivityManagerDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public int SumHours()
        {
            return this._dbcontext.Activities
                .Sum(a => a.Duration);
        }

        public void Create(Activity activity)
        {
            this._dbcontext.Add(activity);
            _dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            Activity toDelete = this.ReadById(id);
            if (toDelete != null)
            {
                this._dbcontext.Remove(toDelete);
            }
            _dbcontext.SaveChanges();
        }

        public IEnumerable<Activity> Read()
        {
            return this._dbcontext.Activities;
        }

        public Activity? ReadById(int id)
        {
            return this._dbcontext.Activities.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Activity activity)
        {
            this._dbcontext.Update(activity);
            _dbcontext.SaveChanges();
        }
    }
}
