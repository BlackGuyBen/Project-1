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

            double[,] salaryNumbered =
            {
             /*1*/  {26400100,24500100,23400000,26200300,24000000,27800900,22900300,23000000 },
             /*2*/  {20300100,19890200,21900300,22000000,22500249,21000800,19000590,20000000 },
             /*3*/  {17420300,18700800,19300230,16000000,20000100,17499233,18000222,19400000 },
             /*4*/  {13100145,15000000,13400230,18000000,16000200,27900200,12999999,16200700 },
             /*5*/  {10300000,11600400,10000000,13000000,11899999,14900333,10000100,15900000 }
            };

            int row, col;
            bool keepGoing = true;
            double sum;
            string numInput, name;

            List<String> coachList = new List<String>();
            List<Double> playerCost = new List<Double>();
            List<String> roster = new List<String>();

            ConsoleKeyInfo keyPress;

            //welcome message
            welcome(out keyPress);
            while (keyPress.Key == ConsoleKey.Enter)
            {
                name = getName();
                numInput = getInput();
                Console.Clear();
                outputList(ref positions, ref playerNames, ref colleges, ref );

                do
                {
                    getData(out row, out col);
                    outputInfo(ref row, ref col, ref salary);

                    //Add data to list
                    coachList.Add(playerNames[row, col]);
                    playerCost.Add(salary[row, col]);
                    //playerNumberCost.Add(salaryNumbered[row, col]);
                    keepGoing = getInnerPrimer();
                } while (keepGoing);

                //Going through the list to show choosen players
                foreach (var x in coachList)
                {
                    Console.WriteLine($"You have added the following player {i}");
                }

                Console.WriteLine("Total number of players: {0}", coachList.Count);
                total = playerCost.Sum();






            }

        }
        public static void welcome(out ConsoleKeyInfo keyPress)
        {
            Console.WriteLine("Welcome, this program...");
            Console.WriteLine("Let's get started, please press the enter key");
            keyPress = Console.ReadKey();
        }
    }
}
