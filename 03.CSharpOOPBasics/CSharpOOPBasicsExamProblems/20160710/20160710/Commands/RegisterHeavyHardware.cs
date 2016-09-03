namespace _20160710.Commands
{
    using _20160710.Models;
    class RegisterHeavyHardware
    {
        private readonly Hardware hardware;
        public RegisterHeavyHardware(Hardware hardware)
        {
            this.hardware = hardware;
        }
        public void Register()
        {
            TheSystem.Components.Add(hardware);
        }
    }
}