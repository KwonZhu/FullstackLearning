namespace Practice5.Models
{
    public class Category : BaseModel
    {
        public string CategoryName { get; set; }
        public string CategoryLevel { get; set; }
        public int? ParentId { get; set; }
        public Category? Parent { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
