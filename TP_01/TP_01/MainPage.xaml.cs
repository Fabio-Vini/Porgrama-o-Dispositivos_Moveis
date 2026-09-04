namespace TP_01;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnOkClicked(object sender, EventArgs e)
    {
        if (entryId.Text == "admin" && entrySenha.Text == "senha@dmin")
        {
            await DisplayAlert("Login", "Logado com sucesso!", "OK");
        }
        else
        {
            await DisplayAlert("Login", "Login não autorizado.", "OK");
        }
    }

    private void OnLimparClicked(object sender, EventArgs e)
    {
        entryId.Text = "";
        entrySenha.Text = "";

        entryId.Focus();
    }

    private async void OnCreditosClicked(object sender, EventArgs e)
    {
        await DisplayAlert(
            "Créditos",
            "Desenvolvido por: Fábio Vinicius e Kauã Felipe",
            "OK");
    }
}