namespace Example.Entities;

public sealed class SavingsAccount : Account
{
    public SavingsAccount(
        string number, string holder, double balance, double interestRate) :
        base(number, holder, balance)
    {
        InterestRate = interestRate;
    }

    public double InterestRate { get; private set; }

    public void UpdateBalance(double amount)
    {
        Balance += Balance * InterestRate;
    }

    public override void Withdraw(double amount)
    {
        base.Withdraw(amount);
        Balance -= 2.0;
    }

}