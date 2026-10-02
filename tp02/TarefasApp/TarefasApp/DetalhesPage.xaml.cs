using TarefasApp.Models;

namespace TarefasApp;

public partial class DetalhesPage : ContentPage, IQueryAttributable
{
    private Tarefas tarefaSelecionada;

    public DetalhesPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        tarefaSelecionada = (Tarefas)query["Tarefa"];

        AtualizarDados();
    }

    private void AtualizarDados()
    {
        if (tarefaSelecionada != null)
        {
            TituloLabel.Text = tarefaSelecionada.Titulo;
            DescricaoLabel.Text = tarefaSelecionada.Descricao;
            DataLabel.Text = tarefaSelecionada.DataCriacao.ToString("dd/MM/yyyy");
            PrioridadeLabel.Text = tarefaSelecionada.Prioridade;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        AtualizarDados();
    }

    private async void Editar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(
            new EditarTarefaPage(tarefaSelecionada)
        );
    }

    private async void Excluir_Clicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert(
            "Excluir tarefa",
            "Deseja realmente excluir esta tarefa?",
            "Sim",
            "Não"
        );

        if (confirmar)
        {
            MainPage.listaTarefas.Remove(tarefaSelecionada);

            await Shell.Current.GoToAsync("..");
        }


    }

    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}