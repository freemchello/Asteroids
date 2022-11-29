using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Iterator.Scripts
{
    public class IteratorExample : MonoBehaviour
    {
        private void Start()
        {
            var abilities = new List<IAbility>
            {
                new Ability("Simple", 100, Target.None, DamageType.None),
                new Ability("Magic", 200, Target.Unit | Target.Autocast, DamageType.Magical),
                new Ability("Blood", 300, Target.Passive, DamageType.Pure),
                new Ability("Frosty", 400, Target.Unit, DamageType.Frost),
                new Ability("Diablo", 500, Target.Unit | Target.Autocast | Target.Passive, DamageType.Fire)
            };

            IEnemy enemy = new Enemy(abilities);

            Debug.Log("IteratorExample.Start: enemy[0] = " + enemy[0]);
            Debug.Log("IteratorExample.Start: enemy[Target.Unit | Target.Autocast] = " + enemy[Target.Unit | Target.Autocast]);
            Debug.Log("IteratorExample.Start: enemy[Target.Unit | Target.Passive] = " + enemy[Target.Unit | Target.Passive]);
            Debug.Log("IteratorExample.Start: enemy.MaxDamage = " + enemy.MaxDamage);

            foreach (var a in enemy)
            {
                Debug.Log("IteratorExample.Start: a = " + a);
            }

            foreach (var b in enemy.GetAbility().Take(2))
            {
                Debug.Log("IteratorExample.Start: b = " + b);
            }

            foreach (var c in enemy.GetAbility(DamageType.Frost))
            {
                Debug.Log("IteratorExample.Start: c = " + c);
            }
        }
    }
}