namespace LoymaxTest.Web;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCustomExceptionHandler();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        app.UseHttpsRedirection();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            cfg.AddProfile(new AssemblyMappingProfile(typeof(IBankDbContext).Assembly));
        });

        services.AddPersistence(Configuration.GetConnectionString("Sqlite") ?? throw new InvalidOperationException());
        services.AddApplication();
        services.AddCors();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        services.AddServices();
        services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AppSettings:Key"] 
                    ?? throw new InvalidOperationException())),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("Token-Expired", "true");
                    }

                    return Task.CompletedTask;
                }
            };
        });

        services.AddAuthorization();
    }
}