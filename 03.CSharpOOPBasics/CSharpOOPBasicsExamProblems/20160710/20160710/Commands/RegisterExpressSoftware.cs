﻿namespace _20160710.Commands
{
    using _20160710.Models;
    class RegisterExpressSoftware
    {
        private Software software;
        public RegisterExpressSoftware(Software software)
        {
            this.software = software;
        }
        public void register()
        {
            SoftwareComponentValidation validate = new SoftwareComponentValidation(software, software.Hardware);
            if (validate.IsValid())
            {
                TheSystem.Components.Find(c => c.Name == software.Hardware).Software.Add(software);
            }
        }
    }
}
