using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Models.Garbage
{
    public abstract class Garbage : IWaste
    {
        private string name;
        private double volumePerKg;
        private double weight;
        protected Garbage(string name, double volumePerKg, double weight)
        {
            this.Name = name;
            this.VolumePerKg = volumePerKg;
            this.Weight = weight;
        }

        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }

        public double VolumePerKg
        {
            get { return this.volumePerKg; }
            protected set { this.volumePerKg = value; }
        }

        public double Weight
        {
            get { return this.weight; }
            protected set { this.weight= value; }
        }
    }
}