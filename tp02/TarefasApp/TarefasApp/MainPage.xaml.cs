using TarefasApp.Models;

namespace TarefasApp
{
    public partial class MainPage : ContentPage
    {
        public static List<Tarefas> listaTarefas;

        public MainPage()
        {
            InitializeComponent();

            listaTarefas = new List<Tarefas>();

            Tarefas tarefa1 = new Tarefas();

            tarefa1.Titulo = "Estudar";
            tarefa1.Descricao = "Estudar .NET MAUI";
            tarefa1.DataCriacao = DateTime.Now;
            tarefa1.Prioridade = "Alta";

            listaTarefas.Add(tarefa1);

            ListaTarefasView.ItemsSource = listaTarefas;
        }

        private async void ListaTarefasView_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
                return;

            Tarefas tarefaSelecionada =
                (Tarefas)e.CurrentSelection[0];

            Dictionary<string, object> parametros =
                new Dictionary<string, object>();

            parametros.Add("Tarefa", tarefaSelecionada);

            ListaTarefasView.SelectedItem = null;

            await Shell.Current.GoToAsync(
                "DetalhesPage",
                parametros
            );
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ListaTarefasView.ItemsSource = null;
            ListaTarefasView.ItemsSource = listaTarefas;
        }

        private async void Adicionar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(
                new AdicionarTarefaPage()
            );
        }
    }
}