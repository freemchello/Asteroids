using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class Minigun : MonoBehaviour
    {
        public Rigidbody2D _rb;

        [SerializeField] public float _fireForce = 1f; //скорость выстрела
        [SerializeField] public float lifeTime = 3f;//время жизни пули
        [SerializeField] public float _minigunDamage = 10f;//урон от пули

        private void FixedUpdate()
        {
            this._rb.AddForce(transform.up * _fireForce, ForceMode2D.Impulse);
        }
        private void OnEnable()
        {
            this.StartCoroutine("LifeRoutine");
        }
        private void OnDisable()
        {
            this.StopCoroutine("LifeRoutine");
        }

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSecondsRealtime(this.lifeTime);

            this.DesActivate();
        }

        private void DesActivate()
        {
            this.gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D bullet) //при взаимодействии коллайдера пули с
        {
            if (bullet.CompareTag("Asteroid") || bullet.CompareTag("Enemy"))//тэгом Астероид
            {
                Debug.Log("DESTROY BULLET");
                Debug.Log("Attack = " + _minigunDamage);
                DesActivate();//отключать
            }
        }
    }
}