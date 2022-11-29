using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Asteroids
{
    public class ScoreManager : MonoBehaviour
    {
        private ListExecuteObject _interactiveObject;
        private Reference _reference;
        private ViewBonus _viewBonus;
        private ViewEndGame _viewEndGame;

        private CameraController _cameraController;

        private int _bonusCount;

        [SerializeField] private GoodBonus goodBonus;
        [SerializeField] private BadBonus badBonus;

        [SerializeField] private GameObject _player;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _pause;
        void Awake()
        {
            Time.timeScale = 1f;
            _reference = new Reference();

            _cameraController = new CameraController(_player.transform, _reference.MainCamera.transform);
            _interactiveObject = new ListExecuteObject();

            _viewBonus = new ViewBonus(_reference.BonusLabel);
            _viewEndGame = new ViewEndGame(_reference.EndGameLabel);


            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);

            _interactiveObject.AddExecuteObject(_cameraController);

            foreach (var item in _interactiveObject)
            {
                if (item is GoodBonus goodBonus)
                {
                    goodBonus.AddPoints += AddBonus;
                }
                if (item is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayer += _viewEndGame.GameOver;
                    badBonus.OnCaughtPlayer += CaughtPlayer;
                }
            }
        }

        private void CaughtPlayer(string value, Color color)
        {
            _restartButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log(name);
        }

        private void CaughtPlayerWin(int value)
        {
            _restartButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void AddBonus(int value)
        {
            _bonusCount += value;
            _viewBonus.Display(Convert(_bonusCount));
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
            
            //if (_bonusCount >= 5)
            //{
            //    CaughtPlayerWin(_bonusCount);
            //    _viewEndGame.GameOverWin(_bonusCount);
            //}
                

        }   
            public string Convert(long bytes)
            {
                    var ordinals = new[] { "", "K", "M", "G", "T", "P", "E" };
                    float rate = bytes;
                    var _bonusCount = 0;
                    while (rate >= 1000)
                    {
                        rate /= 1000;
                        _bonusCount++;
                    }
                
                    return string.Format("{0} {1}",
                    Mathf.RoundToInt(rate),
                    ordinals[_bonusCount]);
            }
    }
}