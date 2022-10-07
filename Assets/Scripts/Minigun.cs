using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    class Minigun : MonoBehaviour
    {
        public Rigidbody2D _rb;

        [SerializeField] public float _fireForce = 1f; //�������� ��������
        [SerializeField] public float lifeTime = 3f;//����� ����� ����
        [SerializeField] public float _minigunDamage = 10f;//���� �� ����

        private void Start()
        {
            this._rb.AddForce(transform.up * _fireForce, ForceMode2D.Impulse);
        }

        private void FixedUpdate()
        {
            Destroy(gameObject, lifeTime);
        }

        private void OnTriggerEnter2D(UnityEngine.Collider2D bullet)
        {
            if (/*bullet.CompareTag("Player") ||*/ bullet.CompareTag("Asteroid"))
            {
                Debug.Log("DESTROY BULLET");
                Destroy(gameObject);
            }
        }
    }
}