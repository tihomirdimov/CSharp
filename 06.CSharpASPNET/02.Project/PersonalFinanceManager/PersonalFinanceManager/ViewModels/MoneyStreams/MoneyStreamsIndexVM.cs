namespace PersonalFinanceManager.ViewModels.MoneyStreams
{
    public class MoneyStreamsIndexVM
    {
        public MoneyStreamsIndexVM()
        {
            this.MoneyStreamsFormVM = new MoneyStreamsFormVM();
            this.MoneyStreamsListVM = new MoneyStreamsListVM();
        }
        public MoneyStreamsFormVM MoneyStreamsFormVM { get; set; }
        public MoneyStreamsListVM MoneyStreamsListVM { get; set; }
    }
}