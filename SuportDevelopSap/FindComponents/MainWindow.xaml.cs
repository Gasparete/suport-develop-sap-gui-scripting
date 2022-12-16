using SAPFEWSELib;
using SapROTWr;
using System;
using System.Windows;

namespace FindComponents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Wpf.Ui.Controls.UiWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnIdentify_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CSapROTWrapper sapROTWrapper = new();
                object sapGuilRot = sapROTWrapper.GetROTEntry("SAPGUI");
                GuiApplication application = (GuiApplication)sapGuilRot.GetType().InvokeMember("GetScriptingEngine", System.Reflection.BindingFlags.InvokeMethod, null, sapGuilRot, null);
                GuiConnection conn = application.Connections.Item(0) as GuiConnection;
                GuiSession ses = conn.Sessions.Item(0) as GuiSession;
                ((GuiVComponent)ses.FindById(txtIdentify.Text)).SetFocus();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível localizar o componente.", "Alerta!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
