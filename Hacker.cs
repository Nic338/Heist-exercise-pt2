using System;

public class Hacker : IRobber
{
    public string Name {get; set;}
    public int SkillLevel {get; set;}
    public int PercentageCut {get; set;}
    public void PerformSkill(Bank bank)
    {
       bank.AlarmScore = (bank.AlarmScore - SkillLevel);
        Console.WriteLine($"{Name} is hacking the alarm system. Decreased security by {SkillLevel} points!");
        if (bank.AlarmScore == 0)
        {
            Console.WriteLine($"{Name} has disabled the alarm system!");
        }
    }
    public string getSpecialty()
    {
        return "Hacker";
    }
    public Hacker(string name, int skillLevel, int percentCut)
    {
        Name = name;
        SkillLevel = skillLevel;
        PercentageCut = percentCut;
    }
}