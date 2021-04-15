using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GameBook
{
    class Program
    {

        static void Main(string[] args)
        {
            Book book = LoadBook();
            PlayBook(book);
        }

        // NOTE THAT YOU HAVE TO KEEP 'static' KEYWORD IN ORDER TO BE ABLE TO REFERENCE IT
        // FROM THE 'main' METHOD
        static Book LoadBook()
        {
            // Uncomment to load all strings...
            // ... locate the file LoneWolf-FlightFromTheDark.txt in your project (through Explorer) 
            //     so you know where it comes from!
            string[] lines = System.IO.File.ReadAllLines("LoneWolf-FlightFromTheDark.txt");

            // Uncomment to instantiate new book
            Book book = new Book();

            // Uncomment to initialize 'pages' object field with dynamic array
            book.pages = new List<Page>();

            // Uncomment to add new page as the last entry of "book.pages"
            Page page = new Page();
            page.options = new List<Option>();


            // Now its time to read the book the lines!
            foreach (string line in lines) {
                if (int.TryParse(line.Trim(), out int pageNum)) {
                    // we have a new page!
                    book.pages.Add(page);
                    page = new Page();
                    page.options = new List<Option>();
                    page.pageNum = pageNum;
                }
                else // Here we check if there is any occurence of "to" with a number after it to recognise all possible options we have(such as "go to <num>" or "by turning to <num>")
                if (Regex.Match(line.ToLower(), @" to \d+").Success) {
                    // Here we butcher the option line into the actual page number we need to go if it's picked
                    int.TryParse(Regex.Match(line.ToLower(), @" to \d+").Value.Substring(4), out int optionPageNum);

                    // If the parsing went without a hitch, we can create and add the option
                    page.options.Add(new Option(line, optionPageNum));
                }
                else {
                    // page text
                    page.text += "\n" + line;
                }
            }
            book.pages.Add(page);

            return book;
        }

        static void PlayBook(Book book)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("LoneWolf - FlightFromTheDark");

            int currPage = 1; // our current page
            while (true) {
                // 0) Clear previous output and print current page number
                if (currPage != 1) Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Page " + currPage);
                Console.ForegroundColor = ConsoleColor.White;

                // 1) output page
                Console.WriteLine(book.pages[currPage].text);

                // 2) present options
                //    ++ if there are no options, we've hit the end of the story => break the cycle
                //break; // TODO: delete this break, or better, give it a condition
                int optionCount = book.pages[currPage].options.Count;
                if (optionCount == 0) break;
                for (int i = 0; i < optionCount; i++) {
                    Console.WriteLine((i + 1) + " >>> " + book.pages[currPage].options[i].text);
                }

                // 3) read user's input and change "currPage" according to the option
                Console.WriteLine("\nPick option:");
                // Check if the user put in valid input
                bool valid = int.TryParse(Console.ReadLine(), out int optionNum);
                if (valid && (optionNum < 1 || optionNum > book.pages[currPage].options.Count)) valid = false; 
                while(!valid) {
                    Console.WriteLine(String.Format("Invalid input, pick number between [{0},{1}].", 1, book.pages[currPage].options.Count));
                    valid = int.TryParse(Console.ReadLine(), out optionNum);
                    if (valid && (optionNum < 1 || optionNum > (book.pages[currPage].options.Count))) valid = false;
                }
                // "Turn" to the picked page
                currPage = book.pages[currPage].options[optionNum - 1].pageNum;
            }

            Console.WriteLine("--/ The End /--");
            Console.ReadLine();
        }
    }
}
