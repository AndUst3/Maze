using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Maze
{
    public class BadBonus : Bonus, IRotation
    {
        public event Action<int> OnDamage = delegate (int i) { };
        public event Action<string, Color> OnGameOver = delegate(string str, Color color) { };

        private Material _material;

        public override void Awake()
        {
            base.Awake();
            _material = Renderer.material;
            heightFly = Random.Range(1f, 5f);
            speedRotation = Random.Range(10f, 20f);
        }

        public override void Update()
        {
            Fly();
            Rotate();
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * speedRotation), Space.World);
        }

        protected override void Interaction()
        {
            OnGameOver?.Invoke(gameObject.name, _color);
            IsInteractable = false;
        }
    }
}
