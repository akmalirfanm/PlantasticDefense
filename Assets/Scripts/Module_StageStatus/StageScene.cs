using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Plantastic.Module_StageStatus
{
    public class StageScene : MonoBehaviour
    {
        [SerializeField] Transform stageListParent;
        [SerializeField] GameObject stageButton;

        private GameObject[] stageButtonContainer;

        private void Start()
        {
            var l = StageStatus.Instance.stageData.stage;
            stageButtonContainer = new GameObject[l.Length];
            for (int i = 0; i < l.Length; i++)
            {
                stageButtonContainer[i] = Instantiate(stageButton, stageListParent);
                stageButtonContainer[i].GetComponent<Button>().onClick.AddListener(() => Listener(l[i].name));
                stageButtonContainer[i].GetComponentInChildren<TextMeshProUGUI>().text = l[i].name;

                if (!l[i].unlocked)
                {
                    stageButtonContainer[i].GetComponent<Button>().interactable = false;
                }
            }
        }
        void Listener(string nameStage)
        {
            SceneManager.LoadScene(nameStage);
        }
    }
}

