using AUTODEALERN.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTODEALERN.DAL
{
    internal class ADDBStorage
    {
        private readonly ADContext _context;

        public ADDBStorage(ADContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void CreateMenuItem(MenuItem menuItem) 
        {
            _context.MenuItemDb.Add(menuItem);
            _context.SaveChanges();
        }
        public MenuItem GetMenuItemById(int id) 
        {
            return _context.MenuItemDb.FirstOrDefault(item => item.MenuItemId == id);
        }
        public IQueryable<MenuItem> GetAllMenuItems()
        {
            return _context.MenuItemDb;
        }
        public void UpdateMenuItem(MenuItem menuItem) 
        {
            var existingMenuItem = GetMenuItemById(menuItem.MenuItemId);

            if (existingMenuItem != null)
            {
                existingMenuItem.Name = menuItem.Name;
                existingMenuItem.Description = menuItem.Description;
                existingMenuItem.Price = menuItem.Price;
                existingMenuItem.Category = menuItem.Category;

                _context.SaveChanges();
            }
        }
        public void DeleteMenuItem(int id) 
        {
            var menuItem = _context.MenuItemDb.FirstOrDefault(item => item.MenuItemId == id);
            if (menuItem != null)
            {
                _context.MenuItemDb.Remove(menuItem);
                _context.SaveChanges();
            }
        }

        public void CreateSalesman(Salesman salesman) 
        {
            _context.SalesmanDb.Add(salesman);
            _context.SaveChanges();
        }
        public Salesman GetSalesmanById(int id) 
        {
            return _context.SalesmanDb.FirstOrDefault(slm => slm.SalesmanId == id);
        }
        public IQueryable<Salesman> GetAllSalesmans() 
        {
            return _context.SalesmanDb;
        }
        public void UpdateSalesman(Salesman salesman)
        {
            var existingSalesman = GetSalesmanById(salesman.SalesmanId);

            if (existingSalesman != null)
            {
                existingSalesman.Name = salesman.Name;
                existingSalesman.Position = salesman.Position;
                existingSalesman.ContactInfo = salesman.ContactInfo;

                _context.SaveChanges();
            }
        }
        public void DeleteSalesman(int id) 
        {
            var salesman = _context.SalesmanDb.FirstOrDefault(slm => slm.SalesmanId == id);
            if (salesman != null)
            {
                _context.SalesmanDb.Remove(salesman);
                _context.SaveChanges();
            }
        }
        public void CreateClient(Client client)
        {
            _context.ClientDb.Add(client);
            _context.SaveChanges();
        }
        public Client GetClientById(int id) 
        {
            return _context.ClientDb.FirstOrDefault(c => c.ClientId == id);
        }

        public IQueryable<Client> GetAllClients() 
        {
            return _context.ClientDb;
        }

        //public List<Client> GetNewClients() //t?
        //{
        //    List<Client> newClients = _context.ClientDb.Where(c => c.Status == "Свободен").ToList();
        //    return newClients;
        //}
        public void UpdateClient(Client client) 
        {
        var existingClient = GetClientById(client.ClientId);
            if (existingClient != null)
            {
                existingClient.ClientNumber = client.ClientNumber;
                //existingClient.Status = client.Status;
                existingClient.Name = client.Name; // reform
                _context.SaveChanges();

            }
        }
        //public void UpdateClientStatus(int clientId, string status) 
        //{ 
        //Client clientToUpdate = _context.ClientDb.FirstOrDefault(c => c.ClientId == clientId);
        //    if (clientToUpdate != null)
        //    {
        //        clientToUpdate.Status = status;
        //        _context.SaveChanges();

        //    }
        //    else 
        //    {

        //        Console.WriteLine("Клиент с указанным ID не найден.");
        //    }
        //}
        public void DeleteClient(int id) 
        {
            var client = _context.ClientDb.FirstOrDefault(clt => clt.ClientId == id);
            if (client != null) 
            {
                _context.ClientDb.Remove(client);
                _context.SaveChanges();
            
            }
        }
        public void CreateOrder(Order newOrder)
        {
            _context.OrderDb.Add(newOrder);
            _context.SaveChanges();
        
        }
        public Order GetOrderById(int orderId)
        {
            return _context.OrderDb.FirstOrDefault(o => o.OrderId == orderId);
        
        }
        public IQueryable<Order> GetAllOrders()
        {
            return _context.OrderDb;
        }
        public void UpdateOrder(Order updatedOrder) 
        {
            var existingOrder = _context.OrderDb.Find(updatedOrder.OrderId);
            if (existingOrder != null)
            {
                existingOrder.OrderDateTime = updatedOrder.OrderDateTime;
                existingOrder.EmployeeId = updatedOrder.EmployeeId;
                existingOrder.ClientId = updatedOrder.ClientId;
                //existingOrder.Status = updatedOrder.Status;
                existingOrder.MenuItemId = updatedOrder.MenuItemId;

                _context.SaveChanges();
            }
        
        }
        public void DeleteOrder(int orderId)
        {
            var orderToDelete = _context.OrderDb.Find(orderId);
            if (orderToDelete != null)
            {
                _context.OrderDb.Remove(orderToDelete);
                _context.SaveChanges();
            }
        }
    }
}
