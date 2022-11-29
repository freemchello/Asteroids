using UnityEngine;

namespace Asteroids
{
    public class CommandExample : MonoBehaviour
    {
        public InputHandler InputHandler;

        private void Start()
        {
            Instantiate(InputHandler, Vector2.zero, Quaternion.identity);
        }
    }
}