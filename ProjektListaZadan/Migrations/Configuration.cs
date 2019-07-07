namespace ProjektListaZadan.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// Klasa utworzona automatycznie za pomoc¹ entityframework
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<ProjektListaZadan.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        /// <summary>
        /// Uzupe³niamy bazê danych przyk³adowymi danymi
        /// U³atwia to pracê z aplikacj¹
        /// W przypadku zmian nie jest konieczne ponowne wprowadzanie danych
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(ProjektListaZadan.Context context)
        {

            context.Uzytkownik.AddOrUpdate(
                p => p.Email,
                new Uzytkownik { Email = "user1@email.com", Haslo = "password" }
                );

            context.Zadanie.AddOrUpdate(
                p => p.NazwaZadania,
                new Zadanie { NazwaZadania = "Zadanie do projektu nr 1", KategoriaId = 1},
                new Zadanie { NazwaZadania = "Zadanie do projektu nr 2", KategoriaId = 1},
                new Zadanie { NazwaZadania = "Zadanie do projektu nr 3", KategoriaId = 2},
                new Zadanie { NazwaZadania = "Zadanie do projektu nr 4", KategoriaId = 1},
                new Zadanie { NazwaZadania = "Zadanie do projektu nr 5", KategoriaId = 3},
                new Zadanie { NazwaZadania = "Zadanie do projektu nr 6", KategoriaId = 2}   
                );
            context.Kategoria.AddOrUpdate(
                p => p.KategoriaId,
                new Kategoria { NazwaKategori = "Prywatne"},
                new Kategoria { NazwaKategori = "Praca"},
                new Kategoria { NazwaKategori = "Szko³a" }
                );

        }
    }
}
