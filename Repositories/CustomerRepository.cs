
using SQLite;
using SQLiteDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            catch(Exception ex)
            {
                StatusMessage = $"Error {ex.Message}";
            }
        }
    }
}
