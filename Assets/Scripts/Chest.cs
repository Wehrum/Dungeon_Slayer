using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int goldAmount;
    public Animator animator;
    protected override void OnCollect()
    {
        if (!collected)
        {
           
            collected = true;
            animator.SetTrigger("ChestCollect");            
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            goldAmount = UnityEngine.Random.Range(1, 15);
            GameManager.instance.ShowText($"+ {goldAmount} Gold", 25, Color.yellow, transform.position, Vector3.up * 10, 1.5f);
            SoundManager.PlaySound(SoundManager.Sound.Chest, transform.position);
            
        }

    }
}
