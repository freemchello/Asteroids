using System;
using UnityEngine;

namespace Asteroids
{
    public abstract class Unit : MonoBehaviour
    {

        [SerializeField] public Rigidbody _rb;
        public Transform _transform;

       
        public static int Health = 100;
        public static bool isDead = false;

       

    }
}
