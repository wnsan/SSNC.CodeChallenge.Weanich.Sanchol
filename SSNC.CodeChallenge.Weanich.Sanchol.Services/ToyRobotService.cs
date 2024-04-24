using SSNC.CodeChallenge.Weanich.Sanchol.Domains;

namespace SSNC.CodeChallenge.Weanich.Sanchol.Services
{
    public class ToyRobotService
    {
        private readonly string[] Directions =  
            new string[] { "NORTH", "SOUTH", "EAST", "WEST" };


        public void Place(Toy toy, Board board, int x, int y, string f)
        {
            if(x < board.Width && x >= 0 && y < board.Height && y >= 0
                && Directions.Contains(f))
            {
                toy.Update(x, y, f);
            }
        }
    }
}
