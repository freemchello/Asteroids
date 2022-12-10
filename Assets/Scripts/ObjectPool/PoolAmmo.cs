using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PoolAmmo : MonoBehaviour
    {
        [SerializeField] private int poolCount = 4; //ёмкость пула
        [SerializeField] private bool autoExpand = false;
        [SerializeField] private Minigun minigunPrefab;
        public Transform spawnPosition; //МЕСТО СПАВНА ПУЛЬ


        private DefaultPlayerInput _input;
        private PoolMono<Minigun> pool;
        private void Awake()
        {
            _input = new DefaultPlayerInput();
            _input.Player.Minigun.performed += context => SpawnBullet();
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
            this.pool = new PoolMono<Minigun>(minigunPrefab, poolCount, this.transform);//создание пула
            this.pool.autoExpand = this.autoExpand;//авторасширение по флагу
        }
        public void SpawnBullet()
        {
            var bullet = pool.GetFreeElement();
            bullet.transform.position = spawnPosition.position; //привязка спавна создания пули к позиции
            bullet.transform.rotation = spawnPosition.rotation; //привязка спавна создания пули к вращению
           
            //bulletObj.transform.SetParent(spawnPosition); привязка пули к позиции(можно использоваться для лазера,огнемета и т.п.)
        }
    }
}