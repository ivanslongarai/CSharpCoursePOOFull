namespace Example.Entities;

public class Account
{
    public Account(string number, string holder, double balance)
    {
        Number = number;
        Holder = holder;
        Balance = balance;
    }

    public string Number { get; private set; }
    public string Holder { get; private set; }
    public double Balance { get; protected set; }

    public virtual void Withdraw(double amount)
    {
        Balance -= amount + 5.0;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

}