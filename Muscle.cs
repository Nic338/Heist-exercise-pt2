using System;

public class Muscle : IRobber
{
    public string Name {get; set;}
    public int SkillLevel {get; set;}
    public int PercentageCut {get; set;}
    public void PerformSkill(Bank bank)
    {
        bank.SecurityGuardScore = (bank.SecurityGuardScore - SkillLevel);
        Console.WriteLine($"{Name} is taking out the security guards. Decreased security by {SkillLevel} points.");
        if (bank.SecurityGuardScore == 0)
        {
            Console.WriteLine($"{Name} has taken out all of the security guards!");
        }
    }
    public string getSpecialty()
    {
        return "Muscle";
    }
    public Muscle(string name, int skillLevel, int percentCut)
    {
        Name = name;
        SkillLevel = skillLevel;
        PercentageCut = percentCut;
    }
}