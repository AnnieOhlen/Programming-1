using System;
using System.Collections.Generic;

namespace Blogg
{
    class Program
    {
        static void Main(string[] args)
        {
            //Definiering av lista för blogginlägg.
            List<string[]> stringLista = new List<string[]>();

            //Bool och while för kontroll över programmets avslut.
            bool programKör = true;
            while (programKör)

            {
                //Så att konsollen rensas mellan menyåtergångarna/valen.
                Console.Clear();

                //Dagens datum nedanför som står högst upp i bloggen vid programstart.
                DateTime dagensDatum = DateTime.Now;
                Console.WriteLine(dagensDatum.ToShortDateString());

                //Nedan följer en meny med switch, lade till lite specialtecken för att snygga upp/avgränsa i konsollen.
                //Special-tecken eller brytrader så som " — — — — — " används igenom programmet.
                Console.WriteLine(" — — — — — — — — — — — — — ");
                Console.WriteLine("< § ~ { BLOGGEN } ~ § >");
                Console.WriteLine("[1] Skriv ett nytt inlägg");
                Console.WriteLine("[2] Läs alla inlägg");
                Console.WriteLine("[3] Sök bland alla inlägg");
                Console.WriteLine("[4] Radera inlägg från din blogg");
                Console.WriteLine("[5] Avsluta bloggen");
                Console.WriteLine(" — — — — — — — — — — — — — ");

                //Tryparse ifall ogiltig inmatning sker (bokstäver).
                Int32.TryParse(Console.ReadLine(), out int menyVal);
                switch (menyVal)
                {
                    //Case 1 används till att skapa nya inlägg.
                    case 1:
                        //Första strängen används till dagens datum när inlägget skapas.
                        string[] nyPost = new string[4];
                        Console.WriteLine(" — — — — — ");
                        nyPost[0] = dagensDatum.ToShortDateString();
                        Console.WriteLine("Dagens datum: " + nyPost [0]);
                        Console.WriteLine(" — — — — — ");

                        //Andra strängen för rubrik till inlägget.
                        Console.WriteLine("< Skriv din rubrik >");
                        nyPost[1] = Console.ReadLine();
                        Console.WriteLine(" — — — — — ");

                        //Tredje strängen för innehållet i inlägget.
                        Console.WriteLine("< Skriv ditt blogginlägg >");
                        nyPost[2] = Console.ReadLine();
                        Console.WriteLine(" — — — — — ");

                        /*Fjärde strängen för sökord då det är vanligt i bloggar.
                        Sökorden är inte alltid exakta ord som matchar inläggets innehåll utan kan beskriva inlägget
                        och på så sätt attrahera fler läsare.*/
                        Console.WriteLine("< Sökord >");
                        nyPost[3] = Console.ReadLine();
                        Console.WriteLine(" — — — — — ");

                        //Slutligen läggs de fyra nya posterna in i vektorlistan som en sträng-vektor.
                        stringLista.Add(nyPost);

                        //Information till användaren att inlägget sparats och hur återgång sker till menyn.
                        Console.WriteLine("Ditt inlägg har sparats!");
                        Console.WriteLine("Tryck ENTER för att återgå till menyn!");
                        break;

                    //Case 2 används till att lista skapade inlägg men skriver även ut till konsoll om inlägg saknas.
                    case 2:
                        //Vad som händer om sträng-vektorlistan saknar strängar (alltså inlägg).
                        if (stringLista.Count == 0)
                        {
                            Console.WriteLine("Det finns inga inlägg i bloggen!");
                        }
                        
                        //Vad som sker om ovanstående inte är fallet; samtliga vektorer i listan skrivs ut i nummerordning.
                        else
                        {
                            //For går igenom varje strängvektor i vektorlistan och skriver ut dem i indexordning.
                            for (int i = 0; i < stringLista.Count; i++)
                            {
                                Console.WriteLine(" — — — — — — — — — — — — — ");
                                Console.WriteLine("# " + (i));
                                Console.WriteLine(" — — — — — ");
                                Console.WriteLine("< " + stringLista[i][0] + " >");
                                Console.WriteLine(" — — — — — ");
                                Console.WriteLine("< Rubrik: " + stringLista[i][1] + " >");
                                Console.WriteLine(" — — — — — ");
                                Console.WriteLine("< Inlägg: " + stringLista[i][2] + " >");
                                Console.WriteLine(" — — — — — ");
                                Console.WriteLine("Sökord: " + stringLista[i][3]);
                            }
                        }
                        break;

                    //Case 3 används till linjär sökning.
                    case 3:
                        //Input från användare efterfrågas vilket blir en stäng-variabel för sökningen.
                        Console.WriteLine("Skriv vad du söker efter!");
                        Console.WriteLine("(Format för datumsökning är " + dagensDatum.ToShortDateString() + ".)");
                        Console.WriteLine(" — — — — — ");
                        string sökOrd = Console.ReadLine();

                        /*En for-loop för att gå igenom samtliga inlägg som lagts till i listan (bloggen).
                        if används för att kontrollera i varje kategori om sökordet finns,
                        varefter det skrivs ut i vilket indexnummer som inlägget finns i.
                        Använde mig först av lika med operator för kategorierna i listan och sökord men fick då inte
                        med träffar där flera ord skrivits i ex. samma rubrik. Bytte därefter till "Contains" för att lösa problemet.*/

                        for (int i = 0; i < stringLista.Count; i++)
                        {
                            //Då [0] endast innehåller siffror i strängen för datum så används inte ToLower i just denna.
                            if (stringLista[i][0].Contains(sökOrd))
                            {
                                Console.WriteLine(" — — — — — ");
                                Console.WriteLine(sökOrd + " finns som datum för blogginlägg # " + i + " !");
                            }

                            if (stringLista[i][1].ToLower().Contains(sökOrd.ToLower()))
                            {
                                Console.WriteLine(" — — — — — ");
                                Console.WriteLine(sökOrd + " finns i rubriken för blogginlägg # " + i + " !");
                            }

                            if (stringLista[i][2].ToLower().Contains(sökOrd.ToLower()))
                            {
                                Console.WriteLine(" — — — — — ");
                                Console.WriteLine(sökOrd + " förekommer i blogginlägg # " + i + " !");
                            }

                            if (stringLista[i][3].ToLower().Contains(sökOrd.ToLower()))
                            {
                                Console.WriteLine(" — — — — — ");
                                Console.WriteLine(sökOrd + " finns bland sökorden för blogginlägg # " + i + " !");
                            }
                        }
                        //Informerar användaren om att eventuellt ytterligare träffar inte finns, återgång till menyn.
                        Console.WriteLine(" — — — — — ");
                        Console.WriteLine("Sökningen [ " + sökOrd + " ] gav inga ytterligare träffar.");
                        Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
                        break;

                    /*Case 4 används till att radera specifika inlägg. Dessa raderas utifrån indexnummer, 
                     användaren kan ta del av numret genom att skriva ut samtliga inlägg eller göra en sökning.*/
                    case 4:
                        //Användaren får fråga om vilket inlägg ska raderas, TryParse och int-variabel skapas för detta.
                        Console.WriteLine(" — — — — — ");
                        Console.WriteLine("Vilket inlägg (nummer) ska raderas från bloggen?" +
                            "\nOm du inte vet vilket nummer inlägget har så gå menyn för att söka i bloggen.");
                        Console.WriteLine(" — — — — — ");

                        Int32.TryParse(Console.ReadLine(), out int radera);
                        //Alternativ för vad som händer om sökträff inte finns.
                        if (stringLista.Count == 0)
                        {
                            Console.WriteLine(" — — — — — ");
                            Console.WriteLine("Inlägget finns inte bloggen eller så har du inte skrivit en siffra!" + 
                                "\nTryck på valfri tangent för att återgå till menyn.");
                            Console.WriteLine(" — — — — — ");
                        }

                        //Alternativ för vad som händer om det finns inlägg.
                        else
                        {
                            //Användaren får möjlighet att bekräfta eller avbryta radering av inlägg.
                            Console.WriteLine(" — — — — — ");
                            Console.WriteLine("Ska verkligen inlägg nummer " + radera + " ska raderas?" +
                                "\nBekräfta med JA eller tryck valfri tangent för att avbryta och återgå till menyn.");
                            Console.WriteLine(" — — — — — ");
                            //Beep-ljud för att förvarna för "allvarlig åtgärd".
                            Console.Beep();
                            //Ny string-variabel gällande bekräftelse att radera introduceras.
                            string raderaBekräftelse = Console.ReadLine();
                            if (raderaBekräftelse.ToUpper() == "JA")
                            {
                                    //Efter bekräftelse i tidigare kodstycke sker radering utifrån valt indexnummer.
                                    stringLista.RemoveAt(radera);
                                    Console.WriteLine(" — — — — — ");
                                    Console.WriteLine("Nu är inlägg nummer " + radera + " raderat." +
                                        "\n Tryck på valfri tangent för att återgå till menyn.");
                                    Console.WriteLine(" — — — — — ");
                            }

                            else
                            {
                                Console.WriteLine(" — — — — — ");
                                Console.WriteLine("Du har avbrutit borttagning av blogginlägg nummer " + radera + ".");
                                Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
                                Console.WriteLine(" — — — — — ");
                            }
                        }
                        break;

                    //Case 5 används till att avsluta programmet.
                    case 5:
                        /*Lagt in valt för användaren att bekräfta att programmet faktiskt ska avslutas.
                         Sker med string-variabel från användaren och if-struktur.*/
                        Console.WriteLine(" — — — — — ");
                        Console.WriteLine("Vill du avsluta programmet?" +
                            "\nBekräfta med JA eller tryck valfri tangent för att avbryta och återgå till menyn.");
                        //Beep-ljud för att förvarna för "allvarlig åtgärd".
                        Console.Beep();
                        Console.WriteLine(" — — — — — ");

                        //Nedan inväntas input från användare, om ja avslutas programmet annars valfri tangent för att avbryta.
                        string programAvslut = Console.ReadLine();
                        if (programAvslut.ToUpper() == "JA")
                        {
                            Console.WriteLine(" — — — — — ");
                            Console.WriteLine("Tryck valfri tangent för att avsluta programmet.");
                            programKör = false;
                        }
                        //Alternativ om användaren inte matar in "ja", detta alternativ för återgång till menyn.
                        else
                        {
                            Console.WriteLine(" — — — — — ");
                            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
                            Console.WriteLine(" — — — — — ");
                        }
                        break;

                    default:
                        Console.WriteLine(" — — — — — ");
                        Console.WriteLine("Du måste välja mellan menyval 1-5!");
                        Console.WriteLine(" — — — — — ");
                        break;
                }
                Console.ReadLine(); //Så att enter behövs efter varje menyval (så att fönstret inte rensas direkt).
            }
        }
    }
}
