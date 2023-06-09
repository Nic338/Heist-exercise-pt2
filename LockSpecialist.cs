using System;

public class LockSpecialist : IRobber
{
    public string Name {get; set;}
    public int SkillLevel {get; set;}
    public int PercentageCut {get; set;}
    public void PerformSkill(Bank bank)
    {
        bank.VaultScore = (bank.VaultScore - SkillLevel);
        Console.WriteLine($"{Name} is cracking the vault. Decreased security by {SkillLevel} points.");
        if (bank.VaultScore <= 0)
        {
            Console.WriteLine($"{Name} has broken into the vault!");
        }
    }
    public string getSpecialty()
    {
        return "Lock Specialist";
    }
    public LockSpecialist(string name, int skillLevel, int percentCut)
    {
        Name = name;
        SkillLevel = skillLevel;
        PercentageCut = percentCut;
    }
}