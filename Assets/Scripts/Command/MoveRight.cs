using UnityEngine;

namespace Asteroids
{
    public class MoveRight : ICommand
    {
        private readonly float _moveDistance;
        private readonly Transform _box;

        public bool Succeeded { get; private set; }


        public MoveRight(float moveDistance, Transform box)
        {
            _moveDistance = moveDistance;
            _box = box;
        }

        public bool TryExecute()
        {
            _box.Translate(_box.right * _moveDistance);
            Debug.Log("moveR");
            Succeeded = true;
            return Succeeded;
        }

        public void Undo()
        {
            _box.Translate(-_box.right * _moveDistance);
        }
    }
}