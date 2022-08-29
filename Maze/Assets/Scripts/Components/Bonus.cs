using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public abstract class Bonus : MonoBehaviour, IExecute, IFly
    {
        protected Color _color;
        private Renderer _renderer;
        private Collider _collider;

        private bool _isInteractable;
        public float heightFly;
        public float speedRotation;

        public bool IsInteractable 
        { 
            get => _isInteractable; 
            set
            {
                _isInteractable = value;
                _renderer.enabled = value;
                _collider.enabled = value;
            }  
        }

        public Renderer Renderer { get => _renderer; set => _renderer = value; }

        public virtual void Awake()
        {
            if (!TryGetComponent<Renderer>(out _renderer))
            {
                Debug.Log("No Renderer Component!");
            }
            if (!TryGetComponent<Collider>(out _collider))
            {
                Debug.Log("No Collider Component!");
            }   
            
            IsInteractable = true;
            _color = Random.ColorHSV();
            _renderer.sharedMaterial.color = _color;
        }

        private void OnTriggerEnter(Collider other)
        {
           if (other.CompareTag("Player"))
            {
                Interaction();
            }
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, heightFly), transform.position.z);
        }

        protected abstract void Interaction();
        public abstract void Update(); 
    }
}