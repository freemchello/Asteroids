using System;

namespace Asteroids
{
    public interface IHit
    {
        event Action<float> OnHitChange;
        void Hit(float damage);
    }
}