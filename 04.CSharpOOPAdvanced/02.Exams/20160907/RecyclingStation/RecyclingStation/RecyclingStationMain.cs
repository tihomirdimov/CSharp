namespace RecyclingStation
{
    using RecyclingStation.Core;

    public class RecyclingStationMain
    {
        private static void Main(string[] args)
        {
            var recyclingStation = new Engine();
            recyclingStation.Run();
        }
    }
}
