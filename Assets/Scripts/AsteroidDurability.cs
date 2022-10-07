using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidDurability : MonoBehaviour
    {
        [SerializeField] public float _durabilityPoint = 10f;

        private void OnTriggerEnter2D(Collider2D Asteroid) // при взаимодействии с коллайдером Asteroid
        {
            if (Asteroid.CompareTag("Bullet"))
            {
                GameObject BulletObj = GameObject.FindGameObjectWithTag("Bullet");
                var BulletComponent = BulletObj.GetComponent<Minigun>();
                var minigunDamage = BulletComponent._minigunDamage;
                Debug.Log("ENEMYBULLET DAMAGE(AsterlidDurability.cs)");

                //if (_shieldPoint > 0)
                //{
                //    _shieldPoint -= enemyDamage;

                //    if (_shieldPoint <= 0)
                //    {
                //        _healthPoint += _shieldPoint;
                //    }
                //}
                //else
                _durabilityPoint -= minigunDamage;
            }
            
        }
        private void Update()
        {
            if (_durabilityPoint <= 0)
                Destroy(gameObject);
        }
    }
}