using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektListaZadan
{
    /// <summary>
    /// Kontekst bazy danych
    /// Pozwala na połączenie odpowiednich klas w c# z ich odpowiednikami w bazie danych
    /// Umożliwa działanie na danych z bazy danych
    /// </summary>
    public class Context: DbContext
    {
        public DbSet<Kategoria> Kategoria { get; set; }
        public DbSet<Uzytkownik> Uzytkownik { get; set; }
        public DbSet<Zadanie> Zadanie{ get; set; } 
    }
}
