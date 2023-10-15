public abstract class Person // Абстрактний клас людини для майстра та клієнта
{
    public string FullName { get; set; } // ПІБ
    public string PhoneNumber { get; set; } // Номер телефону

    public abstract void Presentation();

    public Person()
    {
        Console.Write("Full name: "); FullName = Console.ReadLine();
        Console.Write("Phone number: "); PhoneNumber = Console.ReadLine();
    }

}