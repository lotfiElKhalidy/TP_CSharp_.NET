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

        public void AddShipToGamingMap(Ship ship, int position)
        {
            this.ShipPositionsMap[position] = 1;
        }

        public void ReplaceShipInGamingMap(int actualPosition, int newPosition)
        {
            this.ShipPositionsMap[actualPosition] = 0;
            this.ShipPositionsMap[newPosition] = 1;
        }

        public void DeleteShipFromGamingMap(int position)
        {
            this.ShipPositionsMap[position] = 0;
        }

        public void AttackPlayer(int position)
        {
            this.WarMap[position] = 1;

            if (this.ShipPositionsMap[position] == 1)
            {
                this.ShipPositionsMap[position] = 0;
            }
            else
            {
                this.ShipPositionsMap[position] = -1;
            }
        }

    }
}
