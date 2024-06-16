//Christine Liu  X00193365  OOSDEV2-Repeat

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSDEV2
{
    public class TestPoll
    {

        public static void Main()
        {
            //value control test , error handing for title 
            try
            {
                new MultipleChoicePoll("More than 30 character loooooooooooooooooong", DateOnly.Parse("30-06-2024"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Title length exception caught as expected");
            }


            //more proper test
            MultipleChoicePoll Poll = new MultipleChoicePoll("Favourite Cuisine Poll", DateOnly.Parse("15-07-2024"));
            Poll.AddOption(new Option("Chinese"));
            Poll.AddOption(new Option("Mexican"));
            Poll.AddOption(new Option("French"));
            Console.WriteLine("number of options: " + Poll.NumberOfOptions);
            Console.WriteLine("initial situation");
            Console.WriteLine(Poll.ToString());

            Poll.VoteFor(0, 10);
            Poll.VoteFor(2, 5);
            Poll.VoteFor(1, 7);

            try
            {
                Poll.VoteFor(4, 10);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("index out of range exception caught as expected");
            }
            Poll.VoteFor(0, 2);

            Console.WriteLine("result");
            Console.WriteLine(Poll.ToString());
        }

    }

}
