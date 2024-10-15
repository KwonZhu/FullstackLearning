namespace Practice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>
            {
                new CSharp(1, 30),
                new HTML(2, 6),
                new React(3, 30),
            };
        }
    }
}
