using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            Enemy1.CreateAsteroidEnemy(new Health(100.0f, 100.0f));
            //IEnemyFactory factory = new AsteroidFactory();
            //factory.Create(new Health(100.0f, 100.0f));
            //Enemy.Factory = factory;
            Enemy1.Factory.Create(new Health(100.0f, 100.0f));
        }
    }
}