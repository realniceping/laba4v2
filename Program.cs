namespace laba4v2
{

    
    
    class Program
    {
        static void Main(string[] args)
        {

            Attention();
            
            Trapezoid trapezoid1 = new Trapezoid();

            //some system variables
            int menu = 0;   
            //some system variables

            do
            {
                Menu();
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        //Если в сетере прописана механика установки новой точки "безопасно" следовательно можно попробовать реализовать это действие в коде
                        ChangeOnePoint(trapezoid1);
                        break;
                    case 2:
                        Console.WriteLine(trapezoid1.ToString());
                        break;
                    case 3:
                        Console.WriteLine("area of your trapezoid = " + Convert.ToString(trapezoid1.GetArea()));
                        break;
                    case 0:
                        Console.WriteLine("good bye!");
                        break;

                }
            } while (menu != 0);

        }

        public static void ChangeOnePoint(Trapezoid trapezoid1) {

            //some system variables 
            double newX, newY;
            int submenu;
            Point temp;
            //some system variables 

            Console.Write("what point you want to change??(1 - 4)>> ");
            submenu = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new X coord>> ");
            newX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new Y coord>> ");
            newY = Convert.ToInt32(Console.ReadLine());
            temp = new Point(newX, newY, "A");
            trapezoid1[submenu - 1] = temp;

        }

        public static void Attention() {
            Console.WriteLine("Hello, this programm can built abstract trapezoid");
            Console.WriteLine("Before using this programm you shold know, that trapezoid should have two parallel line");
            Console.WriteLine("If some one of pare line dont be paralel, program notify you about it");
            Console.WriteLine("Declarate your trapezoid");
        }
        public static void Menu()
        {
            Console.WriteLine("What you want to do?");
            Console.WriteLine("1. change one point");
            Console.WriteLine("2. show info about trapezoid");
            Console.WriteLine("3. find trapezoid area");
            Console.WriteLine("0. exit");
            Console.Write(">> ");
        }

        


    }
}