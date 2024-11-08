namespace Practice5.Models
{
    /// <summary>
    /// Represents a category in the system.
    /// </summary>
    public class Category : BaseModel
    {
        /// <summary>
        /// CategroyName
        /// </summary>
        public string CategoryName { get; set; }

        // <summary>
        /// CategoryLevel
        /// </summary>
        public int CategoryLevel { get; set; }

        /// <summary>
        /// ParentId
        /// If null, this category is a top-level category.
        /// </summary>
        public int? ParentId { get; set; }
        public Category? Parent { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
