using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Huespedes>? Huespedes { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Empleados_Roles>? Empleados_Roles { get; set; }
        public DbSet<Habitaciones>? Habitaciones { get; set; }
        public DbSet<Tipos_Habitaciones>? Tipos_Habitaciones { get; set; }
        public DbSet<Habitaciones_Tipos>? Habitaciones_Tipos { get; set; }
        public DbSet<Reservas>? Reservas { get; set; }
        public DbSet<Detalles_Reservas>? Detalles_Reservas { get; set; }
        public DbSet<Servicios>? Servicios { get; set; }
        public DbSet<Reservas_Servicios>? Reservas_Servicios { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Mantenimientos>? Mantenimientos { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Consumos>? Consumos { get; set; }
    }
}
