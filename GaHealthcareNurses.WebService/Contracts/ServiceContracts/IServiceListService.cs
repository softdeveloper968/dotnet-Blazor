using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IServiceListService
    {
        Task<IEnumerable<ServiceList>> Get();
        Task<ServiceList> GetById(int id);
    }
}
