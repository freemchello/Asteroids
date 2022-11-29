namespace Asteroids
{
    internal sealed class AddArmorModificator : PlayerModificator
    {
        private readonly int _maxArmor;

        public AddArmorModificator(Player player, int maxArmor)
            : base(player)
        {
            _maxArmor = maxArmor;
        }

        public override void Handle()
        {
            if (_player.Armor <= _maxArmor)
            {
                _player.Armor = 100;
            }

            base.Handle();
        }
    }
}