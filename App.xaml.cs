using SQLiteDemo.Repositories;
using SQLiteDemo.MVVM.Views;
using SQLiteDemo.MVVM.Models;

namespace SQLiteDemo;

public partial class App : Application
{
	//public static CustomerRepository CustomerRepo { get; private set; }
	public static BaseRepository<Customer> CustomerRepo { get; private set; }
	public static BaseRepository<Order> OrdersRepo { get; private set; }
	public App(BaseRepository<Customer> repo, BaseRepository<Order> ordersRepo)
	{
		InitializeComponent();
		CustomerRepo= repo;
		OrdersRepo = ordersRepo;
        MainPage = new MainPage();
	}
}
