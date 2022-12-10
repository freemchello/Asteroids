using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class EnemyObserver : MonoBehaviour, IHit
    {
        public event Action<float> OnHitChange = delegate (float f) { };
        public void Hit(float damage)
        {
            OnHitChange.Invoke(damage);
        }
    }
}