﻿namespace _20160710.Commands
{
    using _20160710.Models;
    class RegisterLightSoftware
    {
        private Software software;
        public RegisterLightSoftware(Software software)
        {
            this.software = software;
        }
        public void register()
        {
            TheSystem.Components.Find(c => c.Name == software.Hardware).Software.Add(software);
        }
    }
}
