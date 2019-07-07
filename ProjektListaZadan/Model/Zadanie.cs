using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektListaZadan
{
    /// <summary>
    /// Tworzy tabelę zadania
    /// </summary>
    public class Zadanie
    {
        /// <summary>
        /// Ustawia kolumnę ZadanieId jako Id Tabeli
        /// </summary>
        [Key]
        public int ZadanieId { get; set; }
        public string NazwaZadania { get; set; }
        public bool StatusZadania { get; set; } = false;

        /// <summary>
        /// Tworzy klucz obcy do tabeli Kategoria
        /// Taki zapis pozwala na połączenie wiele do wielu
        /// </summary>
        [ForeignKey ("Kategoria")]
        public int KategoriaId { get; set; }
        public Kategoria Kategoria{ get; set; }


        /// <summary>
        /// Tworzy klucz obcy do tabeli Użytkownik
        /// Taki zapis pozwala na połączenie wiele do wielu
        /// </summary>
        [ForeignKey("Uzytkownik")]
        public int UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }
    }
}


