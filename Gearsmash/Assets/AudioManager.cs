using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Button[] buttonsInterface;

    public bool isPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        while (!isPlay)
        {
            foreach (var btn in buttonsInterface)
            {
                btn.interactable = false;
            }
        }
    }
}
