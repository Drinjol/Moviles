using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text;

namespace CommunyStoreFrontEnd;

public partial class ChatsList : ContentPage
{


    private List<Chats> _listaDeChats = new List<Chats>();


    //Refrezca los componentes una vez se pintan en la vista

    #region refrezcarCompomentes
    public List<Chats> listaDeChats
    {
        get { return _listaDeChats; }
        set
        {
            _listaDeChats = value;
            OnPropertyChanged(nameof(listaDeChats));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion



    public ChatsList()
	{
		InitializeComponent();
        CargarChats();
    }

    private async void CargarChats()
    {
        listaDeChats = await ChatsDelAPI();
        BindingContext = this;
    }


    private async Task<List<Chats>> ChatsDelAPI()
    {
        List<Chats> retornarChatsApi = new List<Chats>();
        

        try
        {
            ReqObtenerChats req = new ReqObtenerChats();
            req.idUsuario = SesionFrontEnd.usuarioSesion.Id;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                 var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/chats/obtenerchats", jsonContent);
               
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    ResObtenerChats res = JsonConvert.DeserializeObject<ResObtenerChats>(responseContent);

                    if (res.resultado)
                    {
                        retornarChatsApi = res.chats;
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el API");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error interno");
        }

        return retornarChatsApi;
    }

    private void OnChatItemTapped(object sender, EventArgs e)
    {
        var tappedFrame = sender as Frame;
        var chat = tappedFrame?.BindingContext as Chats;

        if (chat != null)
        {
            metodo_VerMensajes_Clicked(chat.idChat);

            // Deselecciona el elemento después de manejar el tap
            collectionView.SelectedItem = null;
        }
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var selectedChat = e.CurrentSelection[0] as Chats;
            if (selectedChat != null)
            {
                metodo_VerMensajes_Clicked(selectedChat.idChat);

                // Deselecciona el elemento después de manejar la selección
                collectionView.SelectedItem = null;
            }
        }
    }


    private void metodo_VerMensajes_Clicked(int idChat)
    {
        Navigation.PushAsync(new ListaMensajes(idChat));
    }



}