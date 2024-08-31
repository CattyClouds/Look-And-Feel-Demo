using System.Collections.Generic;
using System.Linq;

namespace Look_and_Say_Demo
{
    /// <summary>
    /// Look and Feel Demo
    /// Git-Amend Weekly Kata Challenge from his community Discord. This is my implementation.
    /// </summary>
    internal class Program
    {
        private static int termCount = 0;
        private static List<int> previousLine = new List<int>();
        private static List<int> lineToSay = new List<int>();
        public static int TermCount { get => termCount; set => termCount = value; }
        public static List<int> PreviousLine { get => previousLine; set => previousLine = value; }
        public static List<int> LineToSay { get => lineToSay; set => lineToSay = value; }

        static void Main(string[] args)
        {
            //Primary loop for n amount of iterations to look and say
            for (int i = 0; i < 15; i++)
            {
                System.Threading.Thread.Sleep(500); //Give a little breathing room to read for larger iteration counts

                //Console.WriteLine("Run: " + (i+1));

                //Handle the initial run
                if (i == 0)
                {
                    PreviousLine.Add(1); //Seed value
                    LineToSay = PreviousLine.ToList<int>();
                    SayTheLine();
                }
                else
                {
                    Look();
                    SayTheLine();
                }

                //Reset for next iteration
                PreviousLine.Clear();
                PreviousLine = LineToSay.ToList<int>();
                LineToSay.Clear();
            }
            Console.WriteLine($"{Environment.NewLine}========================================{Environment.NewLine}Done");
            Console.ReadKey();
        }

        static void Look()
        {
            int previousNum = 0;

            //Go through each number from previous iteration
            for (int j = 0; j < PreviousLine.Count; j++)
            {
                //Set the previous term
                if (!(PreviousLine.Count > 1 && j > 0))
                {
                    previousNum = PreviousLine[j];
                }

                //Check if current term matches previous term
                if ((PreviousLine[j] != previousNum))
                {
                    LineToSay.Add(TermCount); //Add the termCount
                    LineToSay.Add(previousNum); //Add the previous term
                    TermCount = 1; //Set this to 1 because we're now on a new term and this'll be the first time we see it
                    previousNum = PreviousLine[j];
                }
                else
                {
                    TermCount++;
                }
            }

            LineToSay.Add(TermCount); //Add the termCount
            LineToSay.Add(previousNum); //Add the previous term
            TermCount = 0; //Reset for next iteration
        }

        static void SayTheLine()
        {
            for (int x = 0; x < LineToSay.Count; x++)
            {
                Console.Write(LineToSay[x].ToString());
            }
            Console.Write(Environment.NewLine);
        }
    }
}
