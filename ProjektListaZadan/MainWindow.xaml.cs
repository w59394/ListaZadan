using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace ProjektListaZadan
{
    /// <summary>
    /// Okno główne aplikacji - odpowiada za odświeżanie widoków, pobieranie, tworzenie i edycje danych
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Konstruktor - tworzy główne okno
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();            
            listaZadanGrid.ItemsSource = PobierzZadania();// Przypisuje wszystkie zadania do DataGrid listaZadanGrid, który je wyświetla
        }
      
        public List<Zadanie> mojeZadania = new List<Zadanie>();// Przechowuje listę zadań

        /// <summary>
        /// Pobiera listę wszystkich zadań
        /// </summary>
        /// <returns>mojeZadania</returns>
        private List<Zadanie> PobierzZadania()
        {
            /// Otwiera połączenie z bazą danych
            var db = new Context();

            mojeZadania = db.Zadanie.AsEnumerable().ToList();
            return mojeZadania;

        }
        /// <summary>
        /// Pobiera zadania wykonane
        /// </summary>
        /// <returns>Zadania wykonane</returns>
        private List<Zadanie> PobierzZadaniaWykonane()
        {
            /// Otwiera połączenie z bazą danych
            var db = new Context();

            mojeZadania = db.Zadanie.Where(x => x.StatusZadania == true).AsEnumerable().ToList();
            return mojeZadania;

        }
        /// <summary>
        /// Pobiera zadania niewykonane
        /// </summary>
        /// <returns>Zadania niewykonane</returns>
        private List<Zadanie> PobierzZadaniaNieWykonane()
        {
            /// Otwiera połączenie z bazą danych
            var db = new Context();

            mojeZadania = db.Zadanie.Where(x => x.StatusZadania == false).AsEnumerable().ToList();
            return mojeZadania;

        }
        /// <summary>
        /// Pobiera listęzadań z danej kategori
        /// </summary>
        /// <param name="idKategori"></param>
        /// <returns>Zadania z kategori</returns>
        public List<Zadanie> PobierzZadaniaZKategori(int idKategori)
        {            
            var db = new Context();// Otwiera połączenie z bazą danych
            var mojeZadania = db.Zadanie.Where(x => x.KategoriaId == idKategori).Where(x => x.StatusZadania == false).AsEnumerable().ToList();
            return mojeZadania;
        }

        /// <summary>
        /// Wyświetla zadania z kategorii prywatne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zadaniaPrywatne_Click(object sender, RoutedEventArgs e)
        {

            var idKategori = 1;
            listaZadanGrid.ItemsSource = PobierzZadaniaZKategori(idKategori);

        }
        /// <summary>
        /// Wyśiwetla zadania z kategori praca
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zadaniaPraca_Click(object sender, RoutedEventArgs e)
        {
            var idKategori = 2;
            listaZadanGrid.ItemsSource = PobierzZadaniaZKategori(idKategori);

        }
        /// <summary>
        /// Wyświetla zadania z kategori szkoła
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zadaniaszkola_Click(object sender, RoutedEventArgs e)
        {
            var idKategori = 3;
            listaZadanGrid.ItemsSource = PobierzZadaniaZKategori(idKategori);

        }
        /// <summary>
        /// Wyświetla wykonane zadania
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zadaniaWykonane_Click(object sender, RoutedEventArgs e)
        {
            listaZadanGrid.ItemsSource = PobierzZadaniaWykonane();
        }
        /// <summary>
        /// Wyświetla zadania niewykonane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zadaniaNieWykonane_Click(object sender, RoutedEventArgs e)
        {
            listaZadanGrid.ItemsSource = PobierzZadaniaNieWykonane();

        }
        /// <summary>
        /// Wyświetla wszystkie zadania
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wszystkieZadania_Click(object sender, RoutedEventArgs e)
        {
            listaZadanGrid.ItemsSource = PobierzZadania();
        }

        /// <summary>
        /// Dodaje nowe zadanie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dodajZadanie_Click(object sender, RoutedEventArgs e)
        {            
            var db = new Context();// Otwiera połączenie z bazą danych
            Zadanie zadanie = new Zadanie();
                        
            zadanie.NazwaZadania = this.nazwaZadaniaTextBox.Text;// Przypisuje wartość z pola nazwaZadaiaTextBox, do nowego zadania

            var intParse = this.kategoriaZadaniaTextBox.Text;// Pobiera kategorie zadania
            
            zadanie.KategoriaId = Int32.Parse(intParse);// Konwertuje kategorie zadania na int - tak jest reprezentowana w bazie danych
            
            zadanie.StatusZadania = false;// Ustawia status nowego zadania jako niewykonane
            
            var stareZadania = PobierzZadania().LastOrDefault();// Pobiera Id ostatniego zadania
            
            int stareId = stareZadania.ZadanieId;// Przypisuje Id ostatniego zadania
            
            zadanie.ZadanieId = stareId + 1;// Zwiększa stareId o 1 i przypisuje je do nowego zadania
            
            zadanie.UzytkownikId = 1;// Przydziela Id użytkownika
            
            db.Zadanie.Add(zadanie);// Dodaje i zapisuje zadanie
            db.SaveChanges();
                        
            string wiadomosc = this.nazwaZadaniaTextBox.Text;// Wyświetla wiadomość po dodaniu zadania
            MessageBox.Show("Poprawnie dodano zadanie: " + wiadomosc);
        }
    }
}
