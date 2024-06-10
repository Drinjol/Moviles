using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunyStoreFrontEnd.Entidades;
using CommunyStoreFrontEnd.Utilitarios;
using Microsoft.Maui.Controls;

namespace CommunyStoreFrontEnd.Selectors
{
    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SenderTemplate { get; set; }
        public DataTemplate ReceiverTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as Mensaje;
            if (message == null)
                return null;

            // Aquí supón que tienes acceso a la información del usuario actual
            int currentUserId = SesionFrontEnd.usuarioSesion.Id;

            return message.idUsuario == currentUserId ? SenderTemplate : ReceiverTemplate;
        }
    }
}
