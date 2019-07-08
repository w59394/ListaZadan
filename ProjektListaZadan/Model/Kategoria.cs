using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektListaZadan
{
    /// <summary>
    /// Tworzy tabelę Kategoria w bazie danych
    /// </summary>
    public class Kategoria
    { 
        [Key]
        public int KategoriaId { get; set; }
        public string NazwaKategori { get; set; }
        ICollection<Zadanie> Zadanie { get; set; }
    }
}
