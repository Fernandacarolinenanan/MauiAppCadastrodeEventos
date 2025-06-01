using MauiAppCadastrodeEventos.Models;

namespace MauiAppCadastrodeEventos.Views
{
    public partial class ResumoEventoPage : ContentPage
    {
        public Evento Evento { get; set; }
        public int Participantes { get; set; }
        public double CustoPorParticipante { get; set; }
        public double CustoTotal { get; set; }

        public ResumoEventoPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            // Fix: Replace the incorrect usage of "Parameters" with the correct way to pass and retrieve parameters.
            if (Shell.Current.CurrentState is ShellNavigationState nav)
            {
                if (Shell.Current.CurrentItem is ShellItem shellItem &&
                    shellItem.CurrentItem is ShellSection shellSection &&
                    shellSection.CurrentItem is ShellContent shellContent &&
                    shellContent.BindingContext is IDictionary<string, object> parameters)
                {
                    if (parameters.TryGetValue("Evento", out var eventoObj) &&
                        parameters.TryGetValue("Participantes", out var partObj) &&
                        parameters.TryGetValue("CustoPorParticipante", out var custoObj) &&
                        parameters.TryGetValue("CustoTotal", out var totalObj))
                    {
                        Evento = eventoObj as Evento;
                        Participantes = (int)partObj;
                        CustoPorParticipante = (double)custoObj;
                        CustoTotal = (double)totalObj;

                        BindingContext = this;
                    }
                }
            }
        }
    }
}
