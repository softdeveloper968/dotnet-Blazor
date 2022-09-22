using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Linq;

namespace Services
{
    public class LoginService:ILoginService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly INurseService _nurseService;
        private readonly IEmployerService _employerService;
        private readonly IClientService _clientService;
        private readonly GaHealthcareNursesContext _gaHealthcareNursesContext;

        public LoginService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, INurseService nurseService, IConfiguration configuration, IEmployerService employerService, IClientService clientService,GaHealthcareNursesContext gaHealthcareNursesContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _nurseService = nurseService;
            _configuration = configuration;
            _employerService = employerService;
            _clientService = clientService;
            _gaHealthcareNursesContext = gaHealthcareNursesContext;
        }

        public async Task<LoginViewModel<UserDetails>> Login(Login login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            UserDetails userViewModel = new UserDetails();
            string roleName=string.Empty;
            if (user == null)
            {
                return null;
            }
            var nurse = await _nurseService.GetById(user.Id);
            var employer = await _employerService.GetById(user.Id);
            var client = await _clientService.GetById(user.Id);
            if (nurse != null)
            {
                 userViewModel = new UserDetails
                {
                    UserId = user.Id,
                    Email = user.Email,
                    UserName = $"{nurse.FirstName} {nurse.LastName}"
                };
            }
            else if(employer!=null)
            {
                 userViewModel = new UserDetails
                {
                    UserId = user.Id,
                    Email = user.Email,
                    UserName = employer.Name
                };
            }
            else
            {
                userViewModel = new UserDetails
                {
                    UserId = user.Id,
                    Email = user.Email,
                    UserName = $"{client.FirstName} {client.LastName}"
                };
            }

            if (user != null && await userManager.CheckPasswordAsync(user, login.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    roleName = userRole;
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
              
                var response = new LoginViewModel<UserDetails>
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    Role= roleName,
                    UserDetails = userViewModel
                };
                return response;
            }
            return null;
        }

        public async Task<bool> AdminLogin(Login login)
        {
          return _gaHealthcareNursesContext.Admin.Where(x => x.Email == login.Email && x.Password == login.Password).Any();
          
        }
    }
}
