using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Entidades.Response;
using CommunyStoreFrontEnd.Utilitarios;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text;

namespace CommunyStoreFrontEnd;

public partial class ListaDeseos : ContentPage, INotifyPropertyChanged
{

    private List<PublicacionGuardada> _listaPublicacionesGuardadas = new List<PublicacionGuardada>();

    public List<PublicacionGuardada> listaDePublicacionesGuardadas
    {
        get { return _listaPublicacionesGuardadas; }
        set
        {
            _listaPublicacionesGuardadas = value;
            OnPropertyChanged(nameof(listaDePublicacionesGuardadas));
        }
    }



    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    public ListaDeseos()
	{
		InitializeComponent();
        CargarPublicaciones();

    }


    public async void CargarPublicaciones()
    {
        listaDePublicacionesGuardadas = await publicacionesGuardadasDelApi();
        BindingContext = this;
    }

    private async Task<List<PublicacionGuardada>> publicacionesGuardadasDelApi()
    {
        List<PublicacionGuardada> retornarPublicacionGuardadasApi = new List<PublicacionGuardada>();
        

        try
        {
            
            ReqObtenerPublicacionesGuardadas req = new ReqObtenerPublicacionesGuardadas();

            req.usuarioid = SesionFrontEnd.usuarioSesion.Id;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(API_LINK.link + "CommunyStoreApi/publicacion/obtenerPublicacionGuardadas", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    // Imprimir el contenido de la respuesta para verificar
                    Console.WriteLine(responseContent);

                    // Intenta deserializar el JSON
                    try
                    {

                        ResObtenerPublicacionesGuardadas res = JsonConvert.DeserializeObject<ResObtenerPublicacionesGuardadas>(responseContent);
                        if (res.resultado)
                        {


                            retornarPublicacionGuardadasApi = res.listaPublicacionGuardada;

                        }
                        else
                        {
                            DisplayAlert("No se encontró el backend", "Error con la API", "ACEPTAR");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejar excepciones al deserializar el JSON
                        Console.WriteLine("Error al deserializar JSON: " + ex.Message);
                    }
                }
                else
                {
                    // Manejar código de estado de respuesta incorrecto
                    Console.WriteLine("Código de estado de respuesta incorrecto: " + response.StatusCode);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error interno", "ERROR CON BACKEND", "ACEPTAR");
        }


        return retornarPublicacionGuardadasApi;
    }

    private void Button_Clicked_delete_publicacion_guardada(object sender, EventArgs e)
    {
        
    }

    private void Button_Clicked_contactar_usuario(object sender, EventArgs e)
    {

    }



}