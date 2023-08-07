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
        [SerializeField] Button stage1Button;
        [SerializeField] Button stage2Button;
        [SerializeField] Button backButton;

        [SerializeField] string stage1NameScene;
        [SerializeField] string stage2NameScene;

        private void Awake()
        {
            AddListener();
        }

        void BackButton()
        {
            SceneManager.LoadScene("Home");
        }
        private void AddListener()
        {
            backButton.onClick.AddListener(BackButton);
            stage1Button.onClick.AddListener(() => SceneManager.LoadScene(stage1NameScene));
            stage1Button.onClick.AddListener(() => SceneManager.LoadScene(stage2NameScene));
        }
    }
}

