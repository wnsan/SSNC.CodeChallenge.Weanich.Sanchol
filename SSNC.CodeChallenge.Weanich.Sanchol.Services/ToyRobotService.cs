using SSNC.CodeChallenge.Weanich.Sanchol.Domains;

namespace SSNC.CodeChallenge.Weanich.Sanchol.Services
{
    public class ToyRobotService
    {
        private readonly string[] Directions =
            new string[] { "NORTH", "SOUTH", "EAST", "WEST" };


        public void Place(Toy toy, Board board, int x, int y, string f)
        {
            if (x < board.Width && x >= 0 && y < board.Height && y >= 0
                && Directions.Contains(f))
            {
                toy.Update(x, y, f);
            }
        }

        /// <summary>
        /// Return null when toy is invalid.
        /// </summary>
        /// <param name="toy"></param>
        /// <returns></returns>
        public string Report(Toy toy)
        {
            if (toy is null || toy.PositionX is null || toy.PositionY is null || toy.Direction is null)
            { 
                return null; 
            }

            return $"{toy.PositionX},{toy.PositionY},{toy.Direction}";
        }

        public void Move(Toy toy, Board board)
        {
            if(toy.Direction == "NORTH" && toy.PositionY + 1 < board.Height)
            {
                toy.MoveUp();
            }

            if (toy.Direction == "SOUTH" && toy.PositionY - 1 >= 0)
            {
                toy.MoveDown();
            }

            if (toy.Direction == "EAST" && toy.PositionY + 1 < board.Width)
            {
                toy.MoveRight();
            }

            if (toy.Direction == "WEST" && toy.PositionY - 1 >= 0)
            {
                toy.MoveLeft();
            }
        }
    }
}
