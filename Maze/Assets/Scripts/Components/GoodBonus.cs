using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Maze
{
    public class GoodBonus : Bonus, IFlick
    {
        public event Action<int> AddPoint = delegate (int i) { };
        private Material _material;

        public override void Awake()
        {
            base.Awake();
            _material = Renderer.material;
            heightFly = Random.Range(1f, 4f);
        }

        public override void Update()
        {
            Fly();
            Flick();
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        protected override void Interaction()
        {
            IsInteractable = false;
        }
    }
}
