using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        private AudioClip _buttonClick;
        [SerializeField]
        private AudioClip _enemyDie;
        [SerializeField]
        private AudioClip _buyTower;
        [SerializeField]
        private AudioClip _sellTower;

        private UnityAction _onButtonClick;
        private UnityAction _onEnemyDie;
        private UnityAction _onBuyTower;
        private UnityAction _onSellTower;

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
            _onButtonClick = new UnityAction(OnButtonClick);
            _onEnemyDie = new UnityAction(OnEnemyDie);
            _onBuyTower = new UnityAction(OnBuyTower);
            _onSellTower = new UnityAction(OnSellTower);
        }
        private void OnEnable()
        {
            EventManager.StartListening("ClickMessage", _onButtonClick);
            EventManager.StartListening("DieMessage", _onEnemyDie);
            EventManager.StartListening("BuyMessage", _onBuyTower);
            EventManager.StartListening("SellMessage", _onSellTower);
        }
        private void OnDisable()
        {
            EventManager.StopListening("ClickMessage", _onButtonClick);
            EventManager.StopListening("DieMessage", _onEnemyDie);
            EventManager.StopListening("BuyMessage", _onBuyTower);
            EventManager.StopListening("SellMessage", _onSellTower);
        }
        private void Update()
        {
            
        }
        public void PlaySfx(AudioClip clip)
        {
            _sfxSource.PlayOneShot(clip);
        }
        public void OnButtonClick()
        {
            PlaySfx(_buttonClick);
        }
        public void OnEnemyDie()
        {
            PlaySfx(_enemyDie);
        }
        public void OnBuyTower()
        {
            PlaySfx(_buyTower);
        }
        public void OnSellTower()
        {
            PlaySfx(_sellTower);
        }
    }
}

