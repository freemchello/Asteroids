using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class InputHandler : MonoBehaviour
    {
        private DefaultPlayerInput _input;
        
        [SerializeField]
        private Transform _square;

        [SerializeField]
        private float _moveDistance;

        private ICommand _buttonU;
        private ICommand _buttonJ;
        private ICommand _buttonH;
        private ICommand _buttonK;
        private ICommand _buttonN;
        private ICommand _buttonM;

        private readonly List<ICommand> _oldCommands = new List<ICommand>();

        private void Start()
        {
            _input = new DefaultPlayerInput();
            _input.Player.Up.performed += Up => _buttonU = new MoveUp(_moveDistance, _square);
            _input.Player.Down.performed += Down => _buttonJ = new MoveDown(_moveDistance, _square);
            _input.Player.Left.performed += Left => _buttonH = new MoveLeft(_moveDistance, _square);
            _input.Player.Right.performed += Right => _buttonK = new MoveRight(_moveDistance, _square);
            _input.Player.Nothing.performed += Nothing => _buttonN = new DoNothing();
            _input.Player.Undo.performed += Undo => _buttonM = new UndoCommand(_oldCommands);
        }
        private void OnEnable()
        {
            _input.Enable();
        }
        private void OnDisable()
        {
            _input.Disable();
        }
        private void Update()
        {
            if (_buttonU.Succeeded)
            {
                if (_buttonU.TryExecute())
                {
                    _oldCommands.Add(_buttonU);
                }
            }

            if (_buttonJ.Succeeded)
            {
                if (_buttonJ.TryExecute())
                {
                    _oldCommands.Add(_buttonJ);
                }
            }

            if (_buttonH.Succeeded)
            {
                if (_buttonH.TryExecute())
                {
                    _oldCommands.Add(_buttonH);
                }
            }

            if (_buttonK.Succeeded)
            {
                if (_buttonK.TryExecute())
                {
                    _oldCommands.Add(_buttonK);
                }
            }

            if (_buttonN.Succeeded)
            {
                if (_buttonN.TryExecute())
                {
                    _oldCommands.Add(_buttonN);
                }
            }

            if (_buttonM.Succeeded)
            {
                _buttonM.TryExecute();
            }
        }
    }
}