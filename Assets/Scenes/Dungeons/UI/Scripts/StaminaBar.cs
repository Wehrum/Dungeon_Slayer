using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : Weapon
{
    private Image Bar;
    // Start is called before the first frame update
    void Awake()
    {
        Bar = GetComponent<Image>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        GameObject go = GameObject.Find("Weapon1");
        Weapon stamina = go.GetComponent<Weapon>();
        float energy = stamina.currentenergy;
        float maxenergy = stamina.maxenergy;
        Bar.fillAmount = energy / maxenergy;
    }
}
