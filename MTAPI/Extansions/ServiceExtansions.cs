namespace MTAPI.Extansions
{
    public static class ServiceExtansions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<DataAcessLayerss.ILicenseRepository, DataAcessLayerss.LicenseRepository>();
            services.AddScoped<DataAcessLayerss.IProdutsRepository, DataAcessLayerss.ProductsRepository>();
        }

        public static void ConfigureServiceWrapper(this IServiceCollection services)
        {
            services.AddScoped<BusinessLayer.Abstrack.ILicenseServices, BusinessLayer.Concrete.LicenseServices>();
            services.AddScoped<BusinessLayer.Abstrack.IProductServices, BusinessLayer.Concrete.ProductService>();
        }
    }
}
