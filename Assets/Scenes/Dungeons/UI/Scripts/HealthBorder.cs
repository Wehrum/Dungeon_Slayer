using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBorder : Fighter
{
    //timer script varibales
    public float spriteBlinkingTimer = 1.0f;
    public float spriteBlinkingMiniDuration = 1.0f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;
    private Image border;
    private Image bar;
    private Image backbar;


    // Start is called before the first frame update
    void Start()
    {
        //Finding components and setting public variables
        border = GetComponent<Image>();

        GameObject healthbar = GameObject.Find("HealthBar");
        bar = healthbar.GetComponent<Image>();

        GameObject healthbarback = GameObject.Find("HealthBarBackground");
        backbar = healthbarback.GetComponent<Image>();

    }

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            border.enabled = true;
            bar.enabled = true;
            backbar.enabled = true;
                                                                          
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (border.enabled == true)
            {
                border.enabled = false;
                bar.enabled = false;
                backbar.enabled = false;
            }
            else
            {
               border.enabled = true;
                bar.enabled = true;
                backbar.enabled = true;
            }
        }
    }


    void Update()
    {
        GameObject go1 = GameObject.Find("Player");
        Fighter test1 = go1.GetComponent<Fighter>();
        float health = test1.HitPoint;
        if (health <= 2)
        {
            SpriteBlinkingEffect();
            if (health > 2)
            {
                border.enabled = true;
                bar.enabled = true;
                backbar.enabled = true;
            }
        }
    }
}
