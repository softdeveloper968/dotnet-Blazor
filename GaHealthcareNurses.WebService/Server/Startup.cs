using AutoMapper;
using Contracts;
using Contracts.RepositoryContracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Services;
using System.Reflection;
using System.Text;

namespace GaHealthcareNurses.Server
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            //For Database Connection
            services.AddDbContext<GaHealthcareNursesContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
            services.AddControllers().AddNewtonsoftJson(options =>
          options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            #region Mapping of interfaces and classes
            services.AddScoped<INurseRepository, NurseRepository>();
            services.AddScoped<INurseService, NurseService>();
            services.AddScoped<IEmployerRepository, EmployerRepository>();
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<ITaskListRepository, TaskListRepository>();
            services.AddScoped<ITaskListService, TaskListService>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IWorkExperienceRepository, WorkExperienceRepository>();
            services.AddScoped<IWorkExperienceService, WorkExperienceService>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IEducationTypeRepository, EducationTypeRepository>();
            services.AddScoped<IEducationTypeService, EducationTypeService>();
            services.AddScoped<ICertificationRepository, CertificationRepository>();
            services.AddScoped<ICertificationService, CertificationService>();
            services.AddScoped<IReferenceRepository, ReferenceRepository>();
            services.AddScoped<IReferenceService, ReferenceService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<IHiringAggrementsRepository, HiringAggrementsRepository>();
            services.AddScoped<IHiringAggrementsService, HiringAggrementsService>();
            services.AddScoped<IUploadDocumentsRepository, UploadDocumentsRepository>();
            services.AddScoped<IUploadDocumentsService, UploadDocumentsService>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IServiceListRepository, ServiceListRepository>();
            services.AddScoped<IServiceListService, ServiceListService>();
            services.AddScoped<ICareRecipientRepository, CareRecipientRepository>();
            services.AddScoped<ICareRecipientService, CareRecipientService>();
            services.AddScoped<IPushNotificationService, PushNotificationService>();
            services.AddScoped<IJobApplyRepository, JobApplyRepository>();
            services.AddScoped<IJobApplyService, JobApplyService>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IPreferencesService, PreferencesService>();
            services.AddScoped<IWorkHistoryService, WorkHistoryService>();
            services.AddScoped<ITaskListVerificationRepository, TaskListVerificationRepository>();
            services.AddScoped<ITaskListVerificationService, TaskListVerificationService>();
            services.AddScoped<IJobTitleRepository, JobTitleRepository>();
            services.AddScoped<IJobTitleService, JobTitleService>();
            services.AddScoped<IJobInvitationService, JobInvitationService>();
            services.AddScoped<IJobApplyForAgencyRepository, JobApplyForAgencyRepository>();
            services.AddScoped<IJobApplyForAgencyService, JobApplyForAgencyService>();
            services.AddScoped<ITaskListCategoryRepository,TaskListCategoryRepository>();
            services.AddScoped<ITaskListCategoryService, TaskListCategoryService>();
            services.AddScoped<ITaskListTemplateRepository, TaskListTemplateRepository>();
            services.AddScoped<ITaskListTemplateService, TaskListTemplateService>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IBuyCoursesRepository, BuyCoursesRepository>();
            services.AddScoped<IBuyCoursesService, BuyCoursesService>();
            //services.AddScoped<IUriService>();

            #endregion

            //For Swagger
            services.AddSwaggerGen();

            //For AutoMapper
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutomapperConfig)));

            // For Identity  
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<GaHealthcareNursesContext>()
                  .AddDefaultTokenProviders();
            
            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidAudience = Configuration["JWT:ValidAudience"],
                     ValidIssuer = Configuration["JWT:ValidIssuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                 };
             });

            services.AddHttpClient();

            services.AddAuthorization();

            services.AddMvc(option => option.EnableEndpointRouting = false)
              .AddJsonOptions(jsonOptions =>
              {
                  jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                  jsonOptions.JsonSerializerOptions.WriteIndented = true;
              })
              .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc();           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "GaHealthcareNurses API");
           });
        }
    }
}
