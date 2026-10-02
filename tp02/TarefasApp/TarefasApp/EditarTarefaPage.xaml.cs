namespace TarefasApp;
using TarefasApp.Models;

public partial class EditarTarefaPage : ContentPage
{
    private Tarefas tarefa;
    public EditarTarefaPage(Tarefas tarefa)
    {
        InitializeComponent();

        this.tarefa = tarefa;

        TituloEntry.Text = tarefa.Titulo;
        DescricaoEntry.Text = tarefa.Descricao;
        DataPicker.Date = tarefa.DataCriacao;
        PrioridadePicker.SelectedItem = tarefa.Prioridade;
    }

    private async void Salvar_Clicked(object sender, EventArgs e)
    {
        tarefa.Titulo = TituloEntry.Text;
        tarefa.Descricao = DescricaoEntry.Text;
        tarefa.DataCriacao = DataPicker.Date;
        tarefa.Prioridade = PrioridadePicker.SelectedItem?.ToString();

        await Navigation.PopModalAsync();
    }

    private async void Cancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

}