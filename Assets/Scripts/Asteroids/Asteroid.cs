using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : MonoBehaviour
    {
        public Rigidbody2D _rb;

        private float _asteroidForce = 0f; //скорость астероида
        [SerializeField] public float _lifeTime = 3f;//время жизни астероида
        [SerializeField] public float _asteroidDamage = 10f;//урон от астероида
        [SerializeField] public Health _health;

        private void Update()
        {
            _asteroidForce = Random.Range(6f, 10f);
            transform.position += ((transform.right - transform.up) * Time.deltaTime) * _asteroidForce;
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
            yield return new WaitForSecondsRealtime(this._lifeTime);

            this.DesActivate();
        }

        private void DesActivate()
        {
            this.gameObject.SetActive(false);
        }
        private void OnTriggerEnter2D(Collider2D asteroid) //при взаимодействии коллайдера asteroid с
        {
            if (asteroid.CompareTag("Bullet") || asteroid.CompareTag("Player") || asteroid.CompareTag("Enemy"))//тэггами
            {
                Debug.Log("desactive ASTEROID");
                DesActivate();//отключать
            }
        }
    }
}
