namespace _20160825.Models.Centers
{
    using System.Collections.Generic;
    using Animals;
    public class AdoptionCenter : Center
    {
        public AdoptionCenter(string name) : base(name)
        {
            this.Name = name;
            this.Type = 1;
        }
    }
}
