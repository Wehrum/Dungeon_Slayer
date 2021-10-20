using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : Fighter
{
    private const float Damaged_Health_Fade_Timer_Max = 1f;

    private Image Bar;
    private Image backbar;
    private float damagedHealthFadeTimer;
    private Color damagedColor;

    //simple script that will update health bar depending on player health :)
    void Start()
    {
        //grabs healthbar image
    }

    private void Awake()
    {
        Bar = GetComponent<Image>();
        GameObject healthbarback = GameObject.Find("HealthBarBackground");
        backbar = healthbarback.GetComponent<Image>();
        damagedColor = backbar.color;
        damagedColor.a = 0;
        backbar.color = damagedColor;

    }
    void Update()
    {
        if (damagedColor.a > 0)
        {
            damagedHealthFadeTimer -= Time.deltaTime;
            if (damagedHealthFadeTimer < 0)
            {
                float fadeAmount = 5f;
                damagedColor.a -= fadeAmount * Time.deltaTime;
                backbar.color = damagedColor;
            }
        }
        //Finds player object and connects the variable hitpoint to my variable
        GameObject go = GameObject.Find("Player");
        Player player = go.GetComponent<Player>();
        float health = player.HitPoint;
        float maxhealth = player.MaxHitPoint;
        Bar.fillAmount = health / maxhealth;
        if (damagedColor.a <= 0)
        {
            backbar.fillAmount = Bar.fillAmount;
            damagedColor.a = 1;
            backbar.color = damagedColor;
            damagedHealthFadeTimer = Damaged_Health_Fade_Timer_Max;
        }
    }
}
