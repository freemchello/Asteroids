using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerShooting : MonoBehaviour
    {
        
        
        public GameObject gunPrefab;
        public Transform spawnPosition;
        private DefaultPlayerInput _input;
        private void Awake()
        {
            _input = new DefaultPlayerInput();
            _input.Player.Shoot.performed += context => SpawnBullet();
        }
        private void OnEnable()
        {
            _input.Enable();
        }
        private void OnDisable()
        {
            _input.Disable();
        }

        //private void Update()
        //{
        //    if (Input.GetKey(KeyCode.Mouse0))//Назначение клавиши для выстрела из минигана
        //        _isSpawnBullet = true;

        //}
        //private void FixedUpdate()
        //{
        //    if (_isSpawnBullet)
        //    {
        //        _isSpawnBullet = false;
        //        SpawnBullet();
        //    }
        //}

        private void SpawnBullet()
        {
            var bulletObj = Instantiate(gunPrefab, spawnPosition.position, spawnPosition.rotation);
            var bullet = bulletObj.GetComponent<Minigun>();
            //bulletObj.transform.SetParent(spawnPosition); привязка пули к позиции(можно использоваться для лазера,огнемета и т.п.)
        }

        //public IWeapon weapon { get; set; }
        //public void shoot() { weapon.shoot(); }
    }
}