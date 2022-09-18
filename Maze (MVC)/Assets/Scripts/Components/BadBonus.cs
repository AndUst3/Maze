using System;
using UnityEngine;

namespace Maze
{
    public class BadBonus : Bonus
    {
        public event Action<string, Color> OnGameOver = delegate(string name, Color color) { };

        public BadBonus(ObjectView view) : base(view)
        {
            Init();
            view.Collide += Action;
        }

        private void Action(Player contactView)
        {
            Interaction();
        }

        protected override void Interaction()
        {
            OnGameOver?.Invoke(_view.name, _color);
            IsInteractable = false;
        }
    }
}
