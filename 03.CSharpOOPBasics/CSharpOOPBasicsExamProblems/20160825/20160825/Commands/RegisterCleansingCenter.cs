namespace _20160825.Commands
{
    using Models.Centers;
    public class RegisterCleansingCenter : Command
    {
        private readonly string name;
        public RegisterCleansingCenter(string name)
        {
            this.name = name;
        }
        public override void Execute()
        {
            CleansingCenter cleansingCenterToRegister = new CleansingCenter(name);
            PawInc.CleansingCenters.Add(cleansingCenterToRegister);
        }
    }
}
