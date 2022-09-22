using Newtonsoft.Json;
using System.Web.Http.Results;

namespace GaHealthcareNurses.Entity.Models
{
  public class Response<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
