using System;
using UnityEngine;

namespace Maze
{
    public class GoodBonus : Bonus
    {
        public event Action<int> AddPoint = delegate (int i) { };

        public GoodBonus(ObjectView view) : base(view)
        {
            Init();
            view.Collide += Action;
        }

        private void Action(Player contactView)
        {
            Interaction();
        }

        public override void Update()
        {
            Fly();
            Flick();
        }

        protected override void Interaction()
        {
            IsInteractable = false;
            Debug.Log("TriggerEnter");
        }
    }
}
