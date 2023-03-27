using BasicConsoleApp;

// Creating a repository
var customerRepository = new CustomerRepository();

// Creating Customer objects
var customer1 = new Customer("John Smith");
var customer2 = new Customer("David Smith");
var customer3 = new Customer("Gary Rogers");

// Applying additional data
customer1.Age = 30;
customer2.Age = 21;

// Adding customers to the repository
customerRepository.AddNewCustomer(customer1);
customerRepository.AddNewCustomer(customer2);
customerRepository.AddNewCustomer(customer3);

// Extracting data from the repository
Console.WriteLine("The following data has been obtained while iterating through all customers:");

foreach (var customer in customerRepository.GetCustomers())
{
    Console.WriteLine($"""
    Customer id: {customer.Id},
    Customer Name: {customer.Name},
    Customer Age: {customer.Age}

    """);
}

// Extracting filtered data
Console.WriteLine("The following data has been obtained while iterating through customers while filtering by 'Smith' in name:");

foreach (var customer in customerRepository.GetCustomers("Smith"))
{
    Console.WriteLine($"""
    Customer id: {customer.Id},
    Customer Name: {customer.Name},
    Customer Age: {customer.Age}

    """);
}

// Extracting a single customer by name
Console.WriteLine("The following data was returned for David Smith:");
var specificCustomer = customerRepository.GetCustomer("David Smith");

Console.WriteLine($"""
    Customer id: {specificCustomer.Id},
    Customer Name: {specificCustomer.Name},
    Customer Age: {specificCustomer.Age}

    """);