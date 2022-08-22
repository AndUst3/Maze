using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class GoodBonus : Bonus, IFly, IFlick
    {
        public override void Awake()
        {
            base.Awake();

        }

        public override void Update()
        {
            Fly();
            Flick();
        }

        public void Fly()
        {
            Debug.Log("Bonus is flying");
        }

        public void Flick()
        {
            Debug.Log("Bonus is flicking");
        }

        protected override void Interaction()
        {
            IsInteractable = false;
        }
    }
}
