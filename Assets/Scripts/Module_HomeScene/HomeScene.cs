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

        private void Awake()
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(OpenStageSelect);
            _quitButton.onClick.RemoveAllListeners();
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void OpenStageSelect()
        {
            SceneManager.LoadScene("StageSelect");
        }
        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
