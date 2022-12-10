namespace Asteroids
{
    interface IEnemy
    {
        void Accept(IEnemyVisitor visitor);
    }
}