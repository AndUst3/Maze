using UnityEngine;

namespace Maze
{
    public abstract class Unit : MonoBehaviour
    {
        public Transform _transform;
        public Rigidbody _rb;

        public virtual void Awake()
        {
            if (!TryGetComponent<Transform>(out _transform))
            {
                Debug.Log("No Transform Component!");
            }
            if (!TryGetComponent<Rigidbody>(out _rb))
            {
                Debug.Log("No Rigidbody Component!");
            }
        }

        public abstract void Move(float x, float y, float z);
    }
}