using System;
using UnityEngine;

namespace Asteroids
{
    public class Player
    {

        public float Attack;
        public int Health;
        public int Armor;
        public static bool isDead = false;

        public Player(int _damage, int health, int armor, bool isdead)
        {
            Attack = _damage;
            Health = health;
            Armor = armor;
            isDead = isdead;
        }

    }
}
