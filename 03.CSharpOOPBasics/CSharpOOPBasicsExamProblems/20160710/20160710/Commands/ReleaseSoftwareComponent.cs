using System.Linq;
using System.Threading;
using _20160710.Models;

namespace _20160710.Commands
{
    class ReleaseSoftwareComponent
    {
        private readonly string hardware;
        private readonly string software;
        public ReleaseSoftwareComponent(string hardware, string software)
        {
            this.hardware = hardware;
            this.software = software;
        }
        public void Release()
        {
            TheSystem.Components.Find(c => c.Name == hardware).Software.RemoveAll(x=>x.Name.Equals(software));
        }
    }
}
