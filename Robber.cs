using System;

public interface IRobber
{
    public string Name { get; }
    public int SkillLevel {get; set;}
    public int PercentageCut {get; set;}
    public void PerformSkill(Bank bank)
    {
        
    }
    public string getSpecialty();
}