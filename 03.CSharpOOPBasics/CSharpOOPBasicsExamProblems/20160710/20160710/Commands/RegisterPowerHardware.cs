namespace _20160710.Commands
{
    using _20160710.Models;
    class RegisterPowerHardware
    {
        private Hardware hardware;
        public RegisterPowerHardware(Hardware hardware)
        {
            this.hardware = hardware;
        }
        public void register()
        {
            TheSystem.Components.Add(hardware);
        }
    }
}
