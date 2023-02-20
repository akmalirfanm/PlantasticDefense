using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Resource
{
    public class Resource : MonoBehaviour
    {
        public static Resource Instance;

        public int _totalResource { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
                Destroy(gameObject);
        }
        
        public bool IsResourceEnough(int value)
        {
            if (_totalResource - value >= 0)
                return true;
            else
                return false;
        }
        public void SpentResource(int value)
        {
            _totalResource -= value;
        }
        public void AddResource(int value)
        {
            _totalResource += value;
        }
    }
}

