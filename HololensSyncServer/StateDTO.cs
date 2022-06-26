namespace HololensSyncServer
{
    public class StateDTO
    {
        public List<float> Position { get; set; } = new List<float>();
        public List<float> Rotation { get; set; } = new List<float>();
        public List<float> Scale { get; set; } = new List<float>();
        public float Opacity { get; set; }
        public int MapLevel { get; set; }
        public bool RequestMap { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
