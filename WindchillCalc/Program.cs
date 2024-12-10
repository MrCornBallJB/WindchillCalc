namespace WindchillCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // En while true loop så att proggramet inte avslutar 
            while (true)

            {
                // skriver ut text 
                Console.WriteLine("1: Beräkna windchill-faktor: ");
                Console.WriteLine("2: Avsluta: ");
                // läser in värde från användaren 
                int userinput = int.Parse(Console.ReadLine());   

                switch (userinput) // använder swich case för user input 
                {
                    case 1:        // om det är ett 
                        
                        meny();   // kallar meny method 
                        break;

               

                    case 2:   // om det är 2 
                        Environment.Exit(0); // avslutar programmet 
                        break;
                }
                // om mattingen inte är 1 eller 2 så skriver vi ut ett varningsmedelande 
                if (userinput != 1 && userinput != 2)
                {
                   
                    Console.WriteLine("Fel input!");
                }
                Console.WriteLine();









            }







        }

        // vi gör en funktion för all text 
        static void meny()
        {
            // Variabler som vi kommer använda 
            double Temp = 0;
            double Wind = 0;
            double WindChillcalc = 0;

            // Printar ut text till anvädnaren 
            Console.WriteLine("Ange utomhustempraturen i celsius: ");
            //Läser in värde och sparar den i temp variabel
            Temp = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Fyll i vindhastighetet ( ange i m/s eller km/h ): ");
            Console.WriteLine("1: m/s");
            Console.WriteLine("2: km/h");
            // Läser in enheten 
            int enhet = int.Parse(Console.ReadLine());

            Console.WriteLine("Vindhastigheten");
            // läser in vind o sparar den i wind variabel 
            Wind = Convert.ToDouble(Console.ReadLine());
            // kontrollerar om värdet är 1
            if (enhet == 1)
            {
                if (Wind < 1.39) // om inputen är mindre än 1,39 
                {
                    Console.WriteLine("Vindhastighet för låg för att beräkna!"); // informerar användaren 
                    Environment.Exit(0); // Avsluta proggramet 
                }
                else
                {
                    
                    ms(Temp, Wind, WindChillcalc); //  annars kallar ms metoden för att räkna 
                    
                }
                // kontrollerar om värdet är 2 
            } else if (enhet == 2) {
                // om vindhastigheten är mindre än 5, skriv ut varningsmeddelande 
                if(Wind < 5) {
                    Console.WriteLine("Vindhastighet för låg för att beräkna!");
                    Environment.Exit(0);


                } 
                else
                {
                    //  annars kallar kmh metoden för att räkna
                    kmh(Temp, Wind, WindChillcalc);
                   
                }

            } else { Console.WriteLine("Fel input!"); }

            
            
            

            



        }

        // en method för att räkna ms 
        static void ms(double temp, double wind, double WindChill)
        {
            // converterar ms till kmh 
            double Wind = wind * 3.6;
            // ekvationen för att räkna vi matar in värde från temp och wind och sparar den i windchill variabel 
            WindChill = 13.12 + 0.6215 * temp - 11.37 * Math.Pow(Wind, 0.16) + 0.3965 * temp * Math.Pow(Wind, 0.16); 
            // skriver ut resultaten 
            Console.WriteLine($"Känns som {WindChill:F2} grader celsius");


            // Om resultaten är större än -25 skriver ut (kallt)
            if(WindChill > -25)
            {

                Console.WriteLine("Kallt");

            } else if (WindChill > -35 && WindChill < -25)  // om resultatet är större än -35 och mindre än -25 skriver ut (mycket kalt )
            {
                Console.WriteLine("Mycket kallt");
            }
            else if (WindChill > -65 && WindChill < -35)    // om resultatet är större än -65 och mindre än -35 ( skriver ut risk för frostskada )
            {
                Console.WriteLine("Risk för frostskada"); 
                
            }
            else if (WindChill < -60)                       // om resultaet är mindre än -60, skriver ut ( risk för frostskada ) 
            {
                Console.WriteLine("Risk för frostskada");
            }

        }

        // en method för att räkna i km/h
        static void kmh(double temp, double wind, double WindChill)
        {
            
            
            
            // ekvationen för uträkningen 
            WindChill = 13.12 + 0.6215 * temp - 11.37 * Math.Pow(wind, 0.16) + 0.3965 * temp * Math.Pow(wind, 0.16); 
            // skriver ut resultatet 
            Console.WriteLine($"Känns som {WindChill:F2} grader celsius");

            if (WindChill > -25)   // om resultatet är större än -25 ( kalt )
            {
                Console.WriteLine("Kallt");
            }
            else if (WindChill > -35 && WindChill < -25)  // om resultatet är större än -35 och mindre än 25 ( mycket kalt )
            {
                Console.WriteLine("Mycket kallt");
            }
            else if (WindChill > -65 && WindChill < -35) // om resultaet är mindre än -65 och mindre än -35 skriver ut ( risk för frostskada )
            {
                Console.WriteLine("Risk för frostskada");
            }
            else if (WindChill < -60)
            {
                Console.WriteLine("Risk för frostskada");  // om resultatet är mindre än -60 ( risk för frostskada ) 
            }

        }


    }
}   




