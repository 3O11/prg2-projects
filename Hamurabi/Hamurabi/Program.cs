using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = Create();
            game.Play();
        }

        private static Game Create()
        {
            Game game = new Game();

            State initial = new State(
                new Tuple<string, object>[]
                {
                    new Tuple<string, object>("D1", 0),
                    new Tuple<string, object>("P1", 0.0),
                    new Tuple<string, object>("Z", 0),
                    new Tuple<string, object>("P", 95),
                    new Tuple<string, object>("S", 2800),
                    new Tuple<string, object>("H", 3000),
                    new Tuple<string, object>("E", 200),
                    new Tuple<string, object>("Y", 3),
                    new Tuple<string, object>("A", (int)(3000 / 3.0)),
                    new Tuple<string, object>("I", 5),
                    new Tuple<string, object>("Q", 1),
                    new Tuple<string, object>("D", 0),
                }
            );
            game.SetInitial(initial);

            Beat start = new Beat(
                new FText("<Yellow>HAMURABI\n<Gray>CREATIVE COMPUTING  MORRISTOWN, NEW JERSEY\nREWRITTEN IN C# FOR PROGRAMMING II COURSE AT MATFYZ, PRAGUE\n\n"
                        + "<White>TRY YOUR HAND AT GOVERNING ANCIENT SUMERIA\n"
                        + "FOR A <Red>TEN-YEAR <White>TERM OF OFFICE."
                )
            );
            game.SetStart(start);

            Beat report1 = new Beat(
                new FText("\n<yellow>HAMURABI:<White>  I BEG TO REPORT TO YOU,"),
                new Effect(
                    "Z",
                    new Formula( (state, rnd) => ( state.GetInt("Z") + 1 ) )
                )                
            );
            Beat report2 = new Beat(
                new FText("IN YEAR <Red>${Z}<White>, <Yellow>${D}<White> PEOPLE STARVED, <Yellow>${I}<White> CAME TO THE CITY, "),
                new Effect(
                    "P",
                    new Formula( (state, rnd) => ( state.GetInt("P") + state.GetInt("I") ) )
                )
            );

            game.Add(new Transition(start, report1));
            game.Add(new Transition(report1, report2));

            Beat reportPlague = new Beat(
                new FText("<Red>A HORRIBLE PLAGUE STRUCK! HALF THE PEOPLE DIED."),
                new Effect(
                    "P",
                    new Formula( (state, rnd) => ( state.GetInt("P") / 2 ) )
                )
            );
            game.Add(new Transition(report2, reportPlague, new Formula( (state, rnd) => (state.GetInt("Q") < 1) )));

            Beat report3 = new Beat(
                new FText("<White>POPULATION IS NOW <Yellow>${P}<White>\n"
                         +"THE CITY NOW OWNS <Yellow>${A}<White> ACRES.\n"
                         +"YOU HARVESTED <Yellow>${Y}<White> BUSHELS PER ACRE.\n"
                         +"THE RATS ATE <Yellow>${E}<White> BUSHELS.\n"
                         +"YOU NOW HAVE <Yellow>${S}<White> BUSHELS IN STORE."
                )
            );
            game.Add(new Transition(reportPlague, report3));
            game.Add(new Transition(report2, report3));

            //IF Z=11 THEN 860

            Beat year1 = new Beat(                
                new Effect(
                    "C",
                    new Formula( (state, rnd) => ( (int)(10 * rnd.NextDouble()) ) )
                ),
                new Effect(
                    "Y",
                    new Formula( (state, rnd) => ( (int)(17 + state.GetInt("C")) ) )
                )
            );            

            Beat year2Buy = new Beat(
                new FText("<White>LAND IS TRADING AT <Yellow>${Y}<White> BUSHELS PER ACRE."),
                new Input(
                    new FText("<Cyan>HOW MANY ACRES DO YOU WISH TO BUY?<White>"),
                    new Formula((state, rnd) => (0)), // MIN
                    new Formula((state, rnd) => ( state.GetInt("S") / state.GetInt("Y") )) // MAX
                ),
                new Effect(
                    "A",
                    new Formula( (state, rnd) => ( state.GetInt("A") + state.GetInt("input") ) )
                ),
                new Effect(
                    "S",
                    new Formula( (state, rnd) => ( state.GetInt("S") - state.GetInt("Y") * state.GetInt("input")) )
                ),
                new Effect(
                    "C",
                    new Formula( (state, rnd) => ( 0 ) )
                )
            );
            game.Add(new Transition(year1, year2Buy));

            Beat year2Sell = new Beat(
                new Input(
                    new FText("<Cyan>HOW MANY ACRES DO YOU WISH TO SELL?<White>"),
                    new Formula((state, rnd) => (0)), // MIN
                    new Formula((state, rnd) => (state.GetInt("A") )) // MAX
                ),
                new Effect(
                    "A",
                    new Formula( (state, rnd) => ( state.GetInt("A") - state.GetInt("input") ) )
                ),
                new Effect(
                    "S",
                    new Formula( (state, rnd) => ( state.GetInt("S") + state.GetInt("Y") * state.GetInt("input")) )
                ),
                new Effect(
                    "C",
                    new Formula( (state, rnd) => ( 0 ) )
                )
            );
            game.Add(new Transition(year2Buy, year2Sell, new Formula((state, rnd) => (state.GetInt("input") == 0))));

            Beat year3Feed = new Beat(
                new Input(
                    new FText("<Cyan>HOW MANY BUSHELS DO YOU WISH TO FEED YOUR PEOPLE?<White>"),
                    "Q",
                    new Formula( (state, rnd) => ( 0 ) ), // MIN
                    new Formula( (state, rnd) => ( state.GetInt("S") ))  // MAX
                ),
                new Effect(
                    "S",
                    new Formula( (state, rnd) => ( state.GetInt("S") - state.GetInt("Q") ))
                ),
                new Effect(
                    "C",
                    new Formula( (state, rnd) => ( 1 ) )
                )
            );
            game.Add(new Transition(year2Buy, year3Feed));
            game.Add(new Transition(year2Sell, year3Feed));

            Beat year4Plant = new Beat(
                new Input(
                    new FText("<Cyan>HOW MANY ACRES DO YOU WISH TO PLANT WITH SEED?<White>"),
                    new Formula((state, rnd) => (0)), // MIN
                    new Formula((state, rnd) => ( Math.Min(Math.Min(state.GetInt("A"), state.GetInt("S")*2), state.GetInt("P")*10) )) // MAX
                ),
                new Effect(
                    "S",
                    new Formula( (state, rnd) => ( state.GetInt("S") - state.GetInt("input") / 2 ) )
                ),
                new Effect(
                    "C",
                    new Formula( (state, rnd) => ( (int)(rnd.NextDouble() * 5 + 1) ))
                ),
                // REM *** A BOUNTIFUL HARVEST!
                new Effect(
                    "Y",
                    new Formula( (state, rnd) => ( state.GetInt("C") ) )
                ),
                new Effect(
                    "H",
                    new Formula( (state, rnd) => ( state.GetInt("input") * state.GetInt("Y") ) )
                ),
                new Effect(
                    "E",
                    new Formula( (state, rnd) => ( 0 ) )
                ),
                // REM *** RATS ARE RUNNING WILD?
                new Effect(
                    "C",
                    new Formula( (state, rnd) => ( (int)(rnd.NextDouble() * 5 + 1) ))
                ),
                new Effect(
                    "E",
                    new Formula( (state, rnd) => ( state.GetInt("S") / state.GetInt("C") ) ),
                    new Formula( (state, rnd) => ( state.GetInt("C") % 2 == 0 ) )
                ),
                new Effect(
                    "S",
                    new Formula( (state, rnd) => ( state.GetInt("S") - state.GetInt("E") + state.GetInt("H") ) )
                ),
                // REM *** LET'S HAVE SOME BABIES
                new Effect(
                    "C",
                    new Formula( (state, rnd) => ( (int)(rnd.NextDouble() * 5 + 1) ))
                ),
                new Effect(
                    "I",
                    new Formula( (state, rnd) => ( (int)(state.GetInt("C")*(20*state.GetInt("A")+state.GetInt("S"))/state.GetInt("P")/100+1) ))
                ),
                // REM *** HOW MANY PEOPLE HAD FULL TUMMIES?
                new Effect(
                    "C",
                    new Formula( (state, rnd) => ( state.GetInt("Q") / 20 ))
                ),
                new Effect(
                    "D",
                    new Formula( (state, rnd) => ( 0 ))
                ),
                // REM *** HORROS, A 15% CHANCE OF PLAGUE
                new Effect(
                    "Q",
                    new Formula( (state, rnd) => ( (int)(1.85 - rnd.NextDouble())) )
                )
            );
            game.Add(new Transition(year3Feed, year4Plant));

            Beat year5Starve = new Beat(
                new Effect(
                    "D",
                    new Formula( (state, rnd) => ( state.GetInt("P") - state.GetInt("C") ))
                ),
                //P1=((Z-1)*P1+D*100/P)/Z
                new Effect(
                    "P1",
                    new Formula( (state, rnd) => ( ((state.GetInt("Z") - 1) * state.GetDouble("P1") + state.GetInt("D") * 100 / (double)state.GetInt("P")) - 1) / (double)state.GetInt("Z") ),
                    new Formula( (state, rnd) => ( state.GetInt("D") < 0.45 * state.GetInt("P") ) )                    
                ),
                new Effect(
                    "P",
                    new Formula( (state, rnd) => ( state.GetInt("C") )),
                    new Formula( (state, rnd) => ( state.GetInt("D") < 0.45 * state.GetInt("P") ) )
                ),
                new Effect(
                    "D1",
                    new Formula( (state, rnd) => ( state.GetInt("D1") + state.GetInt("D") )),
                    new Formula( (state, rnd) => ( state.GetInt("D") < 0.45 * state.GetInt("P") ) )
                )
            );
            game.Add(new Transition(year4Plant, year5Starve, new Formula( (state, rnd) => (state.GetInt("P") > state.GetInt("C")) )));
            game.Add(new Transition(year4Plant, report1));

            // IF D>.45*P THEN 560
            Beat endImpeach = new Beat(
                new FText("\n<Red>YOU STARVED ${D} PEOPLE IN ONE YEAR!!!\n"
                         +"<White>DUE TO THIS EXTREME MISMANAGEMENT YOU HAVE NOT ONLY\n"
                         + "BEEN <Red>IMPEACHED<White> AND <Red>THROWN OUT OF OFFICE<White> BUT YOU HAVE\n"
                         + "ALSO BEEN <Red>DECLARED NATIONAL FINK<White>!!!!\n")                
            );
            game.Add(new Transition(year5Starve, endImpeach, new Formula((state, rnd) => ( state.GetInt("D") > 0.45 * state.GetInt("P") )) ));
            game.Add(new Transition(year5Starve, report1));

            Beat endResult1 = new Beat(
                new Effect(
                    "L",
                    new Formula( (state, rnd) => ( state.GetInt("A") / state.GetInt("P") ))
                )                
            );

            //IF Z = 11 THEN 860
            game.Add(new Transition(report3, endResult1, new Formula((state, rnd) => (state.GetInt("Z") > 10))));
            game.Add(new Transition(report3, year1));
            
            Beat endResult2 = new Beat(
                new FText("\n<White>IN YOUR 10-YEAR TERM OF OFFICE, <Red>${P1}<White> PERCENT OF THE\n"
                         +"POPULATION STARVED PER YEAR ON THE AVERAGE,\n"
                         +"I.E. A TOTAL OF <Red>${D1}<White> PEOPLE DIED!!\n"
                         +"YOU STARTED WITH <Yellow>10<White> ACRES PER PERSON\n"
                         +"AND ENDED WITH <Yellow>${L}<White> ACRES PER PERSON"
                )
            );
            game.Add(new Transition(endResult1, endResult2));

            // IF P1>33 THEN 565 ... IMPEACH
            // IF L<7 THEN 565 ... IMPEACH
            game.Add(new Transition(endResult2, endImpeach, new Formula( (state, rnd) => ( state.GetDouble("P1") > 33 || state.GetInt("L") < 7 ))));

            // IF P1>10 THEN 940 ... NERO
            // IF L<9 THEN 940 ... NERO
            Beat endResultNero = new Beat(
                new FText("\n<Red>YOUR HEAVY-HANDED PERFORMANCE SMACKS OF NERO AND IVAN IV.\n"
                         + "<White>THE PEOPLE (REMIANING) FIND YOU AN UNPLEASANT RULER, AND,\n"
                         + "FRANKLY, HATE YOUR GUTS!!"
                )
            );
            game.Add(new Transition(endResult2, endResultNero, new Formula((state, rnd) => (state.GetDouble("P1") > 10 || state.GetInt("L") < 9))));

            // IF P1>3 THEN 960 ... BE BETTER
            // IF L<10 THEN 960 ... BE BETTER
            Beat endResultBeBetter1 = new Beat(
                new FText("\n<yellow>YOUR PERFORMANCE COULD HAVE BEEN SOMEWHAT BETTER, BUT\n"
                         + "REALLY WASN'T TOO BAD AT ALL."
                ),
                new Effect[]
                {
                    new Effect(
                        "temp",
                        new Formula( (state, rnd) => ( (int)(state.GetInt("P") * 0.8 * rnd.NextDouble()) ))
                    )
                }
            );
            game.Add(new Transition(endResult2, endResultBeBetter1, new Formula((state, rnd) => (state.GetDouble("P1") > 3 || state.GetInt("L") < 10))));

            Beat endResultBeBetter2 = new Beat(
                new FText("\n<Red>${temp} PEOPLE WOULD DEARLY LIKE TO SEE YOU ASSASSINATED\n"
                        + "<Yellow>BUT WE ALL HAVE OUR TRIVIAL PROBLEMS."
                )
            );
            game.Add(new Transition(endResultBeBetter1, endResultBeBetter2));

            // OTHERWISE ... FANTASTIC
            Beat endResultFantastic = new Beat(
                new FText("\n<White>A FANTASTIC PERFORMANCE!!!  CHARLEMANGE, DISRAELI, AND\n"
                         + "JEFFERSON COMBINED COULD NOT HAVE DONE BETTER!"
                )
            );
            game.Add(new Transition(endResult2, endResultFantastic));

            // FINAL
            Beat endFinal = new Beat(
                new FText("\n<White>SO LONG FOR NOW."
                )
            );
            game.Add(new Transition(endImpeach, endFinal));
            game.Add(new Transition(endResultNero, endFinal));
            game.Add(new Transition(endResultBeBetter2, endFinal));
            game.Add(new Transition(endResultFantastic, endFinal));

            return game;
        }
    }
}
