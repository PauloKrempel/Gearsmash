using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1 = 5f;
    [SerializeField]bool isCooldown = false;
    public KeyCode ability1;
    [Header("Ability 2")]
    public Image abilityImage2;
    public float cooldown2 = 5f;
    [SerializeField]bool isCooldown2 = false;
    public KeyCode ability2;
    [Header("Ability 3")]
    public Image abilityImage3;
    public float cooldown3 = 5f;
    [SerializeField]bool isCooldown3 = false;
    public KeyCode ability3;
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
    }

    void Update()
    {
        if (isCooldown == true)
        {
            Ability1();
        }

        if (isCooldown2 == true)
        {
            Ability2();
        }

        if (isCooldown3 == true)
        {
            Ability3();
        }
    }
    public void Ability1(){
        if(isCooldown == false)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;
        }
        if(isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
    public void Ability2(){
        if(isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }
        if(isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if(abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }
    public void Ability3(){
        if(isCooldown3 == false)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
        }
        if(isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if(abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }
}
