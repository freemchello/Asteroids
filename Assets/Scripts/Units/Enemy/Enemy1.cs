using UnityEngine;
namespace Asteroids
{
    public class Enemy1 : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        public Health Health { get; protected set; }
        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy._health = hp;
            return enemy;
        }
        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }
    }
}
