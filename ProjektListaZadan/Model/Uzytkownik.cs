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
        /// <summary>
        /// Ustatia kolumnę UzytkownikID jako Id tabeli
        /// </summary>
        [Key]
        public int UzytkownikID { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }

        /// <summary>
        /// Tworzy klucz obcy tabeli zadania
        /// Dzieki czemu otrzymujemy listę zadań, dla danego użytkownika
        /// Zapis ICollection<Zadanie> pozwala na połączenie 1 do wielu
        /// </summary>
        ICollection<Zadanie> Zadania { get; set; }
    }
}
