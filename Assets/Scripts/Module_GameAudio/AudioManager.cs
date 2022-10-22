using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Audio;
using Plantastic.Module_GameSetting;

namespace Plantastic.Module_GameAudio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        [SerializeField]
        private AudioSource _bgmSource;
        [SerializeField]
        private AudioSource _sfxSource;

        [SerializeField]
        private AudioClip[] clips;

        
        private UnityAction _onSfx;

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
        }
        private void Start()
        {
            _bgmSource.loop = true;
        }
        private void OnEnable()
        {
            EventManager.StartListening("SFXMessage", SfxContainer);
            EventManager.StartListening("BGMMessage", BgmContainer);
        }
        private void OnDisable()
        {
            
            EventManager.StopListening("SFXMessage", SfxContainer);
            EventManager.StopListening("BGMMessage", BgmContainer);
        }
        private void Update()
        {
            _bgmSource.mute = !GameSetting.instance.isBgmOn;
            _sfxSource.mute = !GameSetting.instance.isSfxOn;
        }
        public void PlaySfx(AudioClip clip)
        {
            _sfxSource.PlayOneShot(clip);
        }
        public void PlayBgm(AudioClip clip)
        {
           AudioSource _audio = gameObject.GetComponent<AudioSource>();
            _audio.clip = clip;
            _audio.Play();
            
        }
        public void SfxContainer(object name)
        {
            AudioClip a = Array.Find(clips, c => c.name == (string)name);

            if (a == null)
            {
                return;
            }
            PlaySfx(a);
        }
        public void BgmContainer(object name)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                _bgmSource.Stop();
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                _bgmSource.Stop();
                AudioClip a = Array.Find(clips, c => c.name == (string)name);
                
                if (a == null)
                {
                    return;
                }
                PlayBgm(a);
            }
            else
            {
                _bgmSource.Stop();
                
                AudioClip a = Array.Find(clips, c => c.name == (string)name);

                if (a == null)
                {
                    return;
                }
                PlayBgm(a);
            }
        }
    }
}
