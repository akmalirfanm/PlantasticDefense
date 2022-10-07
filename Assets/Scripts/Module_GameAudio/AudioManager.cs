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
        [SerializeField]
        private AudioClip _plantAttack1;
        [SerializeField]
        private AudioClip _plantAttack2;
        [SerializeField]
        private AudioClip _plantAttack3;
        [SerializeField]
        private AudioClip _plantAttack4;
        [SerializeField]
        private AudioClip _upgradeTower;
        [SerializeField]
        private AudioClip _boss;
        [SerializeField]
        private AudioClip _winCon;
        [SerializeField]
        private AudioClip _loseCon;

        private UnityAction _onButtonClick;
        private UnityAction _onEnemyDie;
        private UnityAction _onBuyTower;
        private UnityAction _onSellTower;
        private UnityAction _onPlantAttack1;
        private UnityAction _onPlantAttack2;
        private UnityAction _onPlantAttack3;
        private UnityAction _onPlantAttack4;
        private UnityAction _onUpgradeTower;
        private UnityAction _onBoss;
        private UnityAction _onWin;
        private UnityAction _onLose;

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
            _onPlantAttack1 = new UnityAction(OnPlantAttack1);
            _onPlantAttack2 = new UnityAction(OnPlantAttack2);
            _onPlantAttack3 = new UnityAction(OnPlantAttack3);
            _onPlantAttack4 = new UnityAction(OnPlantAttack4);
            _onUpgradeTower = new UnityAction(OnUpgradeTower);
            _onBoss = new UnityAction(OnBoss);
            _onWin = new UnityAction(OnWin);
            _onLose = new UnityAction(OnLose);
        }
        private void OnEnable()
        {
            EventManager.StartListening("ClickMessage", _onButtonClick);
            EventManager.StartListening("DieMessage", _onEnemyDie);
            EventManager.StartListening("BuyMessage", _onBuyTower);
            EventManager.StartListening("SellMessage", _onSellTower);
            EventManager.StartListening("Attack1Message", _onPlantAttack1);
            EventManager.StartListening("Attack2Message", _onPlantAttack2);
            EventManager.StartListening("Attack3Message", _onPlantAttack3);
            EventManager.StartListening("Attack4Message", _onPlantAttack4);
            EventManager.StartListening("UpgradeMessage", _onUpgradeTower);
            EventManager.StartListening("BossMessage", _onBoss);
            EventManager.StartListening("WinSFXMessage", _onWin);
            EventManager.StartListening("LoseSFXMessage", _onLose);
        }
        private void OnDisable()
        {
            EventManager.StopListening("ClickMessage", _onButtonClick);
            EventManager.StopListening("DieMessage", _onEnemyDie);
            EventManager.StopListening("BuyMessage", _onBuyTower);
            EventManager.StopListening("SellMessage", _onSellTower);
            EventManager.StopListening("Attack1Message", _onPlantAttack1);
            EventManager.StopListening("Attack2Message", _onPlantAttack2);
            EventManager.StopListening("Attack3Message", _onPlantAttack3);
            EventManager.StopListening("Attack4Message", _onPlantAttack4);
            EventManager.StopListening("UpgradeMessage", _onUpgradeTower);
            EventManager.StopListening("BossMessage", _onBoss);
            EventManager.StopListening("WinSFXMessage", _onWin);
            EventManager.StopListening("LoseSFXMessage", _onLose);

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
        public void OnPlantAttack1()
        {
            PlaySfx(_plantAttack1);
        }
        public void OnPlantAttack2()
        {
            PlaySfx(_plantAttack2);
        }
        public void OnPlantAttack3()
        {
            PlaySfx(_plantAttack3);
        }
        public void OnPlantAttack4()
        {
            PlaySfx(_plantAttack4);
        }
        public void OnUpgradeTower()
        {
            PlaySfx(_upgradeTower);
        }
        public void OnBoss()
        {
            PlaySfx(_boss);
        }
        public void OnWin()
        {
            PlaySfx(_winCon);
        }
        public void OnLose()
        {
            PlaySfx(_loseCon);
        }
    }
}

