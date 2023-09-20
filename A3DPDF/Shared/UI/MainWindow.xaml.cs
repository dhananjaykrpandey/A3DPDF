
namespace A3DPDF.Shared.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WinMainWindows_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void RdNavItemNewMessage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RadNavigationViewItem radNavigationViewItem = e.OriginalSource as RadNavigationViewItem;
                if (radNavigationViewItem != null && radNavigationViewItem.Tag != null && radNavigationViewItem.Tag.ToString().Trim() != "")
                {
                    OpenForms(radNavigationViewItem.Tag.ToString(), radNavigationViewItem.Content.ToString(), radNavigationViewItem.Icon);
                }

            }
            catch (Exception ex)
            {

                ClsMessage._IClsMessage.ShowError(ex);
            }
            //UcAddContact ucAddContact = new UcAddContact();
            //RdNavViewMain.Content = ucAddContact;
        }
        private void OpenForms(string FormName, string FormTitle, object Icon)
        {
            try
            {
                RadTabItem? radTabItem = IsFormOpen(FormName, FormTitle);
                if (radTabItem != null)
                {
                    TabMainContent.SelectedItem = radTabItem;
                    return;
                }
                StackPanel stackPanel = new();
                stackPanel.Name = $"Stck{FormName}";
                TextBlock textBlock = new();
                textBlock.Text = FormTitle;
                textBlock.Margin = new Thickness(5, 0, 5, 0);
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Center;

                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.Children.Add(UIElement(Icon));
                stackPanel.Children.Add(textBlock);
                radTabItem = new()
                {
                    Name = $"radTabItem_{FormName}",
                    Header = stackPanel,
                    CloseButtonVisibility = Visibility.Visible,


                };
                radTabItem.Content = LoadForm(FormName);
                TabMainContent.Items.Add(radTabItem);
                this.TabMainContent.SelectedItem = radTabItem;

            }
            catch (Exception ex)
            {

                ClsMessage._IClsMessage.ShowError(ex);
            }
        }
        private UIElement UIElement(Object Icon)
        {
            try
            {
                UIElement uIElement = new UIElement();
                ;

                switch (Icon.GetType().FullName.ToString())
                {
                    case "A3DIcons.RemixIcons.IconImage":

                        var iRCons = (A3DIcons.RemixIcons.IconImage)Icon;

                        uIElement = new A3DIcons.RemixIcons.IconImage() { Source = iRCons.Source, Width = 24, Height = 24 };
                        break;
                    case "A3DFontAwesome.Material.IconImage":
                        var iMCons = (A3DFontAwesome.Material.IconImage)Icon;
                        uIElement = new A3DFontAwesome.Material.IconImage() { Source = iMCons.Source, Width = 24, Height = 24 };
                        break;
                    default:
                        break;
                }


                return uIElement;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private RadTabItem? IsFormOpen(string Formname, string FormTitle)
        {
            try
            {

                RadTabItem radTabItem = null;
                if (Formname != null)
                {

                    foreach (RadTabItem rdTabItem in TabMainContent.Items)
                    {

                        if (rdTabItem.Name.ToUpper() == $"radTabItem_{Formname}".ToUpper() && ((StackPanel)rdTabItem.Header).Name.ToString().ToUpper() == $"Stck{Formname}".ToUpper())
                        { radTabItem = rdTabItem; break; }
                    }


                }
                return radTabItem;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public UserControl LoadForm(string FormName)
        {
            var _formName = (from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                             where t.Name.Equals(FormName)
                             select t.FullName).FirstOrDefault();
            var _form = (UserControl)Activator.CreateInstance(type: Type.GetType(_formName));

            _form.HorizontalAlignment = HorizontalAlignment.Stretch;
            _form.VerticalAlignment = VerticalAlignment.Stretch;
            return _form;
        }

        private void RdNavItemAboutUs_Click(object sender, RoutedEventArgs e)
        {
            WinAboutUs winAboutUs = new()
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,


            };
            winAboutUs.ShowDialog();
            
        }
    }
}
