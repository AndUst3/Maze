using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Player : Unit
    {
        private int _health = 100;
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
        public override void Awake()
        {
            base.Awake();
        }

        public override void Move(float x, float y, float z)
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3(x, y, z));
            }
        }
    }
}