using System;
using UnityEngine;

namespace Asteroids
{
    public class GoodBonus : Bonus, IFly, IFlicker
    {
        private float heightFly = 0.5f;
        [SerializeField]private Material _material;
        public double Point = 2123.32;

        public event Action<int> AddPoints = delegate (int i){ };

        void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _transform = GetComponent<Transform>();
        }

        public override void Update()
        {
            Fly();
            Flick();
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }
        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, heightFly), _transform.position.z);
        }

        protected override void Interaction()
        {
            AddPoints.Invoke((int)Point);
        }
    }
}
