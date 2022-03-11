namespace SnakesAndLadders.Core
{
    public class Player
    {
        private string _name;
        private int _number;
        public Token Token;

        public Player(string name, int number)
        {
            _name = name;
            _number = number;            
        }

        public string GetName()
        {
            return _name;
        }
    }
}
