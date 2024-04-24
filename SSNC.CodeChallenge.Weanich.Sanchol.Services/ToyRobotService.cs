using SSNC.CodeChallenge.Weanich.Sanchol.Domains;

namespace SSNC.CodeChallenge.Weanich.Sanchol.Services
{
    public class ToyRobotService
    {
        public void Place(Toy toy, Board board, int x, int y, string f)
        {
            if(x < board.Width && x >= 0 && y < board.Height && y >= 0)
            {
                toy.Update(x, y, f);
            }
        }
    }
}
