using asp_servicios.Controllers;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => {
                x.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();

            // Repositorios
            services.AddScoped<IConexion, Conexion>();
            services.AddScoped<IConsumosAplicacion, ConsumosAplicacion>();
            services.AddScoped<IDetallesReservasAplicacion, DetallesReservasAplicacion>();
            services.AddScoped<IAuditoríasAplicacion, AuditoríasAplicacion>();
            services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();
            services.AddScoped<IEmpleadosPermisosAplicacion, EmpleadosPermisosAplicacion>();
            services.AddScoped<IEmpleadosRolesAplicacion, EmpleadosRolesAplicacion>();
            services.AddScoped<IFacturasAplicacion, FacturasAplicacion>();
            services.AddScoped<IHabitacionesAplicacion, HabitacionesAplicacion>();
            services.AddScoped<IHabitacionesTiposAplicacion, HabitacionesTiposAplicacion>();
            services.AddScoped<IHuespedesAplicacion, HuespedesAplicacion>();
            services.AddScoped<IMantenimientosAplicacion, MantenimientosAplicacion>();
            services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();
            services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
            services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
            services.AddScoped<IReservasAplicacion, ReservasAplicacion>();
            services.AddScoped<IReservasServiciosAplicacion, ReservasServiciosAplicacion>();
            services.AddScoped<IRolesAplicacion, RolesAplicacion>();
            services.AddScoped<IServiciosAplicacion, ServiciosAplicacion>();
            services.AddScoped<ITiposHabitacionesAplicacion, TiposHabitacionesAplicacion>();
            //services.AddScoped<TokenAplicacion, TokenAplicacion>();
            // Controladores
            services.AddScoped<ConsumosController, ConsumosController>();
            services.AddScoped<Detalles_ReservasController, Detalles_ReservasController>();
            services.AddScoped<FacturasController, FacturasController>();
            services.AddScoped<Empleados_PermisosController, Empleados_PermisosController>();
            services.AddScoped<Empleados_RolesController, Empleados_RolesController>();
            services.AddScoped<EmpleadosController, EmpleadosController>();
            services.AddScoped<Habitaciones_TiposController, Habitaciones_TiposController>();
            services.AddScoped<HabitacionesController, HabitacionesController>();
            services.AddScoped<HuespedesController, HuespedesController>();
            services.AddScoped<MantenimientosController, MantenimientosController>();
            services.AddScoped<PermisosController, PermisosController>();
            services.AddScoped<ProductosController, ProductosController>();
            services.AddScoped<ProveedoresController, ProveedoresController>(); 
            services.AddScoped<Reservas_ServicioController, Reservas_ServicioController>();
            services.AddScoped<ReservasController, ReservasController>();
            services.AddScoped<RolesController, RolesController>();
            services.AddScoped<ServiciosController, ServiciosController>();
            services.AddScoped<Tipos_HabitacionesController, Tipos_HabitacionesController>();
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}