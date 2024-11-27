using ServicesLab1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesLab1.Models;
using Microsoft.Identity.Client;

namespace ServicesLab1.Services
{
    public class BankServices : IBankServices
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankServices(ITransactionRepository transactionRepository, IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
            _transactionRepository = transactionRepository;
        }

        public void Deposit(int SourceAccNumber, int accountId, decimal amount)
        {


            var account1 = _bankAccountRepository.GetAccountById(accountId);
            var account2 = _bankAccountRepository.GetAccountById(SourceAccNumber);
            if (account1 != null)
            {
                account1.Balance += amount;
                _bankAccountRepository.UpdateAccount(account1);

                var transaction = new Transaction
                {

                    sourceAccNumber = account2.AccountNumber,
                    operation = "Deposit",
                    amount = amount,
                    Id = accountId
                };
                _transactionRepository.AddTransaction(transaction);
            }
            else
            {
                throw new Exception("Account not found.");
            }
        }

        public void Withdraw(int SourceAccNumber, int accountId, decimal amount)
        {
            var account = _bankAccountRepository.GetAccountById(accountId);

            var account2 = _bankAccountRepository.GetAccountById(SourceAccNumber);
            if (account2 != null)
            {
                if (account2.Balance >= amount)
                {
                    account2.Balance -= amount;
                    _bankAccountRepository.UpdateAccount(account2);
                    var transaction = new Transaction
                    {

                        sourceAccNumber = account2.AccountNumber,
                        operation = "Withdraw",
                        amount = amount,
                        Id = accountId
                    };
                    _transactionRepository.AddTransaction(transaction);
                }
                else
                {
                    throw new Exception("Insufficient funds.");
                }
            }
            else
            {
                throw new Exception("Account not found.");
            }
        }
        public void Transfer(int ac1, int ac2, decimal amount)
        {
            var sourseAcc = _bankAccountRepository.GetAccountById(ac1);
            Withdraw(ac1, ac2, amount);
            Deposit(ac1, ac2, amount);
            var transaction = new Transaction
            {

                sourceAccNumber = sourseAcc.AccountNumber,
                operation = "Transfer",
                amount = amount,
                Id = ac2
            };
            _transactionRepository.AddTransaction(transaction);

        }
    }
}
