namespace LoymaxTest.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;

            try
            {
                var context = serviceProvider.GetRequiredService<BankDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while app initialization");
            }
        }

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder => { builder.UseStartup<Startup>(); });
    }
}