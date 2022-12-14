using System.Collections;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public sealed class ListExecuteObject : IEnumerable, IEnumerator
    {
        private IExecute[] _interectiveObject;
        private int _index = -1;

        public object Current => _interectiveObject[_index];
        public int Lenght => _interectiveObject.Length;

        public ListExecuteObject()
        {
            Bonus[] BonusObject = Object.FindObjectsOfType<Bonus>();
            for(int i = 0; i < BonusObject.Length; i++)
            {
                if(BonusObject[i] is IExecute intObj)
                {
                    AddExecuteObject(intObj);
                }
            }
        }

        public IExecute this[int curr]
        {
            get => _interectiveObject[curr];
            private set => _interectiveObject[curr] = value;
        }

        public void AddExecuteObject(IExecute execute)
        {
            if(_interectiveObject ==null)
            {
                _interectiveObject = new[] {execute};
                return;
            }

            Array.Resize(ref _interectiveObject, Lenght + 1);
            _interectiveObject[Lenght - 1] = execute;
        }

        public bool MoveNext()
        {
            if(_index == Lenght-1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }
        public void Reset()
        {
            _index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
      
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
