using UnityEngine;

namespace Asteroids
{
    public class MoveLeft : ICommand
    {
        private readonly float _moveDistance;
        private readonly Transform _box;

        public bool Succeeded { get; private set; }


        public MoveLeft(float moveDistance, Transform box)
        {
            _moveDistance = moveDistance;
            _box = box;
        }

        public bool TryExecute()
        {
            _box.Translate(-_box.right * _moveDistance);
            Debug.Log("moveL");
            Succeeded = true;
            return Succeeded;
        }

        public void Undo()
        {
            _box.Translate(_box.right * _moveDistance);
        }
    }
}