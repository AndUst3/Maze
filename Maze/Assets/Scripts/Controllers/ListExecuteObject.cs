using System.Collections;
using System;
using UnityEngine;

namespace Maze
{
    public class ListExecuteObject
    {
        private IExecute[] _interactivObject;
        public int Lenght { get { return _interactivObject.Length; } }

        public IExecute[] InteractivObject { get => _interactivObject; set => _interactivObject = value; }

        public ListExecuteObject()
        {

        }

        public void AddExecuteObject(IExecute execute)
        {
            if (InteractivObject == null)
            {
                InteractivObject = new[] { execute };
                return;
            }

            Array.Resize(ref _interactivObject, Lenght + 1);
            InteractivObject[Lenght - 1] = execute;
        } 
    }
}