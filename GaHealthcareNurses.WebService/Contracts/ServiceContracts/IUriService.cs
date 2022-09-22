using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.ServiceContracts
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
