namespace _20160710.Commands
{
    using _20160710.Models;
    class RegisterPowerHardware
    {
        private readonly Hardware hardware;
        public RegisterPowerHardware(Hardware hardware)
        {
            this.hardware = hardware;
        }
        public void Register()
        {
            TheSystem.Components.Add(hardware);
        }
    }
}
