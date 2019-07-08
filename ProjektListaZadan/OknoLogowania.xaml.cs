using System.Linq;
using System.Windows;

namespace ProjektListaZadan
{
    /// <summary>
    /// Okno logowania aplikacji
    /// </summary>
    public partial class OknoLogowania : Window
    {       
        private Context db = new Context(); // Otwiera połączenie z bazą danych
        /// <summary>
        /// Konstruktor - inicjalizuje okno logowania
        /// </summary>
        public OknoLogowania()
        {
            InitializeComponent();            
            this.DataContext = new Context();// Ustawia bazę danych jako źródło danych dla okna
        }
        /// <summary>
        /// Sprawdza dostęp do konta administratora
        /// </summary>
        /// <param name="login"></param>
        /// <param name="haslo"></param>
        /// <returns></returns>
        public static bool SprawdzUzytkownika(string login, string haslo)
        {
            if (login == "admin" && haslo == "admin")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Wywołuje proces logowania użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonZalogujSie_Click(object sender, RoutedEventArgs e)
        {            
            var uzytkownik = db.Uzytkownik.AsEnumerable().Where(x => x.Email == textBoxNazwaUzytkownika.Text).ToList().FirstOrDefault();// Pobiera użytkownika, którego dane są zgodne z podanymi podczas logowania
                                                                                                                                /// Jeślinie wpisano prosi o wprowadzenie go
            if (SprawdzUzytkownika(textBoxNazwaUzytkownika.Text, textBoxHaslo.Password))
            {                
                MainWindow mainWindow = new MainWindow();// Tworzy okno z listą zadań                
                mainWindow.Show();// Otwiera nowe okno                
                this.Close();// Zamyka okno logowania
            }
            else if (textBoxHaslo == null)
            {
                MessageBox.Show("Podaj hasło");
            }            
            else if (uzytkownik == null)// Jeśli nie ma takiego użytkownika informuje o tym
            {
                MessageBox.Show("Nie ma takiego użytkownika");
            }            
            else if (uzytkownik.Haslo != textBoxHaslo.Password)// Jeśli wprowadzono błędne hasło prosi o podanie hasła
            {
                MessageBox.Show("Błędne hasło");
            }            
            else
            {                
                MainWindow mainWindow = new MainWindow();// Tworzy okno z listą zadań                
                mainWindow.Show();// Otwiera nowe okno
                this.Close();// Zamyka okno logowania
            }
        }
    }
}
