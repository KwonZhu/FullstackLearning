using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    public class HTML : Course
    {
        // Constructor that calls base class constructor
        public HTML(int id, int hours) : base(id, "HTML", hours) { }
    }
}