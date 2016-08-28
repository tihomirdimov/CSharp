namespace _20160825.Models.Centers
{
    using System.Collections.Generic;
    using Animals;
    public class CleansingCenter : Center
    {
        public CleansingCenter(string name) : base(name)
        {
            this.Name = name;
            this.Type = 2;
        }
    }
}
