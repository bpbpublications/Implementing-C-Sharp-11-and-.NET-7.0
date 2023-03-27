namespace BasicConsoleApp;

public interface ICustomerRepository
{
    int Count { get; }

    void AddNewCustomer(Customer customer);
    Customer GetCustomer(int id);
    Customer GetCustomer(string name);
    IEnumerable<Customer> GetCustomers();
    IEnumerable<Customer> GetCustomers(string nameMatch);
}

internal class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> customers;

    public CustomerRepository()
    {
        customers = new List<Customer>();
    }

    public int Count => customers.Count;

    public void AddNewCustomer(Customer customer)
    {
        customers.Add(customer);
    }

    public Customer GetCustomer(int id)
    {
        return customers.SingleOrDefault(c => c.Id == id);
    }

    public Customer GetCustomer(string name)
    {
        return customers.SingleOrDefault(c => c.Name == name);
    }

    public IEnumerable<Customer> GetCustomers()
    {
        return customers;
    }

    public IEnumerable<Customer> GetCustomers(string nameMatch)
    {
        return customers.Where(c => c.Name.Contains(nameMatch));
    }
}