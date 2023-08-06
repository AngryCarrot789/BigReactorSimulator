using System.ComponentModel;
using System.Windows;
using BigReactorSimulator.Views.Main;

namespace BigReactorSimulator.Views
{
    public static class WindowManager
    {
        public static App Application { get; private set; }

        public static MainView MainWindow { get; private set; }
        public static NewReactorWindow NewReactor { get; private set; }

        public static bool IsInitialised { get; set; }

        // this is just how i prefer to start an application...
        // and i like it :)))))))
        // you can change it if you want...

        public static void Initialise(App app, string[] args)
        {
            if (IsInitialised)
                return;

            Application = app;

            MainWindow = new MainView();
            MainViewModel model = MainWindow.Model;

            NewReactorViewModel newReactorModel = new NewReactorViewModel(model.CreateReactorFromView);
            model.NewReactor = newReactorModel;
            model.ComponentsLoaded();
            NewReactor = new NewReactorWindow()
            {
                Model = newReactorModel
            };

            RegisterWindow(MainWindow);
            RegisterWindow(NewReactor);

            NewReactor.Model.Width = 6;
            NewReactor.Model.Length = 4;
            NewReactor.Model.Height = 3;
            model.CreateReactorFromView();

            IsInitialised = true;
        }

        private static void RegisterWindow(Window window)
        {
            window.Closing += OnWindowClosing;
        }

        public static void ShutdownApplication()
        {
            ShutdownWindows();
            Application.Shutdown();
        }

        #region Showing and closing/hiding windows

        public static void ShowMain() => ShowWindow(MainWindow);
        public static void HideMain() => HideWindow(MainWindow);

        public static void ShowNewReactor() => ShowWindow(NewReactor);
        public static void HideNewReactor() => HideWindow(NewReactor);

        public static void ShowWindow(Window window)
        {
            window.Show();
        }

        public static void HideWindow(Window window)
        {
            window.Hide();
        }

        private static void ShutdownWindows()
        {
            MainWindow.Closing -= OnWindowClosing;
            NewReactor.Closing -= OnWindowClosing;
            //MainWindow.Close();
        }

        private static void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (sender is MainView)
            {
                ShutdownApplication();
            }
            else
            {
                e.Cancel = true;
                (sender as Window)?.Hide();
            }
        }

        #endregion
    }
}
