using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    /////�� ������ ���� � ������������ ��� ���� PoolAmmo

    //public class PlayerShooting : MonoBehaviour
    //{
    //    private DefaultPlayerInput _input;

    //    /// <summary>
    //    /// ������ �������� + ����� ������ ����
    //    /// </summary>
    //    public GameObject minigunPrefab;
    //    public Transform spawnPosition;


    //    private void Awake()
    //    {
    //        _input = new DefaultPlayerInput();
    //        //_input.Player.Minigun.performed += context => SpawnBullet();
    //    }
    //    private void OnEnable()
    //    {
    //        _input.Enable();
    //    }
    //    private void OnDisable()
    //    {
    //        _input.Disable();
    //    }

    //    private static void SpawnBullet1()
    //    {
    //        //var SpawnBullet = new SpawnBullet();
    //        //var bullet = this.pool.GetFreeElement();
    //        //bullet.transform.position = spawnPosition;
    //        //var bulletObj = Instantiate(minigunPrefab, spawnPosition.position, spawnPosition.rotation);
    //        //var bullet = bulletObj.GetComponent<Minigun>();
    //        //bulletObj.transform.SetParent(spawnPosition); �������� ���� � �������(����� �������������� ��� ������,�������� � �.�.)
    //    }
    //}
}