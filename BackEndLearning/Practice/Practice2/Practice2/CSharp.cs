using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    public class CSharp : Course
    {
        // Constructor that calls base class constructor
        public CSharp(int id, int hours) : base(id, "C#", hours) { }
    }
}
