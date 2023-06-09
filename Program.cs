using System;
using System.Text.RegularExpressions;

public class Program
{
    static void Main(string[] args)
    {
        Heist();
    }

    static public List<IRobber> rolodex = new List<IRobber>()
        {
            new Hacker("Jimmy the Kid", 45, 25),
            new Hacker("Carlos the Slicer", 57, 29),
            new Muscle("Nadia the Fist", 75, 40),
            new Muscle("Frank the Tank", 25, 15),
            new LockSpecialist("Simon the Snake", 45, 35),
            new LockSpecialist("Carol the Turtle", 65, 15),
        };

    static public Bank theBank = new Bank()
    {
        CashOnHand = new Random().Next(50000, 1000000),
        AlarmScore = new Random().Next(0, 100),
        VaultScore = new Random().Next(0, 100),
        SecurityGuardScore = new Random().Next(0, 100)
    };

    static public List<IRobber> crew = new List<IRobber>();
    
    static void Heist()
    {
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        Console.WriteLine("+++++++++++ Welcome to The Heist +++++++++++++");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        Console.WriteLine();
        Console.WriteLine($"~~~ There are currently {rolodex.Count} potential crew members on file ~~~");
        Console.WriteLine();
        AddRobber();
        ReconReport();
        CrewList();
        AddNewCrewMember();
        startHeist();
    }

    static void AddRobber()
    {
        string? Name;
        string? Specialty;
        string? SkillLevel;
        string? PercentCut;
        int ParsedSpecialty;
        int ParsedSkill;
        int ParsedCut;

        while (true)
        {
            Console.WriteLine("Hey! Who's the new guy?");
            Console.WriteLine("(PRESS ENTER TO STOP ADDING CREW MEMBERS)");
            Console.WriteLine();
            Name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Name))
            {
                break;
            }
            Console.WriteLine();
            Console.WriteLine($"Select a skillset for {Name}: ");
            Console.WriteLine();
            Console.WriteLine("(1) Hacker: Disables Alarm Systems");
            Console.WriteLine();
            Console.WriteLine("(2) Muscle: Takes out Security Guards");
            Console.WriteLine();
            Console.WriteLine("(3) Lock Specialist: Cracks into the Vaults");
            Console.WriteLine();

            Specialty = Console.ReadLine();
            ParsedSpecialty = int.Parse(Specialty);

            if (ParsedSpecialty < 1 || ParsedSpecialty > 3)
            {
                Console.WriteLine("Please try again with a valid option!");
                AddRobber();
            }

            Console.WriteLine();
            Console.WriteLine($"What is {Name}'s level of skill in their specialty?");
            Console.WriteLine();
            Console.WriteLine("Enter a skill level from 1 - 100");
            Console.WriteLine();

            SkillLevel = Console.ReadLine();
            ParsedSkill = int.Parse(SkillLevel);

            if (ParsedSkill < 1 || ParsedSkill > 100)
            {
                Console.WriteLine("Try again with a valid option!");
                AddRobber();
            }

            Console.WriteLine();
            Console.WriteLine($"What percentage cut of the cash does {Name} want?");
            Console.WriteLine();

            PercentCut = Console.ReadLine();
            Console.WriteLine();
            ParsedCut = int.Parse(PercentCut);

            if (ParsedCut < 1 || ParsedCut > 100)
            {
                Console.WriteLine("Cmon don't be stupid, try again and this time pick a reasonable number");
                AddRobber();
            }

            if (ParsedSpecialty == 1)
            {
                rolodex.Add(
                    new Hacker(Name, ParsedSkill, ParsedCut)
                );
            }
            else if (ParsedSpecialty == 2)
            {
                rolodex.Add(
                    new Muscle(Name, ParsedSkill, ParsedCut)
                );
            }
            else if (ParsedSpecialty == 3)
            {
                rolodex.Add(
                    new LockSpecialist(Name, ParsedSkill, ParsedCut)
                );
            }
        }
    }

    static void ReconReport()
    {
        static string mostSecure(Bank bank)
        {
            if (bank.AlarmScore > bank.VaultScore && bank.AlarmScore > bank.SecurityGuardScore)
                return "Alarm";
            else if (bank.VaultScore > bank.AlarmScore && bank.VaultScore > bank.SecurityGuardScore)
                return "Vault";
            else 
                return "Security Guard";
        }
    
        static string leastSecure(Bank bank)
        {
            if (bank.AlarmScore < bank.VaultScore && bank.AlarmScore < bank.SecurityGuardScore)
                return "Alarm";
            else if (bank.VaultScore < bank.AlarmScore && bank.VaultScore < bank.SecurityGuardScore)
                return "Vault";
            else 
                return "Security Guard";
        }
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("+++++++++++++++ Recon Report  ++++++++++++++++");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine();
        Console.WriteLine($"The bank's most Secure Sytem is the {mostSecure(theBank)}");
        Console.WriteLine();
        Console.WriteLine($"The bank's least Secure System is the {leastSecure(theBank)}");
        Console.WriteLine();
    }

    static void CrewList()
    {
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("++++++++++ Potential Crew Members ++++++++++++");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine();

        for(int i = 0; i < rolodex.Count; i++)
        {
            int sumOfCuts = crew.Sum(x => x.PercentageCut);
            int maxCut = 100 - sumOfCuts;

            if(rolodex[i].PercentageCut < maxCut && !crew.Contains(rolodex[i]))
            {
            Console.WriteLine($"({i + 1}). {rolodex[i].Name}: ({rolodex[i].getSpecialty()}) Skill Level: {rolodex[i].SkillLevel} Cut: {rolodex[i].PercentageCut}%");
            Console.WriteLine();
            }
        }
    }

    static void AddNewCrewMember()
    {
        Console.WriteLine();

        string? CrewIndex;
        int parsedIndex;

        while (true)
        {
        Console.WriteLine("Enter an Index for the crew member you want:");
        Console.WriteLine("If you're done, press ENTER to start your heist");
        Console.WriteLine();
        CrewIndex = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(CrewIndex))
        break;

        parsedIndex = int.Parse(CrewIndex);
        if (parsedIndex < 0 || parsedIndex > rolodex.Count)
        {
            Console.WriteLine("Invalid entry. Pick a valid crew member.");
            continue;
        }

        IRobber selectedCrew = rolodex[parsedIndex - 1];

        crew.Add(selectedCrew);
        Console.WriteLine($"{selectedCrew.Name} was added to the crew");
        Console.WriteLine();
        CrewList();
        }
    }

    static void startHeist()
    {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine();

        foreach (IRobber crewMember in crew)
        {
            crewMember.PerformSkill(theBank);
            Console.WriteLine();

        }
            Console.WriteLine();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

        if (theBank.IsSecure)
        {
            Console.WriteLine();
            Console.WriteLine("The heist failed! Get out of there!");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("The heist was a success! Cheese it!");
            Console.WriteLine();

            int bankCash = theBank.CashOnHand;
            int howMuchWasCut = 0;

            foreach (IRobber crewMember in crew)
            {
                int crewsCut = (crewMember.PercentageCut * bankCash) / 100;
                Console.WriteLine($"{crewMember.Name}'s cut from the heist was ${crewsCut}");
                Console.WriteLine();
                howMuchWasCut = howMuchWasCut + crewsCut;
            }

            int myCut = bankCash - howMuchWasCut;
            Console.WriteLine($"After it was all said and done, you took home ${myCut}");
        }
    }
}