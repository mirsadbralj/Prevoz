using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Feedback;
using Prevoz.MobileApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Prevoz.Model;

namespace Prevoz.MobileApp.ViewModels
{
    public class LeaveFeedbackViewModel : BaseViewModel
    {
        private readonly ApiService _feedback = new ApiService("feedback");
        public ObservableCollection<int> listaOcjena { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<Feedback> listFeedback { get; set; } = new ObservableCollection<Feedback>();
        public LeaveFeedbackViewModel()
        {
            InsertCommand = new Command(async () => await Insert());
        }
        public int ocjena = 0;
        public string Komentar = string.Empty;
        public ICommand InsertCommand {get; set;}
        public int Ocjena
        {
            get { return ocjena; }
            set { SetProperty(ref ocjena, value); }
        }
        public string komentar
        {
            get { return Komentar; }
            set { SetProperty(ref Komentar, value); }
        }
        public void LoadCollectionListaOcjena()
        {
            for (int i = 1; i <= 5; i++)
                listaOcjena.Add(i);
        }
        public async Task LoadCollectionFeedbacks()
        {
            var feedbacks = await _feedback.Get<List<Feedback>>(null);

            foreach(Feedback feedback in feedbacks)
            {
                listFeedback.Add(feedback);
            }
        }
        public async Task Insert()
        {
            var korisnik = Memorija.Korisnik;
            var FeedBackREquest = new FeedbackUpsertRequest()
            {
                KorisnikId = korisnik.KorisnikId,
                Ocjena = Ocjena,
                Komentar = komentar
            };
            await _feedback.Insert<Model.Feedback>(FeedBackREquest);

            await Application.Current.MainPage.DisplayAlert("Vaša ocjena je memorisana.", "Hvala", "OK");
        }
    }
}