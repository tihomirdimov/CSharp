namespace _20160710.Commands
{
    using _20160710.Models;
    class RegisterLightSoftware
    {
        private Software software;
        public RegisterLightSoftware(Software software)
        {
            this.software = software;
        }
        public void Register()
        {
            SoftwareComponentValidation validate = new SoftwareComponentValidation(software, software.Hardware);
            if (validate.IsValid())
            {
                TheSystem.Components.Find(c => c.Name.Equals(software.Hardware)).Software.Add(software);
            }
        }
    }
}
