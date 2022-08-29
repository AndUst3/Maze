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
        private int _health = 100;

        [SerializeField] private Unit _player;
        [SerializeField] private Bonus[] _bonusObj;
        [SerializeField] private Text _pointLabel;
        [SerializeField] private Text _gameOverLabel;
        [SerializeField] private Button _restartButton;

        private InputController _inputController;
        private ListExecuteObject _executeObject;
        private UIDisplayBonus _displayBonus;
        private UIDisplayGameOver _displayGameOver;

        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
                if (value <= 100 && value >= 0)
                {
                    _health = value;
                }
                else
                {
                    _health = 100;
                    Debug.Log("Wrong health value! Health = 100");
                }
            }
        }

        private void Awake()
        {
            Time.timeScale = 1f;

            _inputController = new InputController(_player);
            _executeObject = new ListExecuteObject(_bonusObj);
            _displayBonus = new UIDisplayBonus(_pointLabel);
            _displayGameOver = new UIDisplayGameOver(_gameOverLabel);

            _executeObject.AddExecuteObject(_inputController);

            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);

            foreach (var item in _bonusObj)
            {
                if (item is GoodBonus goodBonus)
                    goodBonus.AddPoint += AddPoint;

                if (item is BadBonus badBonus)
                    badBonus.OnDamage += OnDamage;
            }
        }

        private void AddPoint(int value)
        {
            _bonusCount += value;
            _displayBonus.Display(_bonusCount);
        } 

        private void OnDamage(int value)
        {
            Health -= 20;
        }

        private void GameOver()
        {
            _restartButton.gameObject.SetActive(false);
            Time.timeScale = 0f;
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