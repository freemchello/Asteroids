using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal class PlayerModificator
    {
        protected Player _player;
        protected PlayerModificator Next;

        public PlayerModificator(Player player)
        {
            _player = player;
        }

        public void Add(PlayerModificator AM)
        {
            if(Next != null)
            {
                Next.Add(AM);
            }
            else
            {
                Next = AM;
            }
        }
        public virtual void Handle() => Next?.Handle(); //Вызов модификации
    }
}