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
        [Key]
        public int ZadanieId { get; set; }
        public string NazwaZadania { get; set; }
        public bool StatusZadania { get; set; } = false;

        [ForeignKey ("Kategoria")]
        public int KategoriaId { get; set; }
        public Kategoria Kategoria{ get; set; }


        [ForeignKey("Uzytkownik")]
        public int UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }
    }
}


