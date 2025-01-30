using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Trailer : MonoBehaviour
{
    public string nameScene = "hills";


    private VideoPlayer vp;
    private double time;
    private double currentTime;

    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        time = vp.clip.length;
        EventManager.TriggerEvent("BGMMessage", "Main Menu");
    }

    void Update()
    {
        CheckVideoOver();
    }
    void CheckVideoOver()
    {
        currentTime = vp.time;
        if (currentTime >= time-0.3f)
        {
            SceneManager.LoadScene(nameScene);
        }
    }

}
