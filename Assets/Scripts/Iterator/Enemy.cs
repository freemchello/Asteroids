using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Iterator.Scripts
{
    public class Enemy : IEnemy
    {
        private readonly List<IAbility> _abilities;

        public Enemy(List<IAbility> abilities)
        {
            _abilities = abilities;
        }

        public IAbility this[int index] => _abilities[index];

        public string this[Target index]
        {
            get
            {
                var ability = _abilities.FirstOrDefault(a => a.Target == index);
                return ability == null ? "Not supported" : ability.ToString();
            }
        }

        public int MaxDamage => _abilities.Select(a => a.Damage).Max();
        

        public IEnumerable<IAbility> GetAbility()
        {
            while (true)
            {
                yield return _abilities[UnityEngine.Random.Range(0, _abilities.Count)];
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _abilities.Count; i++)
            {
                yield return _abilities[i];
            }
        }

        public IEnumerable<IAbility> GetAbility(DamageType damageType)
        {
            foreach (IAbility ability in _abilities)
            {
                if (ability.DamageType == damageType)
                {
                    yield return ability;
                }
            }
        }
    }
}