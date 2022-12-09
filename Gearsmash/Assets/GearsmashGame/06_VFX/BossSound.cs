using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSound : MonoBehaviour
{
    public AudioSource BackMusic;

    public GameObject AudioBoss;
    public bool enter = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !enter)
        {
            BackMusic.Stop();
            AudioBoss.SetActive(true);
        }
    }
}
