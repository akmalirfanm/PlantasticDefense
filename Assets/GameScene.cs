using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
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


    private void OnEnable()
    {
        EventManager.StartListening("UpdateHP", OnUpdateHP);
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
        }

        if(condition == "lose")
        {
            nextButton.gameObject.SetActive(false);
        }
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

    }
}
