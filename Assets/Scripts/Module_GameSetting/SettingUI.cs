using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Plantastic.Module_GameSetting
{
    public class SettingUI : MonoBehaviour
    {
        [SerializeField] private Button _sfxOnButton;
        [SerializeField] private Button _sfxOffButton;
        [SerializeField] private Button _bgmOnButton;
        [SerializeField] private Button _bgmOffButton;

        [SerializeField] private Button _backButton;
        [SerializeField] private Button _finishButton;
        [SerializeField] private GameObject _settingPanel;
        [SerializeField] private GameObject _sfxOffPanel;
        [SerializeField] private GameObject _bgmOffPanel;

        private void Awake()
        {
            SetAllButtonListener();

        }

        private void SetBackButtonListener(UnityAction listener) => SetButtonListener(_backButton, OnClickBackButton);
        private void SetFinishButtonListener(UnityAction listener) => SetButtonListener(_finishButton, OnClickFinishButton);
        private void SetSfxOffButtonListener(UnityAction listener) => SetButtonListener(_sfxOffButton, OnClickSfxButton);
        private void SetSfxOnButtonListener(UnityAction listener) => SetButtonListener(_sfxOnButton, OnClickSfxButton);
        private void SetBgmOnButtonListener(UnityAction listener) => SetButtonListener(_bgmOnButton, OnClickBgmButton);
        private void SetBgmOffButtonListener(UnityAction listener) => SetButtonListener(_bgmOffButton, OnClickBgmButton);

        public void SetButtonListener(Button button, UnityAction listener)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(listener);
        }

        public void OnClickBackButton()
        {
            _settingPanel.SetActive(false);
        }
        public void OnClickFinishButton()
        {
            PlayerPrefs.Save();
            _settingPanel.SetActive(false);
        }

        private void OnClickSfxButton()
        {
            EventManager.TriggerEvent("SwitchSfxValueMessage");
            if (GameSetting.instance.isSfxOn == true)
            {
                _sfxOffPanel.SetActive(false);

            }
            else
            {
                _sfxOffPanel.SetActive(true);

            }
        }

        private void OnClickBgmButton()
        {
            EventManager.TriggerEvent("SwitchBgmValueMessage");
            if (GameSetting.instance.isBgmOn == false)
            {
                _bgmOffPanel.SetActive(true);

            }
            else
            {
                _bgmOffPanel.SetActive(false);

            }
        }

        public void SetAllButtonListener()
        {
            SetBackButtonListener(OnClickBackButton);
            SetFinishButtonListener(OnClickFinishButton);
            SetSfxOffButtonListener(OnClickSfxButton);
            SetSfxOnButtonListener(OnClickSfxButton);
            SetBgmOffButtonListener(OnClickBgmButton);
            SetBgmOnButtonListener(OnClickBgmButton);
        }
    }
}

