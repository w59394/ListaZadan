using System.Linq;
using System.Windows;

namespace ProjektListaZadan
{
    /// <summary>
    /// Logika dla okna logowania
    /// </summary>
    public partial class OknoLogowania : Window
    {
        /// <summary>
        /// Otwiera połączenie z bazą danych
        /// </summary>
        private Context db = new Context();
        /// <summary>
        /// Inicjalizuje okno logowania
        /// </summary>
        public OknoLogowania()
        {
            InitializeComponent();
            /// Ustawia bazę danych jako źródło danych dla okna
            this.DataContext = new Context();
        }

        /// <summary>
        /// Wywołuje proces logowania użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonZalogujSie_Click(object sender, RoutedEventArgs e)
        {
            /// Pobiera użytkownika, którego dane są zgodne z podanymi podczas logowania
            var uzytkownik = db.Uzytkownik.AsEnumerable().Where(x => x.Email == textBoxNazwaUzytkownika.Text).ToList().FirstOrDefault();
            /// Jeślinie wpisano prosi o wprowadzenie go
            if (textBoxHaslo == null)
            {
                MessageBox.Show("Podaj hasło");
            }
            /// Jeśli nie ma takiego użytkownika informuje o tym
            else if (uzytkownik == null)
            {
                MessageBox.Show("Nie ma takiego użytkownika");
            }
            /// Jeśli wprowadzono błędne hasło prosi o podanie hasła
            else if (uzytkownik.Haslo != textBoxHaslo.Password)
            {
                MessageBox.Show("Błędne hasło");
            }
            /// Jeśli wszystkie warunki zostały spełnione, loguje użytkownika i otwiera okno z listą zadań
            else
            {
                /// Tworzy okno z listą zadań
                MainWindow mainWindow = new MainWindow();
                /// Otwiera nowe okno
                mainWindow.Show();
                /// Zamyka okno logowania
                this.Close();
            }




        }
    }
}
