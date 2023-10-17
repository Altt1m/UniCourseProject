public class Specialist : Person // Майстер (наслідування від Person)
{
    // На одного майстра може приходитися лише одне замовлення, але на замовлення може декілька майстрів
    public string BranchName { get; set; } // Назва філіалу
    public Boolean IsFree { get; set; } = true;

    private Order assignedOrder;

    /// <summary>
    /// Конструктор за замовчуванням
    /// </summary>
    public Specialist()
    {
        Console.Write("Назва філіалу: "); BranchName = Console.ReadLine();
        Console.WriteLine($"Майстер {FullName} доданий.\n");
    }

    /// <summary>
    /// Конструктор з параметрами
    /// </summary>
    /// <param name="fN">ПІБ</param>
    /// <param name="pNum">Номер телефону</param>
    /// <param name="bN">Назва філіалу</param>
    public Specialist(string fN, string pNum, string bN)
    {
        FullName = fN;
        PhoneNumber = pNum;
        BranchName = bN;
    }

    override public void Presentation()
    {
        Console.WriteLine($"Мене звати {FullName}. Я працюю майстром у {BranchName}.\n");
    }

    /// <summary>
    /// Приписує майстру замовлення
    /// </summary>
    /// <param name="order">Приписуване замовлення</param>
    public void SetAssignedOrder(Order order)
    {
        assignedOrder = order;
    }

}
