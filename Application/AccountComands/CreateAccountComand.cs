using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountComands
{
    public class CreateAccountComand
    {
        public Guid IdUser { get; set; }
        public decimal Overdraft { get;}
        public decimal Balance { get;}
        public decimal MaxDepositAmountAllowed { get;}
        public Account.AccountType AccountType { get;}
        public CreateAccountComand(Guid idUser, decimal balance, Account.AccountType accountType, decimal overdraft = 0, decimal maxDepositAmountAllowed = 0)
        {
            IdUser = idUser;
            Overdraft = overdraft;
            Balance = balance;
            MaxDepositAmountAllowed = maxDepositAmountAllowed;
            AccountType = accountType;
        }

    }
}
