using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    class PoolEnemyVisitor : MonoBehaviour, IEnemyVisitor
    {
        [SerializeField] private int poolCount = 4; //ёмкость пула
        private PoolMono<Enemy> pool;
        [SerializeField] private Enemy Enemy;
        float newX;
        float newY;
        Vector3 randomXYZ;


        private DefaultPlayerInput _input;

        private void Awake()
        {
            _input = new DefaultPlayerInput();
            _input.Player.Undo.performed += context => SpawnEnemy();
        }
        private void Update()
        {
            newX = Random.Range(-18f, 18f);
            newY = Random.Range(-9f, 10f);
            randomXYZ = new Vector3(newX, newY, 0);

        }

        private void OnEnable()
        {
            _input.Enable();
        }
        private void OnDisable()
        {
            _input.Disable();
        }

        private void Start()
        {
            this.pool = new PoolMono<Enemy>(Enemy, poolCount, this.transform);//создание пула
        }
        public void SpawnEnemy()
        {
            var enemy = pool.GetFreeElement();
            enemy.transform.position = randomXYZ;
            Enemy.Accept(this);
        }

        public void Visit(IEnemy enemy)
        {
            //SpawnEnemy();
            Debug.Log("VISITOR ENEMY");
        }
    }
}
