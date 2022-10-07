using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids
{
    public class PlayerMovement : Unit
    {
        private Vector2 _direction;
        private Rigidbody2D player;
        

        private bool _isForce;

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
        //private void Move(float delta)
        //{
        //    var fixedDirection = transform.TransformDirection(_direction);
        //    transform.position += fixedDirection * (_isForce ? speedShip * 2 : speedShip) * delta;
        //}

        //private void RotateLeft()
        //{
        //    _transform.Rotate(Vector3.forward * (Time.deltaTime * speedRotationShip), Space.World);
        //}
        //private void RotateRight()
        //{
        //    _transform.Rotate(Vector3.back * (Time.deltaTime * speedRotationShip), Space.World);
        //}


        //void Update()
        //{
        //    //_direction.y = Input.GetAxis("Vertical");
        //    //Move(Time.fixedDeltaTime);

        //}
        //private void FixedUpdate()
        //{
            
            //if (Input.GetKey(KeyCode.A)) { RotateLeft(); }
            //else if (Input.GetKey(KeyCode.D)) { RotateRight(); }
            //else
            //if (Input.GetKey(KeyCode.W))
            //{
            //    forceY = speedShip;
            //}
            //else if (Input.GetKey(KeyCode.S))
            //{
            //    forceY = -speedShip;
            //}
            //else if (Input.GetKey(KeyCode.A))
            //{
            //    rotation = speedRotationShip;
            //}
            //else if (Input.GetKey(KeyCode.D))
            //{
            //    rotation = -speedRotationShip;
            //}

            //float playerX = player.rotation;
            //float playerY = player.position.y;

            //    player.MovePosition(new Vector2(0, playerY + forceY));
            //    player.MoveRotation(rotation + player.rotation);
            
        //}
    }
}