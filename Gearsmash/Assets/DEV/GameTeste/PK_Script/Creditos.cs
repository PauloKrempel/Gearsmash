using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class Creditos : MonoBehaviour
{
    public DOTweenAnimation _doTweenAnimation;
    void Start()
    {
        _doTweenAnimation.DOPlay();
        StartCoroutine(Aguarde());
    }

    IEnumerator Aguarde()
    {
        yield return new WaitForSeconds(4);
        transform.DOMoveY(1800, 30);
    }
}
