//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Refaccionaria_DB.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RefaccionariaEntities : DbContext
    {
        public RefaccionariaEntities()
            : base("name=RefaccionariaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Accesorio> Accesorio { get; set; }
        public DbSet<Asentamiento> Asentamiento { get; set; }
        public DbSet<AutoParte> AutoParte { get; set; }
        public DbSet<AutoparteSucursal> AutoparteSucursal { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ClienteCompra> ClienteCompra { get; set; }
        public DbSet<ClienteProducto> ClienteProducto { get; set; }
        public DbSet<ClienteSucursal> ClienteSucursal { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Descuento> Descuento { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<EmpleadoProducto> EmpleadoProducto { get; set; }
        public DbSet<EquipoComputo> EquipoComputo { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<FormaPago> FormaPago { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Moviliario> Moviliario { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoCompra> ProductoCompra { get; set; }
        public DbSet<ProductoVenta> ProductoVenta { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Publicidad> Publicidad { get; set; }
        public DbSet<Quimicos> Quimicos { get; set; }
        public DbSet<QuimicosSucursal> QuimicosSucursal { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<SucursalAccesorio> SucursalAccesorio { get; set; }
        public DbSet<SucursalEmpleado> SucursalEmpleado { get; set; }
        public DbSet<SucursalEquipoComputo> SucursalEquipoComputo { get; set; }
        public DbSet<SucursalEstado> SucursalEstado { get; set; }
        public DbSet<SucursalMoviliario> SucursalMoviliario { get; set; }
        public DbSet<SucursalProveedor> SucursalProveedor { get; set; }
        public DbSet<SucursalPublicidad> SucursalPublicidad { get; set; }
        public DbSet<TipoAsentamiento> TipoAsentamiento { get; set; }
        public DbSet<TipoAsentamientoZona> TipoAsentamientoZona { get; set; }
        public DbSet<TipoAutoparte> TipoAutoparte { get; set; }
        public DbSet<TipoEmpleado> TipoEmpleado { get; set; }
        public DbSet<TipoProveedor> TipoProveedor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<VentaEmpleado> VentaEmpleado { get; set; }
        public DbSet<Zona> Zona { get; set; }
    }
}
