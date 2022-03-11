namespace SnakesAndLadders.Core.DTO
{
    public class PlayResult
    {
        public int CurrentPosition { get; set; }
        public int Movements { get; set; }
        public int FinalPosition { get; set; }
        public bool IsWinner { get; set; }
    }
}
