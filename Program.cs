using System.Text;

namespace Course_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode; // Налаштування кодування виводу
            Console.InputEncoding = Encoding.Unicode; // Налаштування кодування вводу

            //       Запити до системи.
            // 1.Список пристроїв для ремонту.
            // 2.Список пристроїв для встановлення.
            // 3.Список клієнтів, які вибрали певний тип послуги.
            // 4.Середня вартість замовлення.
            // 5.Найбільший термін виконання роботи.
            // 6.Пристрій, який має найбільшу вартість.

            while (true)
            {
                int respond;
                Console.Write("1. Додати майстра\n" +
                              "2. Додати клієнта\n" +
                              "3. Оформити замовлення\n" +
                              "4. Список замовлень на ремонт\n" +
                              "5. Список замовлень на встановлення\n" +
                              "6. Список клієнтів, які обрали певний тип послуги\n" +
                              "7. Найбільший термін виконання роботи\n" +
                              "8. Найдорожче замовлення\n" +
                              "0. Вийти з програми\n\n" +
                              "Оберіть опцію: ");
                try
                {
                    respond = Int32.Parse(Console.ReadLine());
                    if (respond < 0 || respond > 8) 
                    {
                        Console.Clear();
                        Console.WriteLine("Опції під таким номером не існує.\n");
                        continue;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Некоректний ввод номеру опції.\n");
                    continue;
                }

                if ( respond == 0 )
                {
                    Console.WriteLine("\nНа все добре!");
                    break;
                }
                else
                {
                    switch (respond)
                    {
                        case 1:
                            new Specialist();
                            break;
                        case 2:
                            new Client();
                            break;
                        case 3:
                            int specialistNum;
                            int clientNum;
                            while(true)
                            {
                                Console.Clear();
                                if (!Specialist.GetSpecsList().Any())
                                {
                                    Console.Clear();
                                    Console.WriteLine("Спочатку додайте майстрів!\n");
                                    break;
                                }
                                else if (!Client.GetClientsList().Any())
                                {
                                    Console.Clear();
                                    Console.WriteLine("Спочатку додайте клієнтів!\n");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Доступні майстри:\n");
                                    Specialist.ShowSpecsList();
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.Write("Виберіть номер майстра: ");
                                            specialistNum = Int32.Parse(Console.ReadLine());
                                            if (specialistNum <= 0 || specialistNum > Specialist.GetSpecsList().Count)
                                                continue;
                                            Console.Clear();
                                            Console.WriteLine($"Ви обрали майстра №{specialistNum}.\n");
                                            break;
                                        }
                                        catch
                                        {
                                            continue;
                                        }
                                    }
                                    

                                    Console.WriteLine("Доступні клієнти:\n");
                                    Client.ShowClientsList();
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.Write("Виберіть номер клієнта: ");
                                            clientNum = Int32.Parse(Console.ReadLine());
                                            if (clientNum <= 0 || clientNum > Client.GetClientsList().Count)
                                                continue;
                                            Console.Clear();
                                            Console.WriteLine($"Ви обрали клієнта №{clientNum}.\n");
                                            break;
                                        }
                                        catch
                                        {
                                            continue;
                                        }
                                    }

                                    Specialist selectedSpecialist = Specialist.GetSpecsList()[specialistNum - 1];
                                    Client selectedClient = Client.GetClientsList()[clientNum - 1];

                                    new Order(selectedSpecialist, selectedClient);
                                    break; // Вихід з циклу кейса 3
                                }

                            } // Цикл кейсу 3

                            break; // Кінець кейсу

                        // Тут кейси
                        case 7: // Найдовший термін виконання замовлення
                            Console.Clear();
                            if (!Order.GetOrdersList().Any())
                            {
                                Console.WriteLine("Спочатку оформіть хоча б одне замовлення!\n");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Найдовший термін виконання це {Order.GetLongestWorkPeriod()} день(-ів).\n");
                                break;
                            }
                            break;
                        case 8: // Найдорожче замовлення
                            Console.Clear();
                            if (!Order.GetOrdersList().Any())
                            {
                                Console.WriteLine("Спочатку оформіть хоча б одне замовлення!\n");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Найдорожчим є замовлення {Order.GetMostExpensiveOrder().OrderID}.\n" +
                                                  $"Його вартість складає {Order.GetMostExpensiveOrder().Cost} грн.\n");
                                break;
                            }
  
                            
                        
                        default:
                            Console.Clear();
                            Console.WriteLine("Not yet developed.\n");
                            break;

                        

                    } // Світч
                    continue; // Повтор головного циклу
                }
                



            }
            
            //Specialist spec = new Specialist("Жмишенко Михайло Петрович", "+38001", "Енергогаз Україна");
            //spec.Presentation();
            //Client client = new Client("Малевіч Адам Кропивницький", "+38002", "Zabuvko 10");

            //Order order = new Order(spec, client);

            //Console.WriteLine();
            //Specialist spec2 = new Specialist();
            //Client client2 = new Client();
            //Order order2 = new Order(spec2, client2);

            //Console.WriteLine();
            //Order.ShowRepairOrdersList(); // 1.
            //Order.ShowInstallOrdersList(); // 2.
            //Order.ShowClientsByServiceTypeList("Встановлення"); // 3.
            //Console.WriteLine(Order.GetAverageOrderCost()); // 4.
            //Console.WriteLine(Order.GetLongestWorkPeriod()); // 5.
            //Order.GetMostExpensiveOrder().Show(); // 6.


        }
    }
}
