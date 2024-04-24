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
    }
}
