namespace SSNC.CodeChallenge.Weanich.Sanchol.Domains
{
    public class Toy
    {
        public void Update(int x, int y, string f)
        {
            PositionX = x;
            PositionY = y;
            Direction = f;
        }
        public Guid Id { get; set; }

        public int? PositionX { get; set; }

        public int? PositionY { get; set; }

        public string? Direction { get; set; }

    }
}
