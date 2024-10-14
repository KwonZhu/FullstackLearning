using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }

        public Teacher(int id, string name)
        {
            ID = id;
            Name = name;
            Courses = new List<Course>();
        }
    }
}
