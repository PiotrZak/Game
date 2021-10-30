namespace Game.Engine
{
    public class Planet
    {
        public int Size { get; set; }
        public Atmosphere Atmosphere { get; set; }
    }

    public class Atmosphere
    {
        public int Temperature { get; set; }
        public int Pressure { get; set; }
        public int WindSpeed { get; set; }
        public int CarbonPercentage { get; set; }
        public int OxygenPercentage { get; set; }
        public bool isWater { get; set; }
    }
}