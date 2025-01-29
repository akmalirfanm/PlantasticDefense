using System;
using UnityEngine;

public class AudioSetting : MonoBehaviour
{
    public static event Action<float, float> OnSettingChanged;

    private const string SFX_VOLUME_KEY = "SFXVolume";
    private const string BGM_VOLUME_KEY = "BGMVolume";

    public GameObject onSignSfx;
    public GameObject offSignSfx;
    public GameObject onSignBgm;
    public GameObject offSignBgm;

    private float sfxVolume;
    private float bgmVolume;

    private void Start()
    {
        LoadAudioSettings();
        UpdateUI();
        ApplySettings();
    }

    public void ToggleSfx()
    {
        sfxVolume = sfxVolume > 0f ? 0f : 1f;
        UpdateUI();
        SaveAudioSettings();
        ApplySettings();
    }

    public void ToggleBgm()
    {
        bgmVolume = bgmVolume > 0f ? 0f : 1f;
        UpdateUI();
        SaveAudioSettings();
        ApplySettings();
    }

    private void ApplySettings()
    {
        OnSettingChanged?.Invoke(sfxVolume, bgmVolume);
    }

    private void SaveAudioSettings()
    {
        PlayerPrefs.SetFloat(SFX_VOLUME_KEY, sfxVolume);
        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, bgmVolume);
        PlayerPrefs.Save();
    }

    private void LoadAudioSettings()
    {
        sfxVolume = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 1f); // Default: On
        bgmVolume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, 1f); // Default: On
    }

    private void UpdateUI()
    {
        if (onSignSfx != null && offSignSfx != null)
        {
            onSignSfx.SetActive(sfxVolume > 0f);
            offSignSfx.SetActive(sfxVolume <= 0f);
        }

        if (onSignBgm != null && offSignBgm != null)
        {
            onSignBgm.SetActive(bgmVolume > 0f);
            offSignBgm.SetActive(bgmVolume <= 0f);
        }
    }

    public bool IsSfxOn()
    {
        return sfxVolume > 0f;
    }

    public bool IsBgmOn()
    {
        return bgmVolume > 0f;
    }
}
