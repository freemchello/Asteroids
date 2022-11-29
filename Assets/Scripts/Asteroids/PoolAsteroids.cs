using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PoolAsteroids : MonoBehaviour
    {
        [SerializeField] private int asteroidsCount = 20;
        //[SerializeField] private float asteroidSpawnRadius = Random.Range(0f, 50f);
        float newX;
        float newY;
        Vector3 randomXYZ;

        [SerializeField] private bool autoExpand = false;
        [SerializeField] private Asteroid asteroidPrefab;

        private PoolMono<Asteroid> asteroidPool;

        //Vector3 worldPosition = ScreenPositionIntoWorld(new Vector2(Screen.width / 2, Screen.height / 2), 10.0f);

        //public static Vector3 ScreenPositionIntoWorld(Vector2 screenPosition, float distance)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        //    return (ray.direction.normalized * distance);
        //}
        
        private void Update()
        {
            newX = Random.Range(-23f, -22f);
            newY = Random.Range(-10, 40f);
            randomXYZ = new Vector3(newX, newY, 0);
        }

        private void Start()
        {
            this.asteroidPool = new PoolMono<Asteroid>(asteroidPrefab, asteroidsCount, this.transform);//создание пула
            this.asteroidPool.autoExpand = this.autoExpand;//авторасширение пула по необходимости
            StartCoroutine(StartSetAsteroids());//life time астероида и ожидание в энумераторе отсроены так чтобы они мнгновенно заменяли друг друга на сцене.
        }

        private IEnumerator StartSetAsteroids()
        {
            int countSet = 10;
            while (countSet > 0)
            {
                countSet--;
                yield return new WaitForSeconds(0.1f);
                SpawnAsteroid();
                yield return new WaitForSeconds(0.1f);
                countSet++;
            }
            
        }
        public void SpawnAsteroid()
        {
            var asteroid = asteroidPool.GetFreeElement();
            asteroid.transform.position = randomXYZ;
        }
    }
}