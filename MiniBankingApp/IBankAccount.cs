namespace MiniBankingApp
{
    public interface IBankAccount
    {
        string AccountName { get; }
        int AccountNumber { get; }
        string AccountType { get; }
        string Bank { get; }
        double CurrentBalance { get; }

        void DepositFunds(double amount);
        void DisplayBalance();
        void WithdrawFunds(double amount);
    }
}