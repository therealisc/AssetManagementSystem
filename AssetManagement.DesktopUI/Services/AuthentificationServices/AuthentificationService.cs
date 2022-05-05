using AssetManagement.DesktopUI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagement.Library.DataAccess;

namespace AssetManagement.DesktopUI.Services.AuthentificationServices
{
    public class AuthentificationService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly UserData _userData;

        public AuthentificationService(IPasswordHasher passwordHasher, UserData userData)
        {
            _passwordHasher = passwordHasher;
            _userData = userData;
        }

        public AccountModel Login(string username, string password)
        {
            var user = _userData.GetUserByUsername(username);

            AccountModel account = new AccountModel
            {
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                Email = user.Email, 
                Roles = user.Roles
            };

            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(account.PasswordHash, password);

            if (result != PasswordVerificationResult.Success)
            {
                throw new Exception("wrong credentials");
            }

            return account;
        }
    }
}
