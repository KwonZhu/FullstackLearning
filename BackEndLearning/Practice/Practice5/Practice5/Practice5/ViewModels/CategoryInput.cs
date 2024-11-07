namespace Practice5.ViewModels
{
    public class BaseCategoryInput
    {
        public string CategroyName { get; set; }
        public int CategoryLevel { get; set; }
        public int? ParentId { get; set; }

    }

    public class AddCategoryInput : BaseCategoryInput
    {

    }
    public class UpdateCategoryInput : BaseCategoryInput
    {
        public int Id { get; set; }
    }
}
