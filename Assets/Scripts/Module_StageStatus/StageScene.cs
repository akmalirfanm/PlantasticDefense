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
        [SerializeField] Button backButton;

        private GameObject[] stageButtonContainer;

        private void Awake()
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(BackButton);
        }

        void Start()
        {
            var l = StageStatus.Instance.stageData.stage;
            stageButtonContainer = new GameObject[l.Length];
            for (int i = 0; i < l.Length; i++)
            {
                stageButtonContainer[i] = Instantiate(stageButton, stageListParent);
                string stage = l[i].nameScene;
                stageButtonContainer[i].GetComponentInChildren<Button>().onClick.AddListener(()=> Listener(stage));
                stageButtonContainer[i].GetComponentInChildren<TextMeshProUGUI>().text = l[i].name;
                stageButtonContainer[i].GetComponentInChildren<Image>().sprite = l[i].iconImage;

                if (!l[i].unlocked)
                {
                    stageButtonContainer[i].GetComponentInChildren<Button>().interactable = false;
                }
            }
        }
        void Listener(string nameStage)
        {
            SceneManager.LoadScene(nameStage);
        }

        void BackButton()
        {
            SceneManager.LoadScene("Home");
        }
    }
}

