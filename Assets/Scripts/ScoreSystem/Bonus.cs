using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public abstract class Bonus : MonoBehaviour, IExecute
    {
        private bool _isInteractable;
        public Transform _transform;
        protected Color _color;
        
        public bool IsInteractable
        {
            get { return _isInteractable; }
            private set 
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = value;
                GetComponent<Collider2D>().enabled = value;
            }
        }

        void Start()
        {
            IsInteractable = true;

            _color = Random.ColorHSV();

            if (TryGetComponent(out Renderer renderer))
            {
                renderer.sharedMaterial.color = _color;
            }

        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(/*IsInteractable ||*/ other.CompareTag("Player") || other.CompareTag("Bullet"))
            {
                Debug.Log("Score+");
                Interaction();
                IsInteractable = false;
            }
        }

        protected abstract void Interaction();

        public abstract void Update();
    }
}
