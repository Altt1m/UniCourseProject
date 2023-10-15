public class Specialist : Person // Майстер (наслідування від Person)
{
    // На одного майстра може приходитися лише одне замовлення, але на замовлення може декілька майстрів
    public string BranchName { get; set; } // Назва філіалу
    public Boolean IsFree { get; set; } = true;

    public Specialist()
    {
        Console.Write("Branch name: "); BranchName = Console.ReadLine();
        Console.WriteLine($"Specialist {FullName} added.\n");
    }

    override public void Presentation()
    {
        Console.WriteLine($"My name is {FullName}. I'm a specialist working in {BranchName}.\n");
    }

}
