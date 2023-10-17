public class Specialist : Person // Майстер (наслідування від Person)
{
    // На одного майстра може приходитися лише одне замовлення, але на замовлення може декілька майстрів
    public string BranchName { get; set; } // Назва філіалу
    public Boolean IsFree { get; set; } = true;

    private Order assignedOrder;
    private static List<Specialist> specs = new List<Specialist>(); // Статичний список майстрів

    /// <summary>
    /// Конструктор за замовчуванням
    /// </summary>
    public Specialist()
    {
        Console.Write("Назва філіалу: "); BranchName = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"Майстер {FullName} доданий.\n");
        specs.Add(this);
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
        specs.Add(this);
    }

    public void Show()
    {
        string occupied = "Ні";
        if (!IsFree)
        {
            occupied = "Так";
        }
        Console.WriteLine($"ПІБ: {FullName}\n" +
                          $"Номер телефону: {PhoneNumber}\n" +
                          $"Назва філіалу: {BranchName}\n" +
                          $"Зайнятий: {occupied}\n");
    }

    public static List<Specialist> GetSpecsList()
    {
        return specs;
    }

    public static void ShowSpecsList()
    {
        int index = 1;
        foreach (Specialist spec in specs)
        {
            if (spec.IsFree)
            {
                Console.WriteLine($"Майстер №{index}");
                spec.Show();
                index++;
            }
        }
        if (index == 1)
        {

        }
    }

    /// <summary>
    /// Приписує майстру замовлення
    /// </summary>
    /// <param name="order">Приписуване замовлення</param>
    public void SetAssignedOrder(Order order)
    {
        assignedOrder = order;
    }

    override public void Presentation()
    {
        Console.WriteLine($"Мене звати {FullName}. Я працюю майстром у {BranchName}.\n");
    }

    

}
