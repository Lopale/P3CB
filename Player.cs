using System;
using System.Collections.Generic;
using System.Text;

namespace Lopale
{
    class Player
    {
        public int life = 3;

        public string DisplayLife()
        {
            string yourLife = "Life : " + life;
            return yourLife;
        }

        public void looseLife(int pLife)
        {
            life = life - pLife;
        }
        public void gainLife(int pLife)
        {
            life = life + pLife;
        }


    }
}
