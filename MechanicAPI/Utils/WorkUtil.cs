using Mechanic.Shared.Modells;

namespace MechanicAPI.Utils;

public class WorkUtil
{
    public static double CalculateWorkHours(Work work)
    {
        double age = DateTime.Now.Year - work.ProductionDate;
        if (age >= 0 && age < 5)
        {
            age = 0.5;
        }
        else if (age >= 5 && age <= 10)
        {
            age = 1;
        }
        else if (age >= 10 && age < 20)
        {
            age = 1.5;
        }
        else if (age >= 20)
        {
            age = 2;
        }

        double category = (int) work.WorkCategory;
        

        double severity;
        
        if (work.Severity <= 2)
        {
            severity = 0.2;
        }
        else if (work.Severity <= 4)
        {
            severity = 0.4;
        }
        else if (work.Severity <= 7)
        {
            severity = 0.6;
        }
        else if (work.Severity <= 9)
        {
            severity = 0.8;
        }
        else
        {
            severity = 1.0;
        }
        
        return age * severity * category;
        
    }
}