namespace Example.Entities;

public class BusinessAccount : Account
{
    public BusinessAccount(
        string number, string holder, double balance, double loanLimit) :
        base(number, holder, balance)
    {
        LoanLimit = loanLimit;
    }

    public double LoanLimit { get; private set; }

    public void Loan(double amount)
    {
        if (amount <= LoanLimit)
        {
            Balance += amount;
            LoanLimit -= amount;
        }
    }

    public sealed override void Withdraw(double amount)
    {
        Balance -= amount + 2.0;
    }

}