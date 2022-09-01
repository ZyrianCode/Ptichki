using System;
using Authentication.Core.Models;

namespace Authentication.Core.Abstractions.Data.Stores
{
    public interface IAccountStore
    {
        public event Action CurrentAccountChanged;
        public Account CurrentAccount { get; set; }
    }
}
