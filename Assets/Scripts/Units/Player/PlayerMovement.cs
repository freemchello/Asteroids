using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Asteroids
{
    public sealed class PlayerMovement : MonoBehaviour
    {
        private Vector2 _direction;
        public static Rigidbody2D player;

        //private bool _isForce;
        //private bool _isDead;

        private static float turnSpeed = 50;
        private static float speed = 20f;

        private void Start()
        {
            player = GetComponent<Rigidbody2D>();
        }
        void OnMove(InputValue iv)
        {
            _direction = iv.Get<Vector2>();
            //Debug.Log(_direction.x + " - " + _direction.y);
        }

        void FixedUpdate()
        {
            player.AddForce(transform.up * speed * _direction.y * Time.deltaTime, ForceMode2D.Impulse);
            player.MoveRotation(player.rotation + turnSpeed * -_direction.x * Time.deltaTime);
        }

    }
}