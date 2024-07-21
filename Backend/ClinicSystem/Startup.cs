using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicSystem.Context;
using ClinicSystem.Privilage;
using ClinicSystem.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ClinicSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddIdentity<ExtendIdentityUser, IdentityRole>(op =>
            {
                op.Password.RequiredLength = 7;
                op.Password.RequireDigit = false;
                op.Password.RequireLowercase = false;
                op.Password.RequireNonAlphanumeric = false;
                op.Password.RequireUppercase = false;
                op.User.RequireUniqueEmail = true;
                op.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                op.SignIn.RequireConfirmedEmail = true;


            }).AddDefaultTokenProviders().AddEntityFrameworkStores<DbContainer>();

            services.AddDbContextPool<DbContainer>(op => op.UseSqlServer(Configuration.GetConnectionString("con")));
            services.AddHttpContextAccessor();
            services.AddCors(options =>
            {
                options.AddPolicy("allow",
                                    a => a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                                  );

            });
            services.AddScoped<IProcessAttendance, ProcessAttendance>();
            services.AddScoped<IVacationRep, VacationRep>();
            services.AddScoped<ISetupRep, SetupRep>();
            services.AddScoped<IUserRep, UserRep>();
            services.AddScoped<IInsuranceRep, InsuranceRep>();
            services.AddScoped<IOperationRep, OperationRep>();
            services.AddScoped<IAppointmentTypeRep, AppointmentTypeRep>();
            services.AddScoped<IGenderRep, GenderRep>();
            services.AddScoped<IWorkingTimeRep, WorkingTimeRep>();
            services.AddScoped<IProcessTypeRep, ProcessTypeRep>();
            services.AddScoped<IPreAppointmentRep, PreAppointmentRep>();
            services.AddScoped<ITimeRep, TimeRep>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors();
            app.UseHsts();
            
        }
    }
}
