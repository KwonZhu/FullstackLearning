using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    public class CSharpCourse : Course
    {
        // Constructor that calls base class constructor
        public CSharpCourse(int id, int hours) : base(id, "C#", hours) { }
    }
}
