using Newtonsoft.Json;
using System;
using System.Web.Http.Results;

namespace GaHealthcareNurses.Entity.Models
{
  public class LoginViewModel<T>
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Role { get; set; }
        public T UserDetails { get; set; }
    }
}
