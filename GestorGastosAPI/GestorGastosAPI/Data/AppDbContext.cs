using Microsoft.EntityFrameworkCore;
using GestorGastosAPI.Models;

namespace GestorGastosAPI.Data
{
    public class AppDbContext : DbContext // ':' indica herencia de clase 
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbContextOptions es una clase
        // <AppDbContext> es un tipo genérico, el cuál en este caso es nuestra clase.
        // options es la instancia de la clase DbContextOptions.
        // options es pasado por parámetro al constructor AppDbContext
        // ':' indica una llamada explícita al constructor de la clase base, es decir, DbContext
        // A dicha llamada exclusiva del método de la clase base, le pasamos el parámetro 'options'.

        public DbSet<Transaccion> Transacciones { get; set; }

        // 'DbSet' es una clase de EntityFramework Core que representa una tabla de una base de datos.
        // 'Transacciones' por lo tanto es una instancia de la clase DbSet que utiliza el tipo genérico 'Transaccion'
        // La clase Transaccion es conocida gracias a el using GestorGastosAPI.Models

        // LINQ parece ser la sintáxis que utiliza EntityFrameworCore para poder hacer lo que hace
        // el lenguaje SQL pero en C#

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            // Llamamos al método OnModelCreating de la clase heredada 'DbContext' para que haga
            // su configuración por defecto.

            // - Sin embargo - podes agregar reglas que complementen:

            modelBuilder.Entity<Transaccion>().Property(t => t.Descripcion).HasMaxLength(100);
            // Le pone un límite de caracteres a la descripción (por ejemplo 100)

            modelBuilder.Entity<Transaccion>().Property(t => t.Monto).IsRequired();
            // Hace que el campo 'Monto' no pueda ser nulo.

            modelBuilder.Entity<Transaccion>().Property(t => t.Monto).HasColumnType("decimal(18,2)");
            // Por defecto SQL Server usa algo como decimal(18,2) (18 dígitos totales, 2 decimales), pero EF no lo estaba
            // configurando explícitamente, entonces te avisa que si metés un número muy grande o muy preciso
            // (como 123456789012345.6789), puede truncarse o redondearse. Con ésta linea la advertencia en consola desaparece.

        }

        // OnModelCreating es un método que es llamado automáticamente por Entity Framework cuando se está creando
        // el modelo interno de cómo las clases se traducen a tablas. 

        // El parámetro modelBuilder te permite configurar reglas y relaciones personalizadas, 
        // como por ejemplo: cambiar el nombre de una tabla o columna, configurar relaciones
        // (uno a muchos, muchos a muchos), agregar restricciones (campos requeridos, longitudes máximas, etc).

        // Se le hace override al OnModelCreating para poder utilizar configuraciones personalizadas. 

        // Sino llamamos a base.OnModelCreating() podés estar saltándote configuraciones automáticas importantes
        // que EF Core hace por vos, como inferir nombres de tablas, claves primarias, relaciones básicas, etc.
        // Por eso se recomienda siempre dejarlo al principio del método, y luego poner mis reglas personalizadas,
        // que - si es necesario - pueden sobreescribir la configuraición por defecto. 
    }
}
