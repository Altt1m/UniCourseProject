public abstract class Person : IShow // Абстрактний клас людини для майстра та клієнта
{
    public string FullName { get; set; } // ПІБ
    public string PhoneNumber { get; set; } // Номер телефону

    /// <summary>
    /// Презентування себе
    /// </summary>
    public abstract void Presentation();

    /// <summary>
    /// Конструктор за замовчуванням
    /// </summary>
    public Person()
    {
        Console.Clear();
        Console.Write("ПІБ: "); FullName = Console.ReadLine();
        Console.Write("Номер телефону: "); PhoneNumber = Console.ReadLine();
    }

    /// <summary>
    /// Виводить інформацію про людину
    /// </summary>
    public void Show()
    {
        Console.WriteLine($"ПІБ: {FullName}\n" +
                          $"Номер телефону: {PhoneNumber}\n");
    }

}