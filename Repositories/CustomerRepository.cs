
using SQLite;
using SQLiteDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Repositories
{
    public class CustomerRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }
        public CustomerRepository()
        {
            connection = new SQLiteConnection(Сonstans.DatabasePath, Сonstans.Flags);
            connection.CreateTable<Customer>();

        }
        public void Add(Customer newCustomer)
        {
            int result = 0;
            try
            {
                result = connection.Insert(newCustomer);
                StatusMessage = $"{result} row(s) added";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error {ex.Message}";
            }
        }
        public List<Customer> GetAll()
        {
            try
            {
                return connection.Table<Customer>().ToList();
            }
            catch (Exception ex)
            { StatusMessage = $"Error {ex.Message}"; }
            return null;
        }
        public List<Customer> GetAll2()
        {
            try
            {
                return connection.Query<Customer>("select * from Customers").ToList();
            }
            catch (Exception ex)
            { StatusMessage = $"Error {ex.Message}"; }
            return null;
        }
        public Customer Get(int id)
        {
            try {
            return connection.Table<Customer>().FirstOrDefault(x => x.Id == id);
            }
            catch(Exception ex) 
            {
                StatusMessage = $"Error {ex.Message}";
            }
            return null;
        }
        public void AddOrUpdate(Customer customer)
        {
            int result = 0;
            try
            {
                if(customer.Id == 0)
                {
                    result = connection.Insert(customer);
                }
                else
                {
                    result = connection.Update(customer);
                }
               
                StatusMessage = $"{result} row(s) updated";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error {ex.Message}";
            }
           
        }
    }
}
