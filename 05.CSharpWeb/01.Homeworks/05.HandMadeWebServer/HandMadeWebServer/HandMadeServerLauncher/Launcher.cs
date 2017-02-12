namespace HandMadeServerLauncher
{
    using System.IO;
    using HandMadeWebServer.Models;
    using System.Collections.Generic;
    using System.Threading;
    using HandMadeWebServer;

    public class Launcher
    {
        static void Main()
        {
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Home Directory",
                    Method = HandMadeWebServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/home$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = HandMadeWebServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/launcher.html")
                        };
                    }
                }
            };
            HttpServer server = new HttpServer(8085, routes);
            server.Listen();

            Thread thread = new Thread(new ThreadStart(server.Listen));
            thread.Start();
        }
    }
}