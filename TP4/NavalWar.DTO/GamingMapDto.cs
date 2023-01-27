namespace NavalWar.DTO
{
    public class GamingMapDto
    {
        public int MapID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int[][] ShipPositionsMap { get; set; }
        public int[][] WarMap { get; set; }
    }
}
