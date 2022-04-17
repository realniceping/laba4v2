using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4v2
{
    internal class Point
    {
        private string name;
        private double x;
        public double X { 
            get { return x; }
            set { x = value; }

        }
        private double y;
        public double Y
        {  
            get { return y; } 
            set { y = value; }
        }

        public Point(double x, double y, string name) {
            this.x = x;
            this.y = y;
            this.name = name;

        }
        public Point() {
            this.x = 0;
            this.y = 0;
            this.name = "O";
        }

        public void change(double x, double y, char name) { 
            //foo
        }



    }
}
