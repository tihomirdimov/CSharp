namespace PersonalFinanceManager.ViewModels.MoneyStreams
{
    public class MoneyStreamIndexViewModel
    {
        public MoneyStreamIndexViewModel()
        {
            this.MoneyStreamManageViewModel = new MoneyStreamManageViewModel();
            this.MoneyStreamsListViewModel = new MoneyStreamsListViewModel();
        }
        public MoneyStreamManageViewModel MoneyStreamManageViewModel { get; set; }
        public MoneyStreamsListViewModel MoneyStreamsListViewModel { get; set; }
    }
}