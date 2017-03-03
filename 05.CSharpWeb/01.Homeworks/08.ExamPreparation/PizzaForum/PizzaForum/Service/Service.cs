namespace PizzaForum.Service
{
    using PizzaForum.Data;

    public abstract class Service
    {
        protected Service()
        {
            this.Context = Data.Context;
        }

        protected PizzaForumContext Context { get; }
    }
}
