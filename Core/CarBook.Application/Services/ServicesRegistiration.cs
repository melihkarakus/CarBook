using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Services
{
    public static class ServicesRegistiration
    {
        // Bu metod, IServiceCollection türünde bir uzantı metodudur.
        // 'services' bağımlılıkları kaydetmek için kullanılır.
        // 'configuration' yapılandırma ayarlarını tutar.
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // MediatR kütüphanesini ekler ve MediatR hizmetlerini belirtilen derlemeden kaydeder.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServicesRegistiration).Assembly));
        }
    }
}
