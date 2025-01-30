using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Plantastic.Module_GameSetting
{
    public class GameSetting : MonoBehaviour
    {
        public static GameSetting instance;

        public bool isBgmOn { get; private set; }
        public bool isSfxOn { get; private set; }

        private UnityAction onSwitchBgmValue;
        private UnityAction onSwitchSfxValue;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            onSwitchBgmValue = new UnityAction(ToggleMusic);
            onSwitchSfxValue = new UnityAction(ToggleEffect);
        }

        private void OnEnable()
        {
            LoadData();
            EventManager.StartListening("SwitchBgmValueMessage", onSwitchBgmValue);
            EventManager.StartListening("SwitchSfxValueMessage", onSwitchSfxValue);
            Debug.Log("BGM status: " + isBgmOn);
            Debug.Log("SFX status: " + isSfxOn);
        }

        private void OnDisable()
        {
            EventManager.StopListening("SwitchBgmValueMessage", onSwitchBgmValue);
            EventManager.StopListening("SwitchSfxValueMessage", onSwitchSfxValue);
        }
        private void ToggleMusic()
        {
            isBgmOn = !isBgmOn;
            if (isBgmOn)
            {
                PlayerPrefs.SetInt("BGM", 1); //BGM on
            }
            else
            {
                PlayerPrefs.SetInt("BGM", 0); //BGM off
            }
            Debug.Log("BGM status: " + isBgmOn);
        }

        private void ToggleEffect()
        {
            isSfxOn = !isSfxOn;
            if (isSfxOn)
            {
                PlayerPrefs.SetInt("SFX", 1); //SFX on
            }
            else
            {
                PlayerPrefs.SetInt("SFX", 0); //SFX off
            }
            Debug.Log("SFX status: " + isSfxOn);
        }

        private void LoadData()
        {
            int bgmDataHolder = PlayerPrefs.GetInt("BGM");
            if (bgmDataHolder == 1)
            {
                isBgmOn = true;
                //isBgmOn = false;
            }
            else
            {
                isBgmOn = false;
                //isBgmOn = true;
            }
            int sfxDataHolder = PlayerPrefs.GetInt("SFX");
            if (sfxDataHolder == 1)
            {
                isSfxOn = true;
                //isSfxOn = false;
            }
            else
            {
                isSfxOn = false;
                //isSfxOn = true;
            }
        }
    }
}

