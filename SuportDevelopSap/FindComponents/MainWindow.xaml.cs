using SAPFEWSELib;
using SapROTWr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;

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
                Wpf.Ui.Controls.MessageBox messageBox = new Wpf.Ui.Controls.MessageBox();

                MessageBox.Show("Não foi possível localizar o componente.", "Alerta!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }   
        }
    }
}
