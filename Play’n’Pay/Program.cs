namespace Play_n_Pay
{
    internal class Program
    {
        static void Main(string[] args) => Meny();
        static void Tärningar(int saldo, int lyckonummer, int bet)
        {
            Console.Clear();
            Console.WriteLine($"saldo       : {saldo}");
            Console.WriteLine($"lyckonummer : {lyckonummer}");
            Console.WriteLine($"Bet         : {bet}");
            Console.WriteLine("======================");
            Console.WriteLine($"Tryck på valfri tangent för att kasta tärningarna.");
            Console.ReadKey();
            Console.WriteLine();
            saldo = saldo - bet;
            int vinst = 0;
            int antalRätt = 0;

            Random random = new Random();

            int a = random.Next(1, 7);
            int b = random.Next(1, 7);
            int c = random.Next(1, 7);

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"T1: {a} ");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"T2: {b} ");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"T3: {c} ");
            Console.WriteLine();

            List<int> resultat = new List<int>() { a, b, c };

            resultat.ForEach(x =>
            {
                if (x == lyckonummer)
                {
                    antalRätt++;
                }
            });

            if (antalRätt == 0)
            {
                Console.WriteLine("Tyvärr ingen vinst :( ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"V I N S T");
                Console.ResetColor();
                if (antalRätt == 1)
                {
                    vinst = bet * 2;
                }
                else if (antalRätt == 2)
                {
                    vinst = bet * 3;
                }
                else
                {
                    vinst = bet * 4;
                }

            }

            saldo = saldo + vinst;

            if (saldo < 50)
            {
                Console.WriteLine();
                Console.WriteLine("tyvärr är dina pengar slut för denna gång :( ");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.WriteLine();
            Console.WriteLine($"Du vann {vinst} pix, ditt saldo är nu: {saldo}");
            Console.ReadKey();
            Spelet(saldo, bet, lyckonummer);
        }
        static void Spelet(int saldo, int bet, int lyckonummer)
        {

            Console.Clear();
            Console.WriteLine($"saldo       : {saldo}");
            Console.WriteLine($"lyckonummer : {lyckonummer}");
            Console.WriteLine($"Bet         : {bet}");
            Console.WriteLine("======================");
            Console.WriteLine("1. Ändra lyckonummer");
            Console.WriteLine("2. Ändra insatserna");
            Console.WriteLine("3. Kasta tärningarna!");
            Console.WriteLine("4. Avsluta");
            string användarensVal = "";

            while (användarensVal != "4")
            {
                användarensVal = (Console.ReadLine());
                switch (användarensVal)
                {
                    case "1":
                        {
                            Console.Clear();
                            lyckonummer = 0;

                            while (true)
                            {
                                Console.Write("Vilket lyckonummer (1-6) väljer du: ");
                                string nummerInput = Console.ReadLine();

                                if (int.TryParse(nummerInput, out lyckonummer))
                                {
                                    if (lyckonummer > 0 && lyckonummer < 7)
                                    {
                                        Console.WriteLine("OK, bra val ;)");
                                        Thread.Sleep(1000);
                                        break;
                                    }
                                }
                                Console.WriteLine("Du får endast välja en siffra mellan 1-6 ;)");
                            }
                            Spelet(saldo, bet, lyckonummer);
                            break;
                        }
                    case "2":
                        {

                            Bet(saldo, lyckonummer, bet);
                            break;
                        }
                    case "3":
                        {
                            Tärningar(saldo, lyckonummer, bet);
                            break;
                        }
                    case "4":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Välj en siffra mellan 1-4...");
                            break;
                        }
                }

            }

        }
        static void Bet(int saldo, int lyckonummer, int bet)
        {
            Console.Clear();
            while (true)
            {

                Console.WriteLine($"Ditt saldo: {saldo}");
                Console.WriteLine("Hur mycket vill du satsa: ");
                string nummerInput = Console.ReadLine();
                if (int.TryParse(nummerInput, out bet))
                {
                    if (bet >= 50 && bet <= saldo)
                    {
                        break;
                    }
                }

                Console.WriteLine("Läs reglerna igen...");
            }

            Spelet(saldo, bet, lyckonummer);
        }
        static void Meny()
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                        ====TäRnInGaR=====");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("    Dubbla, tredubbla eller fyrdubbla din insats!!");
            Console.WriteLine();
            Console.WriteLine("  Instruktioner:");
            Console.WriteLine("      * Spelaren satsar pix (minst 50 pix)");
            Console.WriteLine("      * Spelaren väljer ett lyckotal (1-6)");
            Console.WriteLine("      * Tre tärningar kastas");
            Console.WriteLine("      * Om en tärning visar lyckotalet får man dubbla insatsen");
            Console.WriteLine("      * Om två tärningar visar får man tre gånger insatsen");
            Console.WriteLine("      * Om alla tärningarna visar lyckonumret så får man fyra gånger insatsen");
            Console.WriteLine();
            Console.WriteLine("  Okej, redo att spela? ( y / n )");

            string användarensVal = "";

            while (användarensVal != "n")
            {
                användarensVal = Console.ReadLine();

                switch (användarensVal)
                {

                    case "y":
                        Console.WriteLine("Allright! Då sätter vi igång....");
                        Thread.Sleep(1000);
                        Console.Clear();
                        int lyckonummer = 0;

                        while (true)
                        {
                            Console.Write("Vilket lyckonummer (1-6) väljer du: ");
                            string nummerInput = Console.ReadLine();

                            if (int.TryParse(nummerInput, out lyckonummer))
                            {
                                if (lyckonummer > 0 && lyckonummer < 7)
                                {
                                    Console.WriteLine("OK, bra val ;)");
                                    Thread.Sleep(1000);
                                    break;
                                }
                            }
                            Console.WriteLine("Du får endast välja en siffra mellan 1-6 ;)");
                        }
                        Console.Clear();
                        int saldo = 500;
                        int bet = 0;

                        while (true)
                        {

                            Console.WriteLine($"Ditt saldo: {saldo}");
                            Console.WriteLine("Hur mycket vill du satsa: ");
                            string nummerInput = Console.ReadLine();
                            if (int.TryParse(nummerInput, out bet))
                            {
                                if (bet >= 50 && bet <= saldo)
                                    break;
                            }

                            Console.WriteLine("Läs reglerna igen...");
                        }

                        Spelet(saldo, bet, lyckonummer);
                        break;
                    case "n":
                        Console.WriteLine("OK, Ha en bra dag...");
                        break;

                    default:
                        Console.WriteLine("Förlåt, jag uppfattade inte vad du ville...");
                        break;
                }
            }


        }
    }
}