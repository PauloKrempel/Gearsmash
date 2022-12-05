using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float life;
    private float startLife;
    private SpriteRenderer spr;
    
    public Image lifeImage;

    private void Start()
    {
        startLife = life;
        spr = GetComponent<SpriteRenderer>();
        lifeImage.type = Image.Type.Filled;
        lifeImage.fillMethod = Image.FillMethod.Horizontal;
        lifeImage.fillOrigin = (int)Image.OriginHorizontal.Left;

    }

    private void Update()
    {
        lifeImage.fillAmount = (life / startLife);
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        StartCoroutine(Damage());
    }

    IEnumerator Damage()
    {
        spr.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spr.color = Color.white;
    }
}
