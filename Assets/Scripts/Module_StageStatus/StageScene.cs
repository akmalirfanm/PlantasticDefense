using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StageScene : MonoBehaviour
{
    [SerializeField] Transform stageListParent;
    [SerializeField] GameObject stageButton;

    private GameObject[] stageButtonContainer;

    private void Start()
    {
        var l = StageStatus.Instance.stageData.stage;
        stageButtonContainer = new GameObject[l.Length];
        for(int i = 0; i < l.Length; i++)
        {
            int j = i + 1;
            stageButtonContainer[i] = Instantiate(stageButton, stageListParent);
            stageButtonContainer[i].GetComponent<Button>().onClick.AddListener(()=>Listener(j));
            stageButtonContainer[i].GetComponentInChildren<TextMeshProUGUI>().text = "Stage " + j;

            if(!l[i].unlocked)
            {
                stageButtonContainer[i].GetComponent<Button>().interactable = false;
            }
        }
    }
    void Listener(int i)
    {
        SceneManager.LoadScene("Stage " + i);
    }
}
