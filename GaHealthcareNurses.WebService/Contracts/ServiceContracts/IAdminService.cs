﻿using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAdmins();
        Task<Admin> GetAdminById(int id);
    }
}
