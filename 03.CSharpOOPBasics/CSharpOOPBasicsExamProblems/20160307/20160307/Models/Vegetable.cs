namespace _20160307.Models
{
    public abstract class Vegetable : MatrixElement
    {
        private bool Grown;
        private string Name;
        private int Power;
        private int Stamina;
        public abstract void Grow();
    }
}
