namespace NavalWar.API
{
    public class GamingMap
    {
        public int MapID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public List<int> ShipPositionsMap { get; set; }
        public List<int> WarMap { get; set; }

        public GamingMap CreateGamingMap(int Width, int Height)
        {
            GamingMap map = new GamingMap();

            map.ShipPositionsMap = new List<int>();
            map.WarMap = new List<int>();

            map.MapID = 1;
            map.Width = Width;
            map.Height = Height;

            for (int i = 0; i < map.Width * map.Height; i++)
            {
                map.ShipPositionsMap.Add(0);
            }

            map.ShipPositionsMap[1] = 1;

            for (int i = 0; i < map.Width * map.Height; i++)
            {
                map.WarMap.Add(0);
            }

            return map;
        }

        public GamingMap AddShipToGamingMap(GamingMap map, Ship ship, int position)
        {

            // Add according to position

            return map;
        }

        public GamingMap ReplaceShipInGamingMap(GamingMap map, int newPosition)
        {

            // Replace position of ship

            return map;
        }

        public GamingMap DeleteShipFromGamingMap(GamingMap map, int position)
        {

            // Delete ship according to position

            return map;
        }

    }
}
