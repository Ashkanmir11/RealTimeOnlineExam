namespace OnlineExam.Api.Configuration
{
    public static class VersioningConfiguration
    {
        public static IServiceCollection ConfigureVersioningServices(this IServiceCollection services)
        {
            services.ConfigureOptions<ConfigureSwaggerOptions>();
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddEndpointsApiExplorer();
            return services;
        }
    }
}
