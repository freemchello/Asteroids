namespace Asteroids
{
    interface IEnemyVisitor
    {
        void Visit(IEnemy enemy);
    }
}