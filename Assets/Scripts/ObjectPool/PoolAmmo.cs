using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PoolAmmo : MonoBehaviour
    {
        [SerializeField] private int poolCount = 4; //������� ����
        [SerializeField] private bool autoExpand = false;
        [SerializeField] private Minigun minigunPrefab;
        public Transform spawnPosition; //����� ������ ����


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
            this.pool = new PoolMono<Minigun>(minigunPrefab, poolCount, this.transform);//�������� ����
            this.pool.autoExpand = this.autoExpand;//�������������� �� �����
        }
        public void SpawnBullet()
        {
            var bullet = pool.GetFreeElement();
            bullet.transform.position = spawnPosition.position; //�������� ������ �������� ���� � �������
            bullet.transform.rotation = spawnPosition.rotation; //�������� ������ �������� ���� � ��������
           
            //bulletObj.transform.SetParent(spawnPosition); �������� ���� � �������(����� �������������� ��� ������,�������� � �.�.)
        }
    }
}