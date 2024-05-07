
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NZZwalks.DataContext;
using NZZwalks.Mapping;
using NZZwalks.RegionRepository;
using NZZwalks.WalkRepository;
using System.Transactions;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using NZZwalks.AccountRepository;
using NZZwalks.TokenRepository;
using Microsoft.OpenApi.Models;
using NZZwalks.ImageRepository;
using Microsoft.Extensions.FileProviders;

namespace NZZwalks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //add authorization header
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "NzWalks Ap2", Version = "v1" });
                opt.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                            
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            },
                            Scheme = "Oauth2",
                            Name = JwtBearerDefaults.AuthenticationScheme,
                            In = ParameterLocation.Header

                        },
                        new List<string>() 
                    }
                });
            });


            builder.Services.AddDbContext<AccountContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));
            builder.Services.AddTransient<IRegionRepo, RegionRepo>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
            builder.Services.AddTransient<IWalkRepo, WalkRepo>();
            builder.Services.AddTransient<IAccountRepo, AccountRepo>();
            builder.Services.AddTransient<ITokenRepo, TokenRepo>();
            builder.Services.AddTransient<IimageRepo, ImageRepo>();

            builder.Services.AddDbContext<AuthDbcontext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("dbcauth")));

          /*  builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NzWalks")
                .AddEntityFrameworkStores<AuthDbcontext>()
                .AddDefaultTokenProviders();*/

			builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NZZwalks")
				.AddEntityFrameworkStores<AuthDbcontext>()
				.AddDefaultTokenProviders()
                .AddSignInManager<SignInManager<IdentityUser>>();

			//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AccountContext>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("SoftStacksApi").AddDefaultTokenProviders();

			builder.Services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequiredUniqueChars = 1;
            });


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options=>options.TokenValidationParameters=new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
			app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

			app.MapControllers();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
                RequestPath ="/Images",
            });


            app.Run();
        }
    }
}
