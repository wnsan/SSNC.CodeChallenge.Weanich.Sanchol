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

        public int? PositionX { get; set; }

        public int? PositionY { get; set; }

        public string? Direction { get; set; }

        public void MoveUp()
        {
            PositionY += 1;
        }

        public void MoveDown()
        {
            PositionY -= 1;
        }

        public void MoveLeft()
        {
            PositionX -= 1;
        }

        public void MoveRight()
        {
            PositionX += 1;
        }

    }
}
