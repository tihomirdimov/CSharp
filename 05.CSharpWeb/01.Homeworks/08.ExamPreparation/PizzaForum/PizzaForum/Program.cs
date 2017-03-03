namespace PizzaForum
{
    using SimpleHttpServer;

    class Program
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
        }
    }
}
