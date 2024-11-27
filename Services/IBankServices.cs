namespace ServicesLab1.Services
{
    public interface IBankServices
    {
        void Deposit(int SourceAccNumber, int accountId, decimal amount);
        void Transfer(int ac1, int ac2, decimal amount);
        void Withdraw(int SourceAccNumber, int accountId, decimal amount);
    }
}