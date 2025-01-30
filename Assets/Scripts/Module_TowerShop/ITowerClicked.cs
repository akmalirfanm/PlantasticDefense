using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plantastic.Module_TowerShop
{
    public interface ITowerClicked
    {
        void StartTowerClicked(); // show range shoot of tower, show upgrade menu
        void EndTowerClicked(); // close range shoot and upgrade menu
    }
}
