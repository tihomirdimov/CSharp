using System.Linq;
using _20160710.Models;

namespace _20160710.Commands
{
    public class SoftwareComponentValidation
    {
        private Software software;
        private string hardware;
        public SoftwareComponentValidation(Software software, string hardware)
        {
            this.software = software;
            this.hardware = hardware;
        }
        public bool IsValid()
        {
            if (TheSystem.Components.Any(s => s.Name.Equals(hardware)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
