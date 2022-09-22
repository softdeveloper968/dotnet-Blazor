using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
  public interface ILoginService
    {
        public Task<LoginViewModel<UserDetails>> Login(Login login);
        public Task<bool> AdminLogin(Login login);
    }
}
