using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace CommunyStoreFrontEnd;

public partial class EditarPerfil : ContentPage, INotifyPropertyChanged
{
    private string nombreUsuario;
    public string NombreUsuario
    {
        get => nombreUsuario;
        set
        {
            if (nombreUsuario != value)
            {
                nombreUsuario = value;
                OnPropertyChanged();
            }
        }
    }

    private string descripcion;
    public string Descripcion
    {
        get => descripcion;
        set
        {
            if (descripcion != value)
            {
                descripcion = value;
                OnPropertyChanged();
            }
        }
    }

    private string direccion;
    public string Direccion
    {
        get => direccion;
        set
        {
            if (direccion != value)
            {
                direccion = value;
                OnPropertyChanged();
            }
        }
    }

    private string telefono;
    public string Telefono
    {
        get => telefono;
        set
        {
            if (telefono != value)
            {
                telefono = value;
                OnPropertyChanged();
            }
        }
    }

    private string emailUsuario;
    public string EmailUsuario
    {
        get => emailUsuario;
        set
        {
            if (emailUsuario != value)
            {
                emailUsuario = value;
                OnPropertyChanged();
            }
        }
    }

    public EditarPerfil(object bindingContext)
    {
        InitializeComponent();
        BindingContext = bindingContext;
        var perfil = bindingContext as PerfilDeUsuario;
        if (perfil != null)
        {
            NombreUsuario = perfil.NombreUsuario;
            Descripcion = perfil.Archivos;
            Direccion = perfil.Direccion;
            Telefono = perfil.Telefono;
            EmailUsuario = perfil.EmailUsuario;
        }
    }

    private async void GuardarInformacion_Clicked(object sender, EventArgs e)
    {
        var perfil = BindingContext as PerfilDeUsuario;
        if (perfil != null)
        {
            perfil.NombreUsuario = NombreUsuario;
            perfil.Archivos = Descripcion; // Asume que "Archivos" es la descripción
            perfil.Direccion = Direccion;
            perfil.Telefono = Telefono;
            perfil.EmailUsuario = EmailUsuario;
        }
        await DisplayAlert("Información", "Información guardada con éxito", "OK");
        await Navigation.PopAsync();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
