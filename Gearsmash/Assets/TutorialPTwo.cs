using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TutorialPTwo : MonoBehaviour
{
    [Header("Configurações")]
    public bool FinishedTutorialEnemy = false;
    public GameObject TutorialEnemy;
    public static TutorialPTwo instance;

    [Header("Audio Tutorial")] public AudioSource aviso;
    public PlayableDirector Director;

    private void Awake()
    {
        instance = this;
        Director.played += Director_Played;
        Director.stopped += Director_Stoped;
    }

    private void Update()
    {
        if (FinishedTutorialEnemy)
        {
            StartTimeline();
            this.enabled = false;
        }
    }

    void Director_Played(PlayableDirector obj)
    {
        TutorialEnemy.SetActive(true);
    }
    void Director_Stoped(PlayableDirector obj)
    {
        TutorialEnemy.SetActive(false);
    }

    public void StartTimeline()
    {
        Director.Play();
    }
}
