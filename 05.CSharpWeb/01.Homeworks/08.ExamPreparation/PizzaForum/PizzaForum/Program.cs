namespace PizzaForum
{
    using SimpleHttpServer;
    using SimpleMVC;

    class Program
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaForum");
        }
    }
}
