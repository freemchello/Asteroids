using System.Collections;
using System.Collections.Generic;

namespace Iterator.Scripts
{
    public interface IEnemy
    {
        IAbility this[int index] { get; }
        string this[Target index] { get; }
        int MaxDamage { get; }
        IEnumerable<IAbility> GetAbility();
        IEnumerator GetEnumerator();
        IEnumerable<IAbility> GetAbility(DamageType damageType);
    }
}