using System;

public class Specialist : Person // Майстер (наслідування від Person)
{
    // На одного майстра може приходитися лише одне замовлення, але на замовлення може декілька майстрів
    public string BranchName { get; set; } // Назва філіалу
    public bool IsFree { get; set; } = true;

    private Order assignedOrder;
    private static List<Specialist> availableSpecs = new List<Specialist>(); // Статичний список майстрів

    /// <summary>
    /// Конструктор за замовчуванням
    /// </summary>
    public Specialist()
    {
        Console.Write("Назва філіалу: "); BranchName = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"Майстер {FullName} доданий.\n");
        availableSpecs.Add(this);
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
        availableSpecs.Add(this);
    }

    public void Show()
    {
        Console.WriteLine($"ПІБ: {FullName}\n" +
                          $"Номер телефону: {PhoneNumber}\n" +
                          $"Назва філіалу: {BranchName}\n");
    }

    /// <summary>
    /// Повертає список доступних майстрів
    /// </summary>
    /// <returns>Список вільних майстрів</returns>
    public static List<Specialist> GetSpecsList()
    {
        return availableSpecs;
    }

    /// <summary>
    /// Виводить список доступних майстрів
    /// </summary>
    public static void ShowAvailableSpecsList()
    {
        int index = 1;
        foreach (Specialist spec in availableSpecs)
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
            Console.Clear();
            Console.WriteLine("Вільні майстри наразі відсутні, спробуйте додати нових.\n");
        }
    }

    /// <summary>
    /// Видаляє майстра зі списку доступних
    /// </summary>
    /// <param name="specialist">Спеціаліст (об'єкт)</param>
    public static void RemoveFromSpecsList(Specialist specialist)
    {
        if (availableSpecs.Contains(specialist))
        {
            availableSpecs.Remove(specialist);
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
