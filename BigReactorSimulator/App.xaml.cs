using System.Windows;
using BigReactorSimulator.Resources;
using BigReactorSimulator.Views;

namespace BigReactorSimulator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            TextureHelper.LoadTextures();

            WindowManager.Initialise(this, e.Args);
            WindowManager.ShowMain();
        }
    }
}
