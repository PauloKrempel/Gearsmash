using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadCreditos : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Creditos");
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(5f);
        Restart();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Load());
        }
    }
}
