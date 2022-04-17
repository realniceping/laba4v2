using System;
using System.Collections;
using System.Collections.Generic;



namespace laba4v2
{

    delegate void AreaEventHandler();
    class Trapezoid: ITrapezoid
    {
        public event AreaEventHandler OnAreaIsOne; 

        private double oldArea;

        private void FirstMessage() {
            Console.WriteLine("After you change one poit area of your trapezoid become to one");
            Console.Write("Old area is = " + this.oldArea);
        }

         private void SecondMessage() {
            Console.WriteLine("New area is = " + this.GetArea());
         }

        private void AreaTrigger()
        {
            if (GetArea() == 1.00)
            {

            }
        }


        private List<Point> p;

        //try to commit it 
        public Point this[int index]
        {
            get
            {
                return p[index];
            }
            set
            {

                this.oldArea = GetArea();
                Point temp = p[index];
                p[index] = value;



                if (this.AreItTrapezoid() == true)
                {
                    Console.WriteLine("point successfuly changed");


                }
                else
                {
                    p[index] = temp;    
                    Console.WriteLine("If you change point like this, you figure don't keep be trapezoid");
                }

                //throw new Exception();
            }
        }


        double a, b, c, d; //где а и б основание,  с и д боковые стороны
        private string name;



        public Trapezoid()
        {
            this.p = new List<Point>();
            double x;
            double y;
            this.name = "ABCD";
            bool valid = false;
            string[] names = { "A", "B", "C", "D" }; // тут в конструкторе, я создаю точки до тех пор, пока пользователь не введет корректные данные
            do
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.Write("Enter X coord of point " + names[i] + ">> ");
                    x = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Y coord of point " + names[i] + ">> ");
                    y = Convert.ToDouble(Console.ReadLine());
                    Point temp = new Point(x, y, names[i]);
                    this.p.Add(temp);
                }
                valid = AreItTrapezoid(); // Функция вернет тру только тогда, когда пользователь введет корректные данные
                if (valid == false)
                {
                    Console.WriteLine("Try to create this fifure again");
                }
                else
                {
                    Console.WriteLine("trapezoid successfuly created");
                }
            } while (valid == false);




        }
        public bool AreItTrapezoid()
        {
            // here i try to check are it's a real trapezoid
            // valid change to true only if trapezoid have two parallel side
            // умные люди подсказали, что это проверка на коллиниарность 
            if (this.p[3].X - this.p[0].X == 0 || this.p[2].X - this.p[1].X == 0 || this.p[1].X - this.p[0].X == 0 || this.p[2].X - this.p[3].X == 0)
            {
                if (this.p[3].X - this.p[0].X == 0 && this.p[2].X - this.p[1].X == 0)
                {
                    this.a = Math.Abs(this.p[1].Y - this.p[2].Y);
                    this.b = Math.Abs(this.p[3].Y - this.p[0].Y);
                    this.c = Math.Sqrt(Math.Pow(this.p[3].X - this.p[2].X, 2) + Math.Pow(this.p[3].Y - this.p[2].Y , 2));
                    this.d = Math.Sqrt(Math.Pow(this.p[0].X - this.p[1].X, 2) + Math.Pow(this.p[0].Y - this.p[1].Y, 2));
                    return true;
                }
                else if (this.p[1].X - this.p[0].X == 0 && this.p[2].X - this.p[3].X == 0)
                {
                    this.a = Math.Abs(this.p[0].Y - this.p[1].Y);
                    this.b = Math.Abs(this.p[2].Y - this.p[3].Y);
                    this.c = Math.Sqrt(Math.Pow(this.p[2].X - this.p[1].X, 2) + Math.Pow(this.p[2].Y - this.p[1].Y, 2));
                    this.d = Math.Sqrt(Math.Pow(this.p[3].X - this.p[0].X, 2) + Math.Pow(this.p[3].Y - this.p[0].Y, 2));

                    return true;
                }

            }
            else
            {
                if ((this.p[2].Y - this.p[1].Y) / (this.p[2].X - this.p[1].X) == (this.p[3].Y - this.p[0].Y) / (this.p[3].X - this.p[0].X))
                {
                    this.a = Math.Sqrt(Math.Pow(this.p[2].X - this.p[1].X, 2) + Math.Pow(this.p[2].Y - this.p[1].Y, 2));
                    this.b = Math.Sqrt(Math.Pow(this.p[3].X - this.p[0].X, 2) + Math.Pow(this.p[3].Y - this.p[0].Y, 2));
                    this.c = Math.Sqrt(Math.Pow(this.p[0].X - this.p[1].X, 2) + Math.Pow(this.p[0].Y - this.p[1].Y, 2));
                    this.d = Math.Sqrt(Math.Pow(this.p[2].X - this.p[3].X, 2) + Math.Pow(this.p[2].Y - this.p[3].Y, 2));

                    return true;
                }
                else if ((this.p[1].Y - this.p[0].Y) / (this.p[1].X - this.p[0].X) == (this.p[2].Y - this.p[3].Y) / (this.p[2].X - this.p[3].X))
                {
                    this.a = Math.Sqrt(Math.Pow(this.p[1].X - this.p[0].X, 2) + Math.Pow(this.p[1].Y - this.p[0].Y, 2));
                    this.b = Math.Sqrt(Math.Pow(this.p[2].X - this.p[3].X, 2) + Math.Pow(this.p[2].Y - this.p[3].Y, 2));
                    this.c = Math.Sqrt(Math.Pow(this.p[2].X - this.p[1].X, 2) + Math.Pow(this.p[2].Y - this.p[1].Y, 2));
                    this.d = Math.Sqrt(Math.Pow(this.p[3].X - this.p[0].X, 2) + Math.Pow(this.p[3].Y - this.p[0].Y, 2));
                    return true;
                }
                else { return false; }
            }
            return false;
        }


        public void ChangePoint() {
            string change;
            double newX, newY;
            Point temp;
            Console.Write("Choose point what you want to change(A, B, C, D)>> ");
            change = Console.ReadLine();
            switch (change) {
                case "A":
                    Console.Write("Enter new X coord>> ");
                    newX = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new Y coord>> ");
                    newY = Convert.ToInt32(Console.ReadLine());
                    temp = new Point(newX, newY, "A");
                    this[0] = temp;

                    break;
                case "B":
                    Console.Write("Enter new X coord>> ");
                    newX = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new Y coord>> ");
                    newY = Convert.ToInt32(Console.ReadLine());
                    temp = new Point(newX, newY, "B");
                    this[1] = temp;
                    break;
                case "C":
                    Console.Write("Enter new X coord>> ");
                    newX = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new Y coord>> ");
                    newY = Convert.ToInt32(Console.ReadLine());
                    temp = new Point(newX, newY, "C");
                    this[2] = temp;
                    break;
                case "D":
                    Console.Write("Enter new X coord>> ");
                    newX = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new Y coord>> ");
                    newY = Convert.ToInt32(Console.ReadLine());
                    temp = new Point(newX, newY, "D");
                    this[3] = temp;
                    break;
                default:
                    Console.WriteLine("0_o");
                    break;
            }

        
        }

        public double GetArea()
        {
            // нашел на просторах интернетах формулу, буду ее тут реализовывать 
            // очень тяжелый алгоритм, но зато простой в реализации
            // для начала нам нужно узнать длины всех сторон трапеции 
            // после взятия всех сторон реализуем 
            double t, y, u, i, o;
            if (this.a - this.b == 0)
            {
                return ((this.a + this.b) / 2) * (this.c * this.c);
            }
            else
            {
                Console.WriteLine(this.a);
                Console.WriteLine(this.b);
                Console.WriteLine(this.c);
                Console.WriteLine(this.d);

                t = (this.a + this.b) / 2;
                y = Math.Pow(this.a - this.b, 2);
                u = y + (this.c * this.c) - (this.d * this.d);
                i = 2 * (this.a - this.b);
                o = Math.Pow(u / i, 2);
                return Math.Round(t * Math.Sqrt((c * c) - o), 2);
            }

        }

        public override string ToString() {
            return "A = (" + this.p[0].X + " " + this.p[0].Y + ")\n" + "B = (" + this.p[1].X + " " + this.p[1].Y + ")\n" + "C = (" + this.p[2].X + " " + this.p[2].Y + ")\n" + "A = (" + this.p[3].X + " " + this.p[3].Y + ")\n";
        }

        


    }       
}
