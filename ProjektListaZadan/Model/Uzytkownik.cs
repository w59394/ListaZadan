using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektListaZadan
{
    /// <summary>
    /// Tworzy tabelę Użytkownik w bazie danych
    /// </summary>
    public class Uzytkownik
    {
 
        [Key]
        public int UzytkownikID { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }

 
        ICollection<Zadanie> Zadania { get; set; }
    }
}
