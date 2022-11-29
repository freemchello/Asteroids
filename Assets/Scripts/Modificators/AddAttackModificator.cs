namespace Asteroids
{
    internal sealed class AddAttackModificator : PlayerModificator
    {
        private readonly int _attack;

        public AddAttackModificator(Player player, int attack) 
            : base(player)
        {
            _attack = attack;
        }
        public override void Handle()
        {
            _player.Attack += _attack;
            base.Handle();
        }
    }
}