namespace ActivityManager_API.Models
{
    public enum Priority
    {
        Low, Medium, High
    }
    public class Activity
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int Duration { get; set; }
        public Priority Priority { get; set; }
        public bool IsFinished { get; set; }
    }
}
