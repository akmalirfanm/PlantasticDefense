using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] GameObject gameplayUI;

    private void Start()
    {
        Time.timeScale = 0f;
        tutorialPanel.SetActive(true);
        gameplayUI.SetActive(false);
    }
    public void TutorialEnd()
    {
        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;
        gameplayUI.SetActive(true);
    }
}
