using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Plantastic.Module_TowerShop;
using TMPro;

public class GameScene : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI hp_Text;

    [SerializeField]
    private Image hpFill;

    [SerializeField]
    private Button pauseButton;

    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private Button retryButton;

    [SerializeField]
    private Button homeButton;

    [SerializeField]
    private Button nextButton;

    [SerializeField]
    private GameObject gameplayPanel;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject resultPanel;

    [SerializeField]
    private Image resultPanelImage;
    [SerializeField]
    private Sprite resultWinSprite;
    [SerializeField]
    private Sprite resultLoseSprite;
    [SerializeField]
    private TextMeshProUGUI unit_deployed_text;
    [SerializeField]
    private TextMeshProUGUI killed_enemies_text;
    [SerializeField]
    private TextMeshProUGUI rank_text;

    private float currentHp;
    private int enemiesKilled;

    private void Awake()
    {
        pauseButton.onClick.RemoveAllListeners();
        pauseButton.onClick.AddListener(OnPause);


        resumeButton.onClick.RemoveAllListeners();
        resumeButton.onClick.AddListener(OnResume);


        mainMenuButton.onClick.RemoveAllListeners();
        mainMenuButton.onClick.AddListener(GoToMainMenu);


        retryButton.onClick.RemoveAllListeners();
        retryButton.onClick.AddListener(RestartScene);


        homeButton.onClick.RemoveAllListeners();
        homeButton.onClick.AddListener(GoToMainMenu);


        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(Next);
    }

    private void Start()
    {
        EventManager.TriggerEvent("BGMMessage", "Cutscene");
    }
    private void OnEnable()
    {
        EventManager.StartListening("UpdateHP", OnUpdateHP);
        EventManager.StartListening("EnemyDie", CountEnemyKilled);
    }
    private void OnDisable()
    {
        EventManager.StopListening("UpdateHP", OnUpdateHP);
    }

    private void OnPause()
    {
        Time.timeScale = 0;
        ShowPause();
    }

    private void OnResume()
    {
        Time.timeScale = 1;
        ShowGameplay();
    }

    private void OnUpdateHP(object hp)
    {
        float _hp = (float)hp;
        hpFill.fillAmount = _hp / 100;
        hp_Text.text = _hp.ToString();

        currentHp = _hp;
    }

    private void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }

    private void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowResult(string condition)
    {
        Time.timeScale = 0;
        gameplayPanel.SetActive(false);
        pausePanel.SetActive(false);
        resultPanel.SetActive(true);

        if(condition == "win")
        {
            nextButton.gameObject.SetActive(true);
            resultPanelImage.sprite = resultWinSprite;
            int _unit = FindObjectOfType<TowerManager>().TowerDeployed;
            unit_deployed_text.text = _unit.ToString();
            killed_enemies_text.text = enemiesKilled.ToString();
            rank_text.text = CheckRank(currentHp);
        }

        if(condition == "lose")
        {
            nextButton.gameObject.SetActive(false);
            resultPanelImage.sprite = resultLoseSprite;
            int _unit = FindObjectOfType<TowerManager>().TowerDeployed;
            unit_deployed_text.text = _unit.ToString();
            killed_enemies_text.text = enemiesKilled.ToString();
            rank_text.text = "F";
        }
    }
    private string CheckRank(float HP)
    {
        if (HP <= 100 && HP >= 91)
            return "S";
        else if (HP >= 76 && HP <= 90)
            return "A";
        else if (HP >= 61 && HP <= 75)
            return "B";
        else if (HP >= 46 && HP <= 60)
            return "C";
        else if (HP >= 31 && HP <= 45)
            return "D";
        else
            return "F";
    }
    private void CountEnemyKilled(object n)
    {
        enemiesKilled++;
    }

    private void ShowPause()
    {
        gameplayPanel.SetActive(false);
        pausePanel.SetActive(true);
        resultPanel.SetActive(false);
    }

    private void ShowGameplay()
    {
        gameplayPanel.SetActive(true);
        pausePanel.SetActive(false);
        resultPanel.SetActive(false);
    }

    private void Next()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("dessert");
    }
}
