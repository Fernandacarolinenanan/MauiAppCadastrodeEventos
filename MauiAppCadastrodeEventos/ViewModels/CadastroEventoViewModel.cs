using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MauiAppCadastrodeEventos.Models;
using MauiAppCadastrodeEventos.Views;

namespace MauiAppCadastrodeEventos.ViewModels
{
    public class CadastroEventoViewModel : INotifyPropertyChanged
    {
        public Evento Evento { get; set; } = new Evento();

        private string numeroParticipantes;
        public string NumeroParticipantes
        {
            get => numeroParticipantes;
            set
            {
                numeroParticipantes = value;
                OnPropertyChanged();
            }
        }

        private string custoPorParticipante;
        public string CustoPorParticipante
        {
            get => custoPorParticipante;
            set
            {
                custoPorParticipante = value;
                OnPropertyChanged();
            }
        }

        public ICommand CadastrarEventoCommand { get; }

        public CadastroEventoViewModel()
        {
            Evento.DataInicio = DateTime.Now;
            Evento.DataTermino = DateTime.Now.AddDays(1);

            CadastrarEventoCommand = new Command(async () =>
            {
                int participantes = int.TryParse(NumeroParticipantes, out var p) ? p : 0;
                double custo = double.TryParse(CustoPorParticipante, out var c) ? c : 0;

                double total = Evento.CustoTotal(participantes, custo);

                await Shell.Current.GoToAsync(nameof(ResumoEventoPage), true, new Dictionary<string, object>
                {
                    { "Evento", Evento },
                    { "Participantes", participantes },
                    { "CustoPorParticipante", custo },
                    { "CustoTotal", total }
                });
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string nome = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
        }
    }
}
