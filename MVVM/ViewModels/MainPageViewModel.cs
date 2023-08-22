﻿using Bogus;
using PropertyChanged;
using SQLiteDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SQLiteDemo.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public List<Customer> Customers { get; set; }
        public Customer CurrentCustomer { get; set; }
        public ICommand AddOrUpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public MainPageViewModel()
        {
            var orders = App.OrdersRepo.GetItems();
            Refresh();
            GenerateNewCustomer();
            AddOrUpdateCommand =
            new Command(async ()=>
            {
                App.CustomerRepo.SaveItem(CurrentCustomer);
                Console.WriteLine(App.CustomerRepo.StatusMessage);
                GenerateNewCustomer();
                Refresh();
            });
            DeleteCommand = new Command(() =>
            {
                App.CustomerRepo.DeleteItems(CurrentCustomer);
                Refresh();
            });
        }

        private void GenerateNewCustomer()
        {
            CurrentCustomer = new Faker<Customer>().RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x=>x.Address, f=>f.Person.Address.Street).Generate();
        }

        private void Refresh()
        {
            
            Customers = App.CustomerRepo.GetItems();
        }
    }
}
