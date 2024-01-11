using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUTODEALERN.DAL;
using AUTODEALERN.Model;

namespace AUTODEALERN.Interface
{
    internal class MainMenu
    {
        private readonly ADDBStorage _dbStorage;
        private readonly SalesmanInterface _salesmanInterface;
        private readonly OrderInterface _orderInterface;

        public MainMenu(ADContext _context)
        {

            _dbStorage = new ADDBStorage(_context);
            _orderInterface = new OrderInterface(_dbStorage);
            _salesmanInterface = new SalesmanInterface(_dbStorage);
        }
        public void Run() 
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Работа со сотрудниками");
                Console.WriteLine("2. Работа с заказами");
                Console.WriteLine("3. Выйти");

                Console.Write("Введите номер действия: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowSalesmanMenu();
                        break;
                    case "2":
                        ShowOrdersMenu();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }

        }
        private void ShowSalesmanMenu() 
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("Выберите действие для сотрудников:");
                Console.WriteLine("1. Добавить сотрудника");
                Console.WriteLine("2. Удалить сотрудника");
                Console.WriteLine("3. Вывести всех сотрудников");
                Console.WriteLine("4. Назад");

                Console.Write("Введите номер действия или '4' для возврата: ");
                string actionChoice = Console.ReadLine();

                switch (actionChoice)
                {
                    case "1":
                        _salesmanInterface.AddSalesman();
                        break;
                    case "2":
                        _salesmanInterface.RemoveSalesman();
                        break;
                    case "3":
                        _salesmanInterface.GetAllSalesmans();
                        break;
                    case "4":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }

        }
        private void ShowOrdersMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("Выберите действие для заказов:");
                Console.WriteLine("1. Создать заказ");
                Console.WriteLine("2. Удалить заказ");
                Console.WriteLine("3. Вывести все заказы");
                Console.WriteLine("4. Назад");

                Console.Write("Введите номер действия или '3' для возврата: ");
                string actionChoice = Console.ReadLine();

                switch (actionChoice)
                {
                    case "1":
                        _orderInterface.AddOrder();
                        break;
                    case "2":
                        _orderInterface.RemoveOrder();
                        break;
                    case "3":
                        _orderInterface.DisplayAllOrdersInfo();
                        break;
                    case "4":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }

    }
}
