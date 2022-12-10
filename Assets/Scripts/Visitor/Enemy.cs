using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    class Enemy : MonoBehaviour, IEnemy
    {
        //float speed = 10f;
        //float health = 100f;
        //int enemyDamage = 10;
        public Rigidbody2D enemyRB;

        public void Accept(IEnemyVisitor visitor)
        {
            visitor.Visit(this);
        }


        //void Start()
        //{

        //}


        //void Update()
        //{

        //}
    }
}