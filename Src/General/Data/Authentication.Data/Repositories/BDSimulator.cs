using System;
using System.Collections.Generic;
using Authentication.Core.Models;
using Authentication.Helpers;

namespace Ptichki.Data.Authentication.Repositories
{
    public static class BDSimulator
    {
        private static User user = new()
        {
            Email = "test",
            Username = "TestTest",
            PasswordHash = "AQAAAAEAACcQAAAAEJ+3/d7ywwmvvpXgG2HPVBZdsxVC9o5qHHj7WAmscxs3beiLxj1f30C8vbWdmjKmMQ==",
            DateJoined = DateTime.Now
        };

        public static List<Account> Accounts = new()
        {
            new Account()
            {
                AccountHolder = user,
                Balance = 0,
                PermissionGroup = PermissionGroups.Test,
                Session = SessionStatus.Test
            }
        };
    }
}
