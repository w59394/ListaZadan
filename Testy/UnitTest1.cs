using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjektListaZadan;

namespace Testy
{/// <summary>
/// Testowanie wybranych metod
/// </summary>
    [TestClass]
    public class UnitTest1
    {
        private string login;
        private string haslo;
        private bool expected;

        [TestMethod]
        public void AdminDostepTak()
        {
            // Arrange
            
            login = "admin";
            
            haslo = "admin";

            expected = true;


            // Act
            OknoLogowania.SprawdzUzytkownika(login, haslo);

            // Assert
            bool actual = OknoLogowania.SprawdzUzytkownika(login, haslo);
            Assert.AreEqual(expected, actual, "Elementy porównywane nie są zgodne");
        }

        [TestMethod]
        public void AdminDostepNie()
        {
            // Arrange

            login = "user1";

            haslo = "user1";

            expected = false;


            // Act
            OknoLogowania.SprawdzUzytkownika(login, haslo);

            // Assert
            bool actual = OknoLogowania.SprawdzUzytkownika(login, haslo);
            Assert.AreEqual(expected, actual, "Elementy porównywane nie są zgodne");
        }   
  
    }
}
