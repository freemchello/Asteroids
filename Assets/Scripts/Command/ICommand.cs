namespace Asteroids
{
    public interface ICommand
    {
        bool Succeeded { get; }

        bool TryExecute();

        void Undo();
    }
}