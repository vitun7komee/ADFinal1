using AUTODEALERN.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUTODEALERN.Model;

namespace AUTODEALERN.Interface
{
    internal class SalesmanInterface
    {
        private readonly ADDBStorage _dbStorage;

        public SalesmanInterface(ADDBStorage dbStorage)
        {
            _dbStorage = dbStorage;
        }
        public void AddSalesman() 
        {
            Console.WriteLine("Введите имя нового сотрудника:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите должность нового сотрудника:");
            string position = Console.ReadLine();

            Console.WriteLine("Введите контактную информацию нового сотрудника:");
            string contactInfo = Console.ReadLine();

            Salesman newSalesman = new Salesman // Создание нового объекта Employee
            {
                Name = name,
                Position = position,
                ContactInfo = contactInfo
            };

            _dbStorage.CreateSalesman(newSalesman);// Вызов метода из базы данных для добавления сотрудника
            Console.WriteLine("Сотрудник успешно добавлен.");

        }
        public void RemoveSalesman() 
        {
            Console.WriteLine("Введите ID сотрудника для удаления:");
            if (int.TryParse(Console.ReadLine(), out int salesmanId))
            {
                _dbStorage.DeleteSalesman(salesmanId);
                Console.WriteLine("Сотрудник успешно удален.");
            }
            else
            {
                Console.WriteLine("Некорректный ID сотрудника.");
            }
        }
        public void GetAllSalesmans() 
        {
            List<Salesman> salesmen = _dbStorage.GetAllSalesmans().ToList();// Получение списка сотрудников из базы данных
            if (salesmen.Count > 0)
            {
                Console.WriteLine("Список всех сотрудников:");
                foreach (var salesman in salesmen)
                {
                    Console.WriteLine($"ID: {salesman.SalesmanId}, Имя: {salesman.Name}, Должность: {salesman.Position}");
                }
            }
            else
            {
                Console.WriteLine("Список сотрудников пуст.");
            }

        }
    }
}
