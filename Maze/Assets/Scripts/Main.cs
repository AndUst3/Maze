using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private InputController _inputController;
        private ListExecuteObject _executeObject;

        [SerializeField] private Unit _player;

        private void Awake()
        {
            _inputController = new InputController(_player);
            _executeObject = new ListExecuteObject();

            _executeObject.AddExecuteObject(_inputController);
        }
        private void Update()
        {
            for (int i = 0; i < _executeObject.Lenght; i++)
            {
                if (_executeObject.InteractivObject[i] == null)
                {
                    continue;
                }
                _executeObject.InteractivObject[i].Update();
            }
                     
        }
    }
}