using System;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
    public class UIDisplayGameOver
    {
        private Text _gameOverLabel;

        public UIDisplayGameOver(Text gameOverLabel)
        {
            _gameOverLabel = gameOverLabel;
            _gameOverLabel.text = String.Empty;
        }

        public void GameOver(string name, Color color)
        {
            _gameOverLabel.text = $"Mission failed. Bonus name: {name}, color: {color}";
        }
    }
}