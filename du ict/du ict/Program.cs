using System;
using System.IO;

class Program
{
    static string cestaSouboru = @"D:\database\databaze 1.txt";
    static string[] radky = File.ReadAllLines(cestaSouboru);
    static string[][] zaznamy = new string[radky.Length][];

    static void Main(string[] args)
    {
        try
        {
            while (true)
            {           
                menu();
                var odezva = Console.ReadKey().KeyChar;   
                switch(odezva)
                {
                    case 'A' or 'a':
                    
                        databazen();
                        break;    
                    
                    case 'B' or 'b':

                        pridatzaznam();
                        break;

                    case 'C' or 'c':

                        Console.WriteLine("Opoustite program");
                        return;

                        

                    default:

                        Console.WriteLine("neplatny vtup, zkuste to znovu"); 

                        break;
                }
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Neco se pokazilo, zavolejte technickou podporu");
        }
    }

    static void menu()
    {
        Console.WriteLine("Co chcete udelat");
        Console.WriteLine("A - vypsat databazi");
        Console.WriteLine ("B - zadat novy zaznam");    
        Console.WriteLine ("C - opustit program ");


    }    
    static void psatdatabase()
    {
        Console.Clear();
        for (int i = 0; i < radky.Length; i++)
        {
            zaznamy[i] = radky[i].Split('*');
            if (i != 0)
            {
                Console.WriteLine("------------------------------------------");
            }
            if (i == 0)
            {
                Console.WriteLine("{0,-5} | {1,-10} | {2,-15} | {3, -20} | {4, -25} | {5, -15} | {6,-10} | {7, -10} | {8,-10}", "záznam", "jmeno", "prijmeni", "ulice", "mesto", "psc", "tel cislo", "pracovni pozice", "titul");
            }
            else
            {
                Console.WriteLine("{0,-5} | {1,-10} | {2,-15} | {3, -20} | {4, -25} | {5, -20} | {6,-15} | {7, -10} | {8,-10}", i, zaznamy[i][0], zaznamy[i][1], zaznamy[i][2], zaznamy[i][3], zaznamy[i][4], zaznamy[i][5], zaznamy[i][6], zaznamy[i][7]);
            }
        }
    }

    static void pridatzaznam()
    {
        Console.WriteLine("jake jmeno chcete pridat");
        string jmeno = Console.ReadLine();
        Console.WriteLine("jake prijmeni chcete pridat");
        string prijmeni = Console.ReadLine();
        Console.WriteLine("jake je jmeno ulice kterou chcete pridat");
        string ulice = Console.ReadLine();
        Console.WriteLine("jake jmeno mesta ktere chcete pridat");
        string mesto = Console.ReadLine();
        Console.WriteLine("jake je psc mesta které chcete pridat");
        string psc = Console.ReadLine();
        Console.WriteLine("jake je tel cislo ktere chcete pridat");
        string telCislo = Console.ReadLine();
        Console.WriteLine("jaka pracovni pozici ma clovek ktereho chcete pridat");
        string pracovniPozice = Console.ReadLine();
        Console.WriteLine("jaký titul tato osobnost má");
        string titul = Console.ReadLine();

        pridatzaznam2(jmeno, prijmeni, ulice, mesto, psc, telCislo, pracovniPozice, titul);
    }

    static void pridatzaznam2(string jmeno, string prijmeni, string ulice, string mesto, string psc, string telCislo, string pracovniPozice, string titul)
    {
       
        using (StreamWriter file = new StreamWriter(cestaSouboru, true))
        {
            file.WriteLine(jmeno + "*" + prijmeni + "*" + ulice + "*" + mesto + "*" + psc + "*" + telCislo + "*" + pracovniPozice + "*" + titul);
        }
        
        
    }

    static void databazen()
    {
        string[] radkyn = File.ReadAllLines(cestaSouboru);
        string[][] zaznamyn = new string[radky.Length][]; 

        Console.Clear();
        for (int i = 0; i < radkyn.Length; i++)
        {
            zaznamyn[i] = radkyn[i].Split('*');
            if (i != 0)
            {
                Console.WriteLine("------------------------------------------");
            }
            if (i == 0)
            {
                Console.WriteLine("{0,-5} | {1,-10} | {2,-15} | {3, -20} | {4, -25} | {5, -15} | {6,-10} | {7, -10} | {8,-10}", "záznam", "jmeno", "prijmeni", "ulice", "mesto", "psc", "tel cislo", "pracovni pozice", "titul");
            }
            else
            {
                Console.WriteLine("{0,-5} | {1,-10} | {2,-15} | {3, -20} | {4, -25} | {5, -20} | {6,-15} | {7, -10} | {8,-10}", i, zaznamy[i][0], zaznamy[i][1], zaznamy[i][2], zaznamy[i][3], zaznamy[i][4], zaznamy[i][5], zaznamy[i][6], zaznamy[i][7]);
            }
        }
    }
}
