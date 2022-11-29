using UnityEngine;
namespace Asteroids
{
    public sealed class AsteroidFactory /*: IEnemyFactory*/
    {
        public Asteroid Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy._health = hp;
            //enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}
