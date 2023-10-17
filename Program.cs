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
                              "7. Середня вартість замовлень\n" +
                              "8. Найбільший термін виконання роботи\n" +
                              "9. Найдорожче замовлення\n" +
                              "0. Вийти з програми\n\n" +
                              "Оберіть опцію: ");
                try
                {
                    respond = Int32.Parse(Console.ReadLine());
                    if (respond < 0 || respond > 9) 
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
                                    Specialist.ShowAvailableSpecsList();
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
                                        catch (Exception)
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
                                    Specialist.RemoveFromSpecsList(selectedSpecialist);
                                    new Order(selectedSpecialist, selectedClient);
                                    break; // Вихід з циклу кейса 3
                                }

                            } // Цикл кейсу 3

                            break; // Кінець кейсу

                        // Тут кейси
                        case 4: // Список замовлень на ремонт
                            Console.Clear();
                            if (!Order.GetOrdersList().Any())
                            {
                                Console.WriteLine("Спочатку оформіть хоча б одне замовлення!\n");
                                break;
                            }
                            else
                            {
                                Order.ShowRepairOrdersList();
                                break;
                            }

                        case 5: // Список замовлень на встановлення
                            Console.Clear();
                            if (!Order.GetOrdersList().Any())
                            {
                                Console.WriteLine("Спочатку оформіть хоча б одне замовлення!\n");
                                break;
                            }
                            else
                            {
                                Order.ShowInstallOrdersList();
                                break;
                            }
                        case 6: // Список клієнтів, які обрали певний тип послуги
                            if (!Client.GetClientsList().Any())
                            {
                                Console.Clear();
                                Console.WriteLine("Спочатку додайте клієнтів!\n");
                                break;
                            }
                            string serviceType;
                            Console.Write("Введіть тип послуги: "); serviceType = Console.ReadLine();
                            Console.Clear();
                            Order.ShowClientsByServiceTypeList(serviceType);
                            break;

                        case 7: // Середня вартість замовлень
                            Console.Clear();
                            if (!Order.GetOrdersList().Any())
                            {
                                Console.WriteLine("Спочатку оформіть хоча б одне замовлення!\n");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Середня вартість всіх замовлень ({Order.GetOrdersList().Count}) становить {Order.GetAverageOrderCost()}.\n");
                                break;
                            }
                            
                        case 8: // Найбільший термін виконання замовлення
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

                        case 9: // Найдорожче замовлення
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

        }
    }
}
