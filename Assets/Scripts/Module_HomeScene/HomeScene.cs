using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Plantastic.Module_HomeScene
{
    public class HomeScene : MonoBehaviour
    {
        [SerializeField]
        private Button _playButton;
        [SerializeField]
        private Button _quitButton;
        [SerializeField]
        private Button _settingButton;
        [SerializeField]
        private GameObject settingPanel;

        private void Awake()
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(OpenStageSelect);
            _settingButton.onClick.RemoveAllListeners();
            _settingButton.onClick.AddListener(OpenSettingPanel);
            _quitButton.onClick.RemoveAllListeners();
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void OpenStageSelect()
        {
            SceneManager.LoadScene("StageSelect");
        }
        private void OpenSettingPanel()
        {
            settingPanel.SetActive(true);
        }
        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
