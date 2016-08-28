namespace _20160825.Commands
{
    using Models.Centers;
    public class RegisterAdoptionCenter : Command
    {
        private readonly string name;
        public RegisterAdoptionCenter(string name)
        {
            this.name = name;
        }
        public override void Execute()
        {
            AdoptionCenter adoptionCenterToRegister = new AdoptionCenter(name);
            PawInc.AdoptionCenters.Add(adoptionCenterToRegister);
        }
    }
}