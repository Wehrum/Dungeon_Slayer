using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : Collectable
{
   // public expCollect;
    public int expAmount = 5;
    public Animator animator;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            //GetComponent<SpriteRenderer>().sprite = expCollect;
            GameManager.instance.ShowText($"+ {expAmount} Exp.", 25, Color.yellow, transform.position, Vector3.up * 10, 1.5f);
            //Destroy(gameObject);
        }

    }
}
