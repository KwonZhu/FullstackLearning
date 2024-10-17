using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    public class React : Course
    {
        // Constructor that calls base class constructor
        public React(int id, int hours) : base(id, "React", hours) { }
    }
}