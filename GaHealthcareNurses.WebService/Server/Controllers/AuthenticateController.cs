using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using GaHealthcareNurses.Entity.Models;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.ViewModels;
using GaHealthcareNurses.Entity.Common;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Drawing;
using Services.Helper;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Web;

namespace GaHealthcareNurses.WebService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRegistrationService _registrationService;
        private readonly ILoginService _loginService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmployerService _employerService;
        private readonly IMapper _mapper;


        public AuthenticateController(UserManager<IdentityUser> userManager, IRegistrationService registrationService, ILoginService loginService, SignInManager<IdentityUser> signInManager, IWebHostEnvironment webHostEnvironment, RoleManager<IdentityRole> roleManager, IEmployerService employerService, IMapper mapper)
        {
            this.userManager = userManager;
            _registrationService = registrationService;
            _loginService = loginService;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
            _roleManager = roleManager;
            _employerService = employerService;
            _mapper = mapper;
        }


        // POST: api/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserViewModel nurse)
        {
            try
            {
                var userExists = await userManager.FindByEmailAsync(nurse.SignUp.EmailAddress);
                if (userExists != null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "User already exists!" });

                IdentityUser user = new IdentityUser()
                {
                    UserName = nurse.SignUp.EmailAddress,
                    Email = nurse.SignUp.EmailAddress,

                    SecurityStamp = Guid.NewGuid().ToString()
                };
                Login login = new Login
                {
                    Email = nurse.SignUp.EmailAddress,
                    Password = nurse.SignUp.Password
                };

                var result = await userManager.CreateAsync(user, nurse.SignUp.Password);

                if (!result.Succeeded)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "User creation failed! Please check user details and try again." });

                await _roleManager.CreateAsync(new IdentityRole("Nurse"));
                await userManager.AddToRoleAsync(user, "Nurse");

                await _registrationService.Add(nurse, user);

                var response = await _loginService.Login(login);


                return new JsonResult(new Response<LoginViewModel<UserDetails>> { Status = "Success", Message = "Nurse created successfully!", Data = response });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/GetUserData
        //  [Authorize(Roles ="Nurse")]
        [HttpGet]
        [Route("GetUserData")]
        public async Task<IActionResult> GetRegisteredNurseData(string id)
        {
            try
            {
                var nurses = await _registrationService.GetById(id);
                if (nurses.SignUp == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Enter valid id" });
                }
                return new JsonResult(new Response<UserViewModel> { Status = "Success", Message = "Data returned successfully", Data = nurses });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // PUT: api/UpdateUser
        // [Authorize(Roles = "Nurse")]
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateRegisteredNurseData(UserViewModel registrationViewModel)
        {
            try
            {
                await _registrationService.Update(registrationViewModel);

                return new JsonResult(new Response<string> { Status = "Success", Message = "Data updated successfully" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // POST: api/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            var response = await _loginService.Login(login);

            if (response == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid Email or Password" });
            }
            return new JsonResult(new Response<LoginViewModel<UserDetails>>
            {
                Status = "Success",
                Message = "user login successfully",
                Data = response
            });
        }


        [HttpPost]
        [Route("admin")]
        public async Task<IActionResult> AdminLogin(Login login)
        {
            var response = await _loginService.AdminLogin(login);

            if (response == false)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid Email or Password" });
            }
            return new JsonResult(new Response<string>
            {
                Status = "Success",
                Message = "user login successfully"
            });
        }


        #region ForgotPassword

        /// <summary>
        /// Method for forgot password with parameter emailadress
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        // POST: api/ForgotPassword
        //[Authorize]
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ResetViewModel resetViewModel)
        {
            try
            {
                var userExists = await userManager.FindByEmailAsync(resetViewModel.Email);
                if (userExists != null)
                {
                    string Token = await userManager.GeneratePasswordResetTokenAsync(userExists);

                    AccountViewModel accountData = await _registrationService.GetAdditionalData(userExists);
                    accountData.token = Token;
                    //accountData.token = HttpUtility.UrlEncode(Token);
                    string templatePath = Environment.CurrentDirectory + @"\\EmailTemplates\ForgotPasswordTemplate.xml";
                    var message = await _registrationService.SendEmailToUser(accountData, templatePath, EmailTemplateType.Forgot.ToString());
                    if (message == true)
                        return new JsonResult(new Response<AccountViewModel> { Status = "Success", Message = "Forgot Link Sent!", Data = accountData });
                    else
                        return new JsonResult(new Response<string> { Status = "Success", Message = "Forgot Link Not Sent!" });
                }
                else
                    return new JsonResult(new Response<string> { Status = "Success", Message = "User not found" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

        #endregion


        #region ResetUserPassword

        // POST: api/ResetPassword
        /// <summary>
        /// used for reset password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        //  [Authorize]
        [Route("ResetUserPassword")]
        public async Task<IActionResult> ResetUserPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                var userData = await userManager.FindByIdAsync(resetPasswordModel.Id);
                if (userData != null)
                {
                    var status = await _registrationService.ChangePassword(userData, resetPasswordModel);
                    if (status == true)
                        return new JsonResult(new Response<string> { Status = "Success", Message = "Password reset Successfully!" });
                    else
                        return new JsonResult(new Response<string> { Status = "Success", Message = "Password not Reset Please try again!" });
                }
                else
                    return new JsonResult(new Response<string> { Status = "Success", Message = "User not found" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

        #endregion


        #region ValidateEmail
        /// <summary>
        /// Method for Validate the Emailaddress if it is exist then it will return data true otherwise it will return false
        /// </summary>
        /// <returns></returns>


        // Get: api/ValidateEmail
        [HttpGet]
        [Route("ValidateEmail")]

        public async Task<IActionResult> ValidateEmail(string emailAddress)
        {
            try
            {
                var userExists = await userManager.FindByEmailAsync(emailAddress);
                if (userExists != null)
                    return new JsonResult(new Response<string> { Status = "Success", Message = "User already exists!" });
                else
                    return new JsonResult(new Response<string> { Status = "Success", Message = "User not found" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }

        }
        #endregion


        #region Logout

        // POST: api/Logout
        //  [Authorize]
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return new JsonResult(new Response<string> { Status = "Success", Message = "Logout Successfully!" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Success", Message = ex.Message.ToString() });
            }

        }
        #endregion


        // POST: api/Register/Agency
        [HttpPost]
        [Route("Register/Agency")]
        public async Task<IActionResult> RegisterEmployer([FromForm] EmployerViewModel employer)
        {
            try
            {
                var userExists = await userManager.FindByEmailAsync(employer.EmailAddress);
                if (userExists != null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "User already exists!" });

                var employerData = _mapper.Map<Employer>(employer);
                var employerExists = await _employerService.GetByName(employerData);
                if (employerExists)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Employer already exists!" });

                IdentityUser user = new IdentityUser()
                {
                    UserName = employer.EmailAddress,
                    Email = employer.EmailAddress,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                Login login = new Login
                {
                    Email = employer.EmailAddress,
                    Password = employer.Password
                };

                var result = await userManager.CreateAsync(user, employer.Password);

                if (!result.Succeeded)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "User creation failed! Please check user details and try again." });

                await _roleManager.CreateAsync(new IdentityRole("Employer"));
                await userManager.AddToRoleAsync(user, "Employer");

                await _registrationService.AddEmployer(employer, user);

                var response = await _loginService.Login(login);

                return new JsonResult(new Response<LoginViewModel<UserDetails>> { Status = "Success", Message = "Employer created successfully!", Data = response });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // POST: api/Register/Client
        [HttpPost]
        [Route("Register/Client")]
        public async Task<IActionResult> RegisterClient([FromBody] ClientViewModel client)
        {
            try
            {
                var userExists = await userManager.FindByEmailAsync(client.EmailAddress);
                if (userExists != null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "User already exists!" });

                IdentityUser user = new IdentityUser()
                {
                    UserName = client.EmailAddress,
                    Email = client.EmailAddress,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                Login login = new Login
                {
                    Email = client.EmailAddress,
                    Password = client.Password
                };

                var result = await userManager.CreateAsync(user, client.Password);

                if (!result.Succeeded)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "User creation failed! Please check user details and try again." });

                await _roleManager.CreateAsync(new IdentityRole("Client"));
                await userManager.AddToRoleAsync(user, "Client");

                await _registrationService.AddClient(client, user);
                var response = await _loginService.Login(login);

                return new JsonResult(new Response<LoginViewModel<UserDetails>> { Status = "Success", Message = "Client created successfully!", Data = response });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("RegisterReferralNurse")]
        public async Task<IActionResult> RegisterReferralNurse([FromBody] ReferralSignUp nurseReferral)
        {
            try
            {
                var userExists = await userManager.FindByEmailAsync(nurseReferral.EmailAddress);
                if (userExists != null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "User already exists!" });
                IdentityUser user = new IdentityUser()
                {
                    UserName = nurseReferral.EmailAddress,
                    Email = nurseReferral.EmailAddress,

                    SecurityStamp = Guid.NewGuid().ToString()
                };
                Login login = new Login
                {
                    Email = nurseReferral.EmailAddress,
                    Password = nurseReferral.Password
                };
                var result = await userManager.CreateAsync(user, nurseReferral.Password);
                if (!result.Succeeded)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "User creation failed! Please check user details and try again." });

                await _roleManager.CreateAsync(new IdentityRole("Nurse"));
                await userManager.AddToRoleAsync(user, "Nurse");

                await _registrationService.AddReferralNurse(nurseReferral, user);
               
                var response = await _loginService.Login(login);

                return new JsonResult(new Response<LoginViewModel<UserDetails>> { Status = "Success", Message = "Nurse created successfully!", Data = response });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

    }
}
