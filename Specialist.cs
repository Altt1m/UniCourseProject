public class Specialist : Person // Майстер (наслідування від Person)
{
    // На одного майстра може приходитися лише одне замовлення, але на замовлення може декілька майстрів
    public string BranchName { get; set; } // Назва філіалу
    public Boolean IsFree { get; set; } = true;

    public Specialist()
    {
        Console.Write("Назва філіалу: "); BranchName = Console.ReadLine();
        Console.WriteLine($"Майстер {FullName} доданий.\n");
    }

    override public void Presentation()
    {
        Console.WriteLine($"Мене звати {FullName}. Я працюю майстром у {BranchName}.\n");
    }

}
