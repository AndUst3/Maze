using System;
using UnityEngine.UI;

namespace Maze
{
    public class UIDisplayBonus
    {
        public Text _pointLabel;
        public UIDisplayBonus(Text pointsLabel)
        {
            _pointLabel = pointsLabel;
            _pointLabel.text = String.Empty;
        }

        public void Display(int value)
        {
            _pointLabel.text = $"������� �������: {value}";
        }
    }
}