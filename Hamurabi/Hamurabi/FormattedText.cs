using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationGame
{
    public class FText
    {
        private string text;

        public FText(string text)
        {
            this.text = text;
        }

        public void Display(State state)
        {
            string filledText = Fill(text, state);
            FText.WriteColor(filledText);
            Console.WriteLine();
        }

        private string Fill(string text, State state)
        {
            while (text.Contains("${"))
            {
                // TODO: implement me!
                //       -- 'text' still contains ${...} reference
                //       1. find the end of ${...}
                //       2. extract name from within {}
                //       3. replace ${...} with value from 'state' under variable name extracted in step 2   

                int startPos = text.IndexOf("${");
                int endPos = text.IndexOf("}");
                string variable = text.Substring(startPos + 2, endPos - startPos - 2);
                string value = state.GetInt(variable).ToString();
                text = text.Replace("${" + variable + "}", value);
            }
            return text;
        }

        public static ConsoleColor GetColor(string consoleColorEnumNameCaseSensitive)
        {
            ConsoleColor? result = null;
            try
            {
                result = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), consoleColorEnumNameCaseSensitive);
            }
            catch (Exception e)
            {
            }
            if (result != null) return (ConsoleColor)result;
            return ConsoleColor.Gray;
        }

        public static void WriteColor(string msg)
        {

            for (int i = 0; i < msg.Length;)
            {
                if (msg[i] == '<' && i + 1 < msg.Length)
                {
                    int next = msg.IndexOf(">", i + 1);
                    if (next >= 0 && msg[next] == '>')
                    {
                        if (next == i + 1)
                        {
                            Console.ForegroundColor = GetColor("");
                        }
                        else
                        {
                            string color = msg.Substring(i + 1, next - i - 1);
                            color = color.Trim();
                            Console.ForegroundColor = GetColor(color);
                        }
                        i = next + 1;
                    }
                    else
                    {
                        Console.Write(msg[i]);
                        ++i;
                    }
                }
                else
                {
                    Console.Write(msg[i]);
                    ++i;
                }
            }

        }           

    }
}
