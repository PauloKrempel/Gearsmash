using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TutorialPU : MonoBehaviour
{
    
    [Header("Caracteristicas Raycast")]
    [SerializeField][Range(0f, 15f)][Tooltip("Range do raio que atingira o enemy")] float rayLength = 10f;
    public bool FoundEnemy = false;
    private LayerMask LayerEnemeyTutorial;
    private bool FinishedTutorialEnemy = false;
    public GameObject TutorialEnemy;
    

    [Header("Audio Tutorial")] public AudioSource aviso;
    public PlayableDirector Director;

    [Header("Botões")] public GameObject[] btnSkills;

    private void Awake()
    {
        // Director = GetComponent<PlayableDirector>();
        Director.played += Director_Played;
        Director.stopped += Director_Stoped;
    }

    private void Start()
    {
        LayerEnemeyTutorial = LayerMask.GetMask("EnemyTutorial");
        
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, rayLength, LayerEnemeyTutorial);
        if (hit.collider != null && !FoundEnemy && !FinishedTutorialEnemy)
        {
            StartTimeline();
            Debug.LogError("Encontrei..");
            FinishedTutorialEnemy = true;
            //Time.timeScale = Time.timeScale == 1.0f ? 0.0f : 1.0f;
        }

        if (FinishedTutorialEnemy)
        {
            this.enabled = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 dir = transform.TransformDirection(Vector3.right) * rayLength;
        Gizmos.DrawRay(transform.position, dir);
    }

    public void Despausar()
    {
        Time.timeScale = Time.timeScale == 1.0f ? 0.0f : 1.0f;
    }

    public void ShowSkills()
    {
        foreach (var btn in btnSkills)
        {
            btn.SetActive(true);
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
