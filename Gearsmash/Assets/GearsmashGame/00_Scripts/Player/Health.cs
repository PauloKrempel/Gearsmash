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
    private bool isDie = false;
    private bool showGameOver = false;
    public GameObject[] btnMove;
    public GameObject GameOver;

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
        if (life <= 0 && !isDie)
        {
            foreach (var btn in btnMove)
            {
                btn.SetActive(false);
                
            }
            
            isDie = true;
            showGameOver = true;
        }

        if (isDie && showGameOver)
        {
            GameOver.SetActive(true);
        }
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        StartCoroutine(Damage());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Lanca"))
        {
            life -= 25f;
        }

        if (collision.collider.CompareTag("Espinhos"))
        {
            life -= 10f;
        }

        if (collision.collider.CompareTag("campo"))
        {
            life -= 50f;
        }
    }

    IEnumerator Damage()
    {
        spr.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spr.color = Color.white;
    }
}
