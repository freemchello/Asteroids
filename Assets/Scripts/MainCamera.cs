using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Asteroids
{
    public class MainCamera : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        private CameraController _cameraController;
        private Reference _reference;
        private ListExecuteObject _interactiveObject;

        private void Awake()
        {
            _reference = new Reference();
            _cameraController = new CameraController(_player.transform, _reference.MainCamera.transform);
            _interactiveObject = new ListExecuteObject();
            _interactiveObject.AddExecuteObject(_cameraController);
        }
        void Update()
        {

            for (int i = 0; i < _interactiveObject.Lenght; i++)
            {
                if (_interactiveObject[i] == null)
                {
                    continue;
                }

                _interactiveObject[i].Update();
            }
        }
    }
}