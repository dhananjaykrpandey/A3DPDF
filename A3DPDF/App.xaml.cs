
namespace A3DPDF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            StyleManager.ApplicationTheme = new FluentTheme();
            ClsMessage._IClsMessage.MsgHeader = "A3D PDF";
            //GDALProjectPropertyClass.IGProjectPropertyClass.GStrConnectionStrings = System.Configuration.ConfigurationManager.ConnectionStrings["A3DMarketing"].ConnectionString;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //WinMainMDI Obj = new WinMainMDI();
            //Obj.Show();
            A3DPDF.Shared.UI.MainWindow _winLogin = new();

            _winLogin.Show();
        }
    }
}
