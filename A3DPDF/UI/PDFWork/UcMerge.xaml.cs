namespace A3DPDF.UI.PDFWork
{
    /// <summary>
    /// Interaction logic for UcMerge.xaml
    /// </summary>
    public partial class UcMerge : UserControl
    {
        public UcMerge()
        {
            InitializeComponent();
            
            
        }

        private void RdBtnSelectfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RdCmbMergeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                RadComboBoxItem _radComboBoxItem=e.AddedItems[0] as RadComboBoxItem;
                if (_radComboBoxItem!=null)
                {
                    RdCmbMergeType.ToolTip=_radComboBoxItem.ToolTip;
                }
            }
            catch (Exception ex)
            {

                ClsMessage._IClsMessage.ShowError(ex, this);
            }
        }
    }
}
