using UnityEngine;

namespace Asteroids
{
    internal sealed class EXAMPLEMODIFICATOR : MonoBehaviour
    {
        void Start()
        {
            var player = new Player(10, 100, 0, false);
            Debug.Log("EXAMPLEMODIFICATOR.cs(цепочка обязанностей) Armor = " + player.Armor);
            var root = new PlayerModificator(player);
            root.Add(new AddAttackModificator(player, 20));
            root.Add(new AddAttackModificator(player, 30));
            root.Add(new AddArmorModificator(player, 100));
            root.Handle();
            Debug.Log("EXAMPLEMODIFICATOR.cs(цепочка обязанностей) Armor = " + player.Armor);
            Debug.Log("EXAMPLEMODIFICATOR.cs(цепочка обязанностей) Attack = " + player.Attack);
        }

    }
}