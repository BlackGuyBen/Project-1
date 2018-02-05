using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Declarations
            string[] positions =
            {"Quaterback", "Running Back", "Wide-Recevier", "Defensive Lineman","Defensive-Back", "Tight Ends", "Line-Backers", "Offensive Tackles"};

            string[,] playerNames =
            {
             /*1*/   {"Mason Rudolph","Saquon Barkley","Courtland Sutton", "Maurice Hurst", "Joshua Jackson", "Mark Andrews", "Roquan Smith", "Orlando Brown"},
             /*2*/   {"Lamar Jackson","Derrius Guice", "James Washington", "Vita Vea", "Derwin James", "Dallas Goedert", "Tremaine Edmunds", "Kolton Miller"},
             /*3*/   {"Josh Rosen", "Bryce Love", "Marcell Ateman", "Taven Bryan", "Denzel Ward", "Jaylen Samuels", "Kendall Joseph", "Chukwuma Okorafor"},
             /*4*/   {"Sam Darnold", "Ronald Jones II", "Anthony Miller", "Da'Ron Payne", "Minkah Fitzpatrick", "Mike Gesicki", "Dorian O'Daniel", "Connor Williams"},
             /*5*/   {"Baker Mayfield","Damien Harris", "Calvin Ridley", "Harrison Phillips", "Isaiah Oliver","Troy Fumagalli","Malik Jefferson","Mike McGlinchey"}
            };

            string[,] colleges =
            {
             /*1*/  {"Oklahoma State", "Penn State", "Southern Methodist", "Michigan", "Iowa", "Oklahoma", "Georgia", "Oklahoma"},
             /*2*/  {"Louisville", "LSU", "Oklahoma State","Washington","Florida State","So. Dakota State","Virgina Tech","UCLA" },
             /*3*/  {"UCLA","Stanford","Oklahoma State","Florida","Ohio State","NC State","Clemson","Western Michigan" },
             /*4*/  {"Southern California","Southern California","Memphis","Alabama","Alabama","Penn State","Clemson","Texas" },
             /*5*/  {"Oklahoma","Alabama","Alabama","Stanford","Colorado","Wisconsin","Texas","Notre Dame" }
            };

            string[,] salary =
            {
             /*1*/  {"$26,400,100","$24,500,100","$23,400,000","$26,200,300","$24,000,000","$27,800,900","$22,900,300","$23,000,000" },
             /*2*/  {"$20,300,100","$19,890,200","$21,900,300","$22,000,000","$22,500,249","$21,000,800","$19,000,590","$20,000,000" },
             /*3*/  {"$17,420,300","$18,700,800","$19,300,230","$16,000,000","$20,000,100","$17,499,233","$18,000,222","$19,400,000" },
             /*4*/  {"$13,100,145","$15,000,000","$13,400,230","$18,000,000","$16,000,200","$27,900,200","$12,999,999","$16,200,700" },
             /*5*/  {"$10,300,000","$11,600,400","$10,000,000","$13,000,000","$11,899,999","$14,900,333","$10,000,100","$15,900,000" }
            };

            //Int version of the salary. May not even need to use this
            double[,] salaryNumbered =
            {
             /*1*/  {26400100,24500100,23400000,26200300,24000000,27800900,22900300,23000000 },
             /*2*/  {20300100,19890200,21900300,22000000,22500249,21000800,19000590,20000000 },
             /*3*/  {17420300,18700800,19300230,16000000,20000100,17499233,18000222,19400000 },
             /*4*/  {13100145,15000000,13400230,18000000,16000200,27900200,12999999,16200700 },
             /*5*/  {10300000,11600400,10000000,13000000,11899999,14900333,10000100,15900000 }
            };
            string name;
            int row, col;
            bool keepGoing = true;
            double total;
           
            List<String> coachList = new List<String>();
            List<Double> playerCost = new List<Double>();
            List<AutoDraft> roster = new List<AutoDraft>();
            ConsoleKeyInfo keyPress;

            //welcome message
            Welcome(out keyPress);
            while (keyPress.Key == ConsoleKey.Enter)
            {
                name = GetName();
                //userInput = getInput();
                Console.Clear();
                OutputList(ref playerNames);

                do
                {
                    GetData(out row, out col);
                    OutputInfo(ref row, ref col,ref playerNames, ref salaryNumbered);

                    //Add data to list
                    coachList.Add(playerNames[row, col]);
                    playerCost.Add(salaryNumbered[row, col]);
                    //playerNumberCost.Add(salaryNumbered[row, col]);
                    keepGoing = GetInnerPrimer();


                } while (keepGoing);

                //Going through the list to show choosen players
                foreach (var x in coachList)
                {
                    Console.WriteLine($"You have added the following players {x}");
                }

                Console.WriteLine("Total number of players: {0}", coachList.Count);
                total = playerCost.Sum();


                roster.Add(new AutoDraft(name, coachList.Count, new List<String>(coachList), total));
                coachList.Clear();
                GetPrimer(out keyPress);
              
            }//end of while loop

            Console.Clear();

            Console.WriteLine("Listed below are the players you've choosen");

            foreach (AutoDraft x in roster)
            {
                Console.WriteLine($"For {x.GetDraft} there are {x.GetcoachNumber} players and the total cost is {x.GetsalaryNumber.ToString("C")}");
                foreach (var i in x.GetListofPlayers)
                {
                    Console.WriteLine($"{i}");
                }
                Console.WriteLine("");
            }

        }//end of main
        public static void Welcome(out ConsoleKeyInfo keyPress)
        {
            Console.WriteLine("Welcome, this program...");
            Console.WriteLine("Let's get started, please press the enter key");
            keyPress = Console.ReadKey();
        }
        public static void GetPrimer(out ConsoleKeyInfo keyPress)
        {
            keyPress = Console.ReadKey();
        }

        public static bool GetInnerPrimer()
        {
            string sentinel;
            bool keepGoing;
            Console.WriteLine("If you would like to add another player, please enter Y. Otherwise enter N");
            sentinel = Console.ReadLine().ToUpper();

            if (sentinel == "Y")
            {
                keepGoing = true;
            }
            else
            {
                keepGoing = false;
            }
            return keepGoing;
            
        }
        public static string GetName()
        {
            //Declarations
            string playerName;
            Console.WriteLine();
            //there may be more to this 
            playerName = Console.ReadLine();

            return playerName;
        }

        public static void OutputList (ref string [,] playerNames)
        {
            for (var x = 0; x< playerNames.GetLength(0); x++)
            {
                Console.WriteLine($" playerName{x+1}:   ");
                for (var y = 0; y <playerNames.GetLength(1); y++)
                {
                    Console.WriteLine($"  {x+1}{y+1}) {playerNames[x,y]}");
                }
                Console.WriteLine("  \n");
            } //outer forloop

        } //end of outputNames

        public static void GetData (out int row, out int col)
        {
            string userInput;
            Console.WriteLine("Please enter a player you would like to draft");
            userInput = Console.ReadLine();
            row = Int32.Parse(userInput.Substring(0, 1)) - 1;
            col = Int32.Parse(userInput.Substring(1, 1)) - 1;

        }
        public static void OutputInfo (ref int row, ref int col, ref string [,] playerNames, ref double [,] playerSalary)
        {
            Console.WriteLine($"You have selected {playerNames[row,col]}. They will cost {playerSalary[row,col].ToString("c")}");
        }
    }

    class AutoDraft
    {

        public string Name { get; set; }
        public string GetDraft { get; set; } = "NFL Draft Choices";
        public double GetcoachNumber { get; set; }
        public List<string> GetListofPlayers { get; set; }
        public double GetsalaryNumber { get; set; }

        public AutoDraft()
        {

        }

        public AutoDraft(string name, string draft, double count, List<string> list, double salary)
        {
            Name = name;
            GetDraft = draft;
            GetListofPlayers = list;
            GetcoachNumber = count;
            GetsalaryNumber = salary;
        }

        public AutoDraft (string name, double count, List<string> list, double salary)
        {
            Name = name;
            GetcoachNumber = count;
            GetListofPlayers = list;
            GetsalaryNumber = salary;
        }

     
    }
}
