using Microsoft.Extensions.Logging;

namespace CommunyStoreFrontEnd
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    //  fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    // fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    fonts.AddFont("fa-brands-400.ttf", "FontAwesone");
                    fonts.AddFont("fa-regular-400.ttf", "FAR");
                    fonts.AddFont("fa-solid-900.ttf", "FAS");


                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
