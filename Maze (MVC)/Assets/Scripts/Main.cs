using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private int _bonusCount;

        [SerializeField] private Unit _player;
        [SerializeField] private ObjectView[] _bonusView;
        [SerializeField] private Bonus[] _bonusObj;
        [SerializeField] private Text _pointLabel;
        [SerializeField] private Text _gameOverLabel;
        [SerializeField] private Button _restartButton;

        private InputController _inputController;
        private CameraController _cameraController;
        private ListExecuteObject _executeObject;
        private UIDisplayBonus _displayBonus;
        private UIDisplayGameOver _displayGameOver;

        private void Awake()
        {
            Time.timeScale = 1f;

            _bonusObj = new Bonus[_bonusView.Length];

            for (int i = 0; i < _bonusView.Length; i++)
            {
                if (_bonusView[i].type == Type.good)
                {
                    _bonusObj[i] = new GoodBonus(_bonusView[i]);
                }
                else if (_bonusView[i].type == Type.bad)
                {
                    _bonusObj[i] = new BadBonus(_bonusView[i]);
                }
            }

            _inputController = new InputController(_player);
            _cameraController = new CameraController(_player._transform, Camera.main.transform); 
            _executeObject = new ListExecuteObject(_bonusObj);
            _displayBonus = new UIDisplayBonus(_pointLabel);
            _displayGameOver = new UIDisplayGameOver(_gameOverLabel);

            _executeObject.AddExecuteObject(_inputController);
            _executeObject.AddExecuteObject(_cameraController);

            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);

            foreach (var item in _bonusObj)
            {
                if (item is GoodBonus goodBonus)
                    goodBonus.AddPoint += AddPoint;

                if (item is BadBonus badBonus)
                {
                    badBonus.OnGameOver += GameOver;
                    badBonus.OnGameOver += _displayGameOver.GameOver;
                }
            }
        }

        private void GameOver(string value, Color color)
        {
            _restartButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        private void AddPoint(int value)
        {
            _bonusCount += value;
            _displayBonus.Display(_bonusCount);
        } 

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void Update()
        {
            for (int i = 0; i < _executeObject.Lenght; i++)
            {
                if (_executeObject[i] == null)
                {
                    continue;
                }
                _executeObject[i].Update();
            }           
        }
    }
}