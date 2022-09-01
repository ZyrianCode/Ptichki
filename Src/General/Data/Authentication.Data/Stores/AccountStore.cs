using System;
using Authentication.Core.Abstractions.Data.Stores;
using Authentication.Core.Models;

namespace Ptichki.Data.Authentication.Stores
{
    public class AccountStore : IAccountStore
    {   
        public event Action CurrentAccountChanged;

        private Account _currentAccount;
        public Account CurrentAccount
        {
            get => _currentAccount;
            set
            {
                _currentAccount = value;
                CurrentAccountChanged?.Invoke();
            }
        }
    }
}
