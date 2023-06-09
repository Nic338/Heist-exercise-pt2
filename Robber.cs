using System;

public interface IRobber
{
    string Name { get; }
    int SkillLevel {get; set;}
    int PercentageCut {get; set;}
    void PerformSkill(Bank bank)
    {
        
    }
    string getSpecialty();
}