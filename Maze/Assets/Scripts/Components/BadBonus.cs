using System;
using UnityEngine;

namespace Maze
{
    public class BadBonus : Bonus
    {
        public event Action<int> OnDamage = delegate (int i) { };
        public event Action<string, Color> OnGameOver = delegate(string str, Color color) { };

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
            OnDamage?.Invoke(20);
            IsInteractable = false;
            Debug.Log("TriggerEnter");
        }

        public override void Update()
        {
            Fly();
            Rotate();
        }
    }
}
