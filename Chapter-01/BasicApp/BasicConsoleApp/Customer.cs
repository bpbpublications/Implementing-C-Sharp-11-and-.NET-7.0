namespace BasicConsoleApp;

public struct Customer
{
    public Customer(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public short Age { get; set; }
    public int Id => randomId;

    private int randomId = (new Random()).Next();
}