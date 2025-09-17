using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Huespedes>? Huespedes { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Roles>? Roles { get; set; }
        DbSet<Empleados_Roles>? Empleados_Roles { get; set; }
        DbSet<Habitaciones>? Habitaciones { get; set; }
        DbSet<Tipos_Habitaciones>? Tipos_Habitaciones { get; set; }
        DbSet<Habitaciones_Tipos>? Habitaciones_Tipos { get; set; }
        DbSet<Reservas>? Reservas { get; set; }
        DbSet<Detalles_Reservas>? Detalles_Reservas { get; set; }
        DbSet<Servicios>? Servicios { get; set; }
        DbSet<Reservas_Servicios>? Reservas_Servicios { get; set; }
        DbSet<Facturas>? Facturas { get; set; }
        DbSet<Mantenimientos>? Mantenimientos { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Productos>? Productos { get; set; }
        DbSet<Consumos>? Consumos { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}