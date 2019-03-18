using System;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 40);
            Console.CursorVisible = false;
            for (int p = 0; p <= 40; p++)
            { 
                Console.SetCursorPosition(0, p);
                Console.Write(p);
            }

            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            Random randColor = new Random();
            Rain[] theRain = new Rain[25];
            for (int i=0; i<theRain.Length;i++)
            {
                theRain[i] = new Rain(colors[randColor.Next(2,15)]);
            }
            do{
                for (int r = 0; r < theRain.Length; r++)
                {
                    theRain[r].RainMoves();
                    Thread.Sleep(1);
                }
            }while (true) ;


        }
    }
    public class Rain
    {
        //public int RainDrop;
        public int x;
        public int y;
        //public int yPrev;
        public int yStart;
        Random Rando;
        ConsoleColor TheColor;
        

        public Rain()
        {
            Rando = new Random();
            yStart = Rando.Next(1, 35);
            y = yStart;
            x = Rando.Next(3, 120);
            TheColor = Console.ForegroundColor;
        }
        public Rain(ConsoleColor aColor)
        {
            Rando = new Random();
            yStart = Rando.Next(1, 35);
            y = yStart;
            x = Rando.Next(3, 120);
            TheColor = aColor;
        }
        public void RainMoves()
        {
            //yPrev = y;
            Console.ForegroundColor = TheColor;
            y++;
            if ((y - yStart)>5)
            {
                Console.SetCursorPosition(x, yStart);
                Console.Write(" ");
                //yStart = Rando.Next(1, 35);
                yStart++;
                //x = Rando.Next(1, 120);
            }

            if (y >= 39)
            {
                
                y = 40;
                if(!(y-yStart > 5))
                    yStart++;
                Console.SetCursorPosition(x, yStart);
                Console.Write(" ");
                //yStart = Rando.Next(1, 35);
                //yStart++;

            }
            if (yStart > 39)
            {

                yStart = Rando.Next(1, 30);
                y = yStart;
                x = Rando.Next(3, 120);
                //yStart--;
            }
            else
            {
                Console.SetCursorPosition(x, y);
                Console.Write("|");
            }
        }


    }
}
