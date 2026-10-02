using TarefasApp.Models;

namespace TarefasApp;

public partial class AdicionarTarefaPage : ContentPage
{
    public AdicionarTarefaPage()
    {
        InitializeComponent();

        DataPicker.Date = DateTime.Now;
    }

    private async void Adicionar_Clicked(object sender, EventArgs e)
    {
        Tarefas novaTarefa = new Tarefas
        {
            Titulo = TituloEntry.Text,
            Descricao = DescricaoEntry.Text,
            DataCriacao = DataPicker.Date,
            Prioridade = PrioridadePicker.SelectedItem?.ToString()
        };

        MainPage.listaTarefas.Add(novaTarefa);

        await Navigation.PopModalAsync();
    }

    private async void Cancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}