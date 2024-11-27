using Microsoft.EntityFrameworkCore;
using ServicesLab1.Models;
using ServicesLab1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLab1.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return _bankAccountRepository.GetAllAccounts();
        }

        public BankAccount GetAccountById(int accountId)
        {
            return _bankAccountRepository.GetAccountById(accountId);
        }

        public void AddAccount(BankAccount account)
        {
            _bankAccountRepository.AddAccount(account);
        }

        public void UpdateAccount(BankAccount account)
        {
            var existingAccount = _bankAccountRepository.GetAccountById(account.Id);
            if (existingAccount != null)
            {
                // Update properties
                existingAccount.AccountNumber = account.AccountNumber;
                existingAccount.Balance = account.Balance;
                existingAccount.UserId = account.UserId;

                // Save changes to the database
                _bankAccountRepository.UpdateAccount(existingAccount);
            }
            else
            {
                throw new Exception("Account not found.");
            }
        }
        public void DeleteAccount(int accountId)
        {
            _bankAccountRepository.DeleteAccount(accountId);
        }

       

       
        public decimal BalanceInquiry(int accountId)
        {
            var account = _bankAccountRepository.GetAccountById(accountId);
            if (account == null)
            {
                throw new Exception("Account not found.");
            }
            return account.Balance;

            //return account?.Balance ?? throw new Exception("Account not found.");

        }


    }
}
