// Brittany Diesbourg & Dianne Corpuz - Section A

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiddlerLibrary
{
    public interface IDeck
    {
        public string About { get; }
        public int CardCount { get; init; }
        public int CardsPerPlayer { get; set; }
        public string TopDiscard { get; }

        IPlayer NewPlayer();
        public string ToString();
    }
}
