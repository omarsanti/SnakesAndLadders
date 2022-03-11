using SnakesAndLadders.Core.Interface;
using System;

namespace SnakesAndLadders.Core
{
    public class Die: IDie
    {
        public static int _maximun;
        public static int _minimun;
        private int? _value;

        public Die()
        {
            _maximun = 6;
            _minimun = 1;
            _value = null;
        }

        public void Roll()
        {
            Random random = new Random(DateTime.Now.Second);
            _value = random.Next(_minimun, _maximun);
        }

        public int GetValue()
        {
            return _value.HasValue ? _value.Value : 0;
        }
    }
}
