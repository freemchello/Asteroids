using UnityEngine;

namespace Asteroids
{
    public class MoveDown : ICommand
    {
        private readonly float _moveDistance;
        private readonly Transform _box;

        public bool Succeeded { get; private set; }


        public MoveDown(float moveDistance, Transform box)
        {
            _moveDistance = moveDistance;
            _box = box;
        }

        public bool TryExecute()
        {
            _box.Translate(-_box.up * _moveDistance);
            Debug.Log("moveD");
            Succeeded = true;
            return Succeeded;
        }

        public void Undo()
        {
            _box.Translate(_box.up * _moveDistance);
        }
    }
}