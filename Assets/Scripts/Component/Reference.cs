using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Reference
    {
        private Camera _mainCamera;
        public Camera MainCamera
        {
            get 
            { 
                if(!_mainCamera)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
            set { _mainCamera = value; }
        }
    }
}
