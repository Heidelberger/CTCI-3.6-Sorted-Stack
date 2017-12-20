using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI_3._6_Sorted_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeaderMsg(3, 6, "Sorted Stack");

            SortedStack myStack = new SortedStack();

            Console.WriteLine("Pushing 100 random numbers onto the stack:");

            int x = 0;
            Random rnd = new Random();
            for (int i = 0; i < 100; ++i)
            {
                x = rnd.Next(10, 99);
                Console.Write(x + ", ");
                myStack.Push(x);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Popping all numbers from the stack:");

            while(myStack.Count > 0)
                Console.Write(myStack.Pop() + ", ");

            Console.ReadLine();
        }

        private static void PrintHeaderMsg(int chapter, int problem, string title)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter " + chapter + ", Problem " + chapter + "." + problem + ": " + title);
            Console.WriteLine();
        }
    }

    class SortedStack : Stack<int>
    {
        /// <summary>
        /// 
        /// 1. remove values from stack until the passed value is smaller than peek() 
        /// 2. push the passed value onto the stack
        /// 3. push all removed values back onto the stack
        /// 
        /// NOTE: this Push() function hides base function (cannot override)
        /// 
        /// Complexity:     Runs in O(N^2) time
        ///                 Worst-case scenario, every element in the stack must
        ///                 be popped and pushed (then popped and pushed again)
        ///                 for every element pushed onto the stack.
        ///                 
        ///                 Requires O(N) memory
        ///                 Every element is stored in a stack. Although elements
        ///                 are moved between the stacks, only 1 copy of each 
        ///                 element is stored at a time.
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Push(int item)
        {
            Stack<int> temp = new Stack<int>();

            while ((base.Count > 0) && (item > Peek()))            
                temp.Push(base.Pop());           

            base.Push(item);

            while (temp.Count > 0)
                base.Push(temp.Pop());
        }
    }
}
