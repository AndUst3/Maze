using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class BadBonus : Bonus, IFly, IRotation
    {
        public override void Awake()
        {
            base.Awake();

        }

        public override void Update()
        {
            Fly();
            Rotate();
        }
        public void Fly()
        {
            Debug.Log("Bonus is flying");
        }

        public void Rotate()
        {
            Debug.Log("Bonus is rotating");
        }

        protected override void Interaction()
        {
            IsInteractable = false;
            
        }
    }
}
