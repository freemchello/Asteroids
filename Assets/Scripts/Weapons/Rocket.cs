using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class Rocket : IWeapon
    {
        private readonly Rigidbody2D _prefabRocket;
        public Rocket(Rigidbody2D prefabRocket)
        {
            _prefabRocket = prefabRocket;
        }
        public void Attack()
        {
            
        }
    }
}