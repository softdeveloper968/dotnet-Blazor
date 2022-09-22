using Contracts.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.Models
{
    public static class PaginationHelper
    {
        public static PagedResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData, PaginationFilter validFilter, int totalRecords/*, IUriService uriService*/, string route)
        {
            var respose = new PagedResponse<List<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            //respose.NextPage =
            //    validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
            //    ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
            //    : null;
            //respose.PreviousPage =
            //    validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
            //    ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
            //    : null;
            //respose.FirstPage = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route);
            //respose.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route);
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }

        //public static PagedResponse<T> CreatePaginatedResponse<T>(IUriService uriService, PaginationFilter pagination, List<T> response)
        //{
        //    var nextPage = pagination.PageNumber >= 1
        //       ? uriService.GetAllUri(new PaginationFilter(pagination.PageNumber + 1, pagination.PageSize)).ToString()
        //       : null;

        //    var previousPage = pagination.PageNumber - 1 >= 1
        //        ? uriService.GetAllUri(new PaginationFilter(pagination.PageNumber - 1, pagination.PageSize)).ToString()
        //        : null;

        //    return new PagedResponse<T>
        //    {
        //        Data = response,
        //        PageNumber = pagination.PageNumber >= 1 ? pagination.PageNumber : (int?)null,
        //        PageSize = pagination.PageSize >= 1 ? pagination.PageSize : (int?)null,
        //        NextPage = response.Any() ? nextPage : null,
        //        PreviousPage = previousPage
        //    };
        //}
    }
}
