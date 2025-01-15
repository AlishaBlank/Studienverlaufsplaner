using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Studienverlaufsplaner
{
    /// <summary>
    /// Interaktionslogik für Module.xaml
    /// </summary>
    public partial class Module : Page
    {
        
        ObservableCollection<Noteneintragung> NotenEintragung = new ObservableCollection<Noteneintragung>();

        public Module()
        {
            InitializeComponent();
            NotenListe.ItemsSource = NotenEintragung;
        }

        private void NoteHinzufuegen(object sender, RoutedEventArgs e)
        {
            var dialog = new NoteneintragungDialog();
            if (dialog.ShowDialog() == true)
            {
                var neueEintragung = new Noteneintragung
                {
                    Fach = dialog.Fach,
                    Note = dialog.Note,
                    ECTS = dialog.ECTS
                };
                NotenEintragung.Add(neueEintragung);
                UpdateECTSSumme();
                UpdateDurchschnitt();
            }
        }

        private void NoteLoeschen(object sender, RoutedEventArgs e)
        {
            if (NotenListe.SelectedItem is Noteneintragung selectedEntry)
            {
                NotenEintragung.Remove(selectedEntry);
                UpdateECTSSumme();
                UpdateDurchschnitt();
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Eintrag aus, den Sie löschen möchten.", "Kein Eintrag ausgewählt",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void NoteBearbeiten(object sender, RoutedEventArgs e)
        {
            if (NotenListe.SelectedItem is Noteneintragung selectedEntry)
            {
                var dialog = new NoteneintragungDialog(selectedEntry.Fach, selectedEntry.Note, selectedEntry.ECTS);
                if (dialog.ShowDialog() == true)
                {
                    selectedEntry.Fach = dialog.Fach;
                    selectedEntry.Note = dialog.Note;
                    selectedEntry.ECTS = dialog.ECTS;
                    NotenListe.Items.Refresh();
                    UpdateECTSSumme();
                    UpdateDurchschnitt();
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Eintrag aus, den Sie bearbeiten möchten.", "Kein Eintrag ausgewählt",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateECTSSumme()
        {
            int summe = NotenEintragung.Sum(ne => ne.ECTS);
            SummeECTS.Content = $"Summe ECTS: {summe}";
        }

        private void UpdateDurchschnitt()
        {
            if (NotenEintragung.Any())
            {
                double durchschnitt = NotenEintragung.Average(ne => ne.Note);
                NotenDurchschnittLabel.Content = $"Notendurchschnitt: {durchschnitt:F2}";
            }
            else
            {
                NotenDurchschnittLabel.Content = "Notendurchschnitt: -";
            }
        }
    }
}
