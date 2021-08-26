using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameBook.Graphs;

namespace GameBook
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("LoneWolf-FlightFromTheDark");

            Book book = LoadBook("LoneWolf-FlightFromTheDark.txt");
            //PlayBook(book, 1);            

            Playout playout = ExtractAndSelectPlayout(book, 1); // <== TO BE IMPLEMENTED!
            if (playout != null && playout.pages != null && playout.pages.Count > 0) PlayPlayout(playout);            
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Failed to find a playout...");
                Console.ReadLine();
            }
        }   

        // NOTE THAT YOU HAVE TO KEEP 'static' KEYWORD IN ORDER TO BE ABLE TO REFERENCE IT
        // FROM THE 'main' METHOD
        static Book LoadBook(string pathToBookFile)
        {
            // Uncomment to load all strings...
            // ... locate the file LoneWolf-FlightFromTheDark.txt in your project (through Explorer) 
            //     so you know where it comes from!
            string[] lines = System.IO.File.ReadAllLines(pathToBookFile);

            // Uncomment to instantiate new book
            Book book = new Book();

            // Uncomment to initialize 'pages' object field with dynamic array
            book.pages = new List<Page>();

            // Uncomment to add new page as the last entry of "book.pages"
            Page page = new Page();
            page.options = new List<Option>();

            // Now its time to read the book the lines!
            foreach (string line in lines)
            {
                if (int.TryParse(line.Trim(), out int pageNum))
                {
                    // we have a new page!
                    while (book.pages.Count < page.pageNum) book.pages.Add(null);
                    book.pages.Add(page);
                    page = new Page();
                    page.options = new List<Option>();
                    page.pageNum = pageNum;
                }
                else
                {
                    int turnToIndex = 0;
                    turnToIndex = line.ToLower().IndexOf("turn to");
                    if (turnToIndex < 0) turnToIndex = line.ToLower().IndexOf("turning to");
                    if (turnToIndex < 0) turnToIndex = line.ToLower().IndexOf("go to");
                    int turnToPageNum = -1;
                    if (turnToIndex >= 0) turnToPageNum = FindNumber(line, turnToIndex);
                    if (turnToPageNum > 0)
                    {
                        // we hit some option
                        Option option = new Option();
                        option.text = line;

                        option.pageNum = turnToPageNum;
                        page.options.Add(option);
                    }
                    else
                    {
                        // page text
                        page.text += "\n" + line;
                    }
                }
            }
            while (book.pages.Count < page.pageNum) book.pages.Add(null);
            book.pages.Add(page);

            return book;
        }

        static int FindNumber(string line, int startIndex)
        {
            while (startIndex < line.Length)
            {
                if (line[startIndex] >= '0' && line[startIndex] <= '9') break;
                ++startIndex;
            }

            if (startIndex >= line.Length)
            {
                // index not found
                return -1;
            }

            string num = "";
            while (startIndex < line.Length && line[startIndex] >= '0' && line[startIndex] <= '9')
            {
                num += line[startIndex];
                ++startIndex;
            }

            return int.Parse(num);
        }

        static void PlayBook(Book book, int pageIndex)
        {
            int currPageIndex = pageIndex; // our current page
            while (true)
            {
                // 1) get current page
                Page currPage = book.pages[currPageIndex];

                // 2) output page
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Page " + currPage.pageNum);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(currPage.text);

                // 3) present options
                //    ++ if there are no options, we've hit the end of the story => break the cycle
                Console.ForegroundColor = ConsoleColor.Gray;
                int num = 1;
                foreach (Option option in currPage.options)
                {
                    Console.WriteLine(num + " >>> " + option.text);
                    num += 1;
                }

                if (currPage.options.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("---/ THE END /---");
                    Console.ReadLine();
                    return;
                }
               
                // 4) read user's input and change "currPage" according to the option                
                int chosenOption = 0;
                while (chosenOption < 1 || chosenOption > currPage.options.Count)
                {
                    Console.WriteLine();
                    Console.Write("Choose option: ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out chosenOption) || chosenOption < 1 || chosenOption > currPage.options.Count)
                    {
                        Console.WriteLine("Invalid input, enter number between [1;" + currPage.options.Count + "]");
                    }
                }

                // 5) turn page index
                currPageIndex = currPage.options[chosenOption - 1].pageNum;

                // 6) clear console
                Console.Clear();
            }
        }

        static Playout ExtractAndSelectPlayout(Book book, int firstPage)
        {
            // 1. PERFORM BFS and DFS via VISITOR PATTERN
            Graph bookGraph = ConstructGraph(book);
            PathStoringVisitor visitor = new PathStoringVisitor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Before I find the paths to the endings for you,\nplease select what kind of path you want: ");
            Console.WriteLine("    1) Shortest paths(BFS)");
            Console.WriteLine("    2) Generic paths(DFS)");
            Console.WriteLine("    3) Randomized paths(Randomized DFS)");
            Console.Write("\nPick the number of the option you would like to select: ");
            bool correct = false;
            while (!correct) {
                int input;
                string rawInput = Console.ReadLine();
                while (!int.TryParse(rawInput, out input)) {
                    Console.Write("Invalid input, please try again: ");
                    rawInput = Console.ReadLine();
                }
                switch (input) {
                    case 1:
                        Graphs.Algo.BFS.Crawl(bookGraph.Nodes[firstPage], visitor);
                        correct = true;
                        break;
                    case 2:
                        Graphs.Algo.DFS.Crawl(bookGraph.Nodes[firstPage], visitor);
                        correct = true;
                        break;
                    case 3:
                        Graphs.Algo.RandomDFS.Crawl(bookGraph.Nodes[firstPage], visitor);
                        correct = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please select again.");
                        break;
                }
            }

            // 2. PRESENT PLAYOUTS AND LET PLAYER CHOOSE
            List<int> endingPageNums = new List<int>();
            foreach (Node node in visitor.terminalNodes) endingPageNums.Add(node.Value);
            PresentOptions(book, endingPageNums);

            Console.Write("\nSelect your desired option: ");
            int selectedEnding;
            int.TryParse(Console.ReadLine(), out selectedEnding);
            selectedEnding--;
            List<Node> pathToEnding = visitor.GetPath(visitor.terminalNodes[selectedEnding]);

            // 3. RETURN THE SELECTED PLAYOUT
            return ConstructPlayout(book, pathToEnding);
        }        

        static void PlayPlayout(Playout playout)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Playout length: " + playout.pages.Count);
            Console.WriteLine("Final page num: " + playout.pages[playout.pages.Count - 1].pageNum);
            Console.WriteLine();

            for (int i = 0; i < playout.pages.Count; ++i)
            {
                Page currPage = playout.pages[i];
                Page nextPage = (i+1 < playout.pages.Count ? playout.pages[i + 1] : null);

                // 1) RENDER PAGE TEXT
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Page " + currPage.pageNum);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(currPage.text);

                // 2) PRESENT CHOSEN OPTION
                if (nextPage != null)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    foreach (Option option in currPage.options)
                    {
                        if (option.pageNum == nextPage.pageNum)
                        {
                            Console.WriteLine(">>> " + option.text);
                            break;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("--- press enter to continue ---");
                    Console.ReadLine();

                    Console.Clear();
                }
            }

            Console.WriteLine();
            Console.WriteLine("---/ THE END /---");
            Console.ReadLine();
        }

        static Playout ConstructPlayout(Book book, List<Node> pathToEnding) {
            Playout result = new Playout();
            
            foreach (Node pageNode in pathToEnding) {
                result.pages.Add(book.pages[pageNode.Value]);
            }

            return result;
        }

        static void PresentOptions(Book book, List<int> endingPageNums) {
            Console.WriteLine("------------------------------------------");
            for (int i = 0; i < endingPageNums.Count; ++i) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Ending no." + (i+1) + ":");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(book.pages[endingPageNums[i]].text);
                Console.WriteLine("------------------------------------------\n");
            }
            Console.WriteLine("-----/    THESE ARE YOUR OPTIONS    /-----");
        }

        static Graph ConstructGraph(Book book) {
            Graph graph = new Graph();

            // In the first pass, all pages are created
            foreach (Page page in book.pages) {
                graph.Nodes.Add(new Node());
                graph.Nodes[page.pageNum].Value = graph.Nodes.Count - 1;
            }
            // In the second pass, all links are added
            foreach (Page page in book.pages) {
                foreach (Option option in page.options) {
                    graph.Nodes[page.pageNum].Links.Add(graph.Nodes[option.pageNum]);
                }
            }

            return graph;
        }
    }
}
