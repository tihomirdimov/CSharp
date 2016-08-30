namespace _20160710.Commands
{
    using _20160710.Models;
    class RegisterHeavyHardware
    {
        private Hardware hardware;
        public RegisterHeavyHardware(Hardware hardware)
        {
            this.hardware = hardware;
        }
        public void register()
        {
            TheSystem.Components.Add(hardware);
        }
    }
}