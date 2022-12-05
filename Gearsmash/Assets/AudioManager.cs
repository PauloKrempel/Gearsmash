using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameObject[] buttonsInterface;

    public AudioSource tutorialP1;
    public AudioSource tutorialP2;
    

 
    public bool isPlay = false;

    public bool finalTutorialP1 = false;
    // Start is called before the first frame update
    void Start()
    {
        //tutorialP1.Play();
        if (!isPlay)
        {
            foreach (GameObject btn in buttonsInterface)
            {
                btn.SetActive(false);

            }
        }
        
    }
    void Update()
    {
        if(isPlay && !finalTutorialP1)
        {
            buttonsInterface[0].SetActive(true); //esquerda
            buttonsInterface[1].SetActive(true); //direita
            buttonsInterface[2].SetActive(true); //cima
            buttonsInterface[3].SetActive(true); //Ataque basico
            finalTutorialP1 = true;
            Debug.LogError("Hora de ativar");
            Debug.LogError(buttonsInterface[4].name);

        }
    }

    public void StartMove()
    {
        isPlay = true;
        Debug.LogError("Entrou no tutorial");
    }
}
