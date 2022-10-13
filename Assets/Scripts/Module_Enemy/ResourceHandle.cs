using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_Enemy
{
    public class ResourceHandle : MonoBehaviour
    {
        public int resource;

        public void AddResource(int value)
        {
            resource += value;
        }
    }
}

