using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage Struct
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    //Upgrade
    public int weaponLevel = 0;
    public SpriteRenderer spriteRenderer;

    //Swing

    private Animator animator;
    public float currentenergy;
    public float maxenergy;
    public float useofenergy;
    public WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;
    protected float wepCooldown = 1f;
    protected float wepLastUse;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            //if (coll.name != "Player" && coll.name != "Knight")
            //{
            //create a new damage object, then send it to fighter
            //}
            Damage dmg = new Damage()
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            //Debug.Log(coll);
            //Debug.Log(coll.tag);
            coll.SendMessage("RecieveDamage", dmg);
            

        }
    }
    protected override void Start()
    {
        currentenergy = maxenergy;
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();

        if (currentenergy > 1)
        {
           if(Input.GetKeyDown(KeyCode.Space))
            {
                Swing();
            }
        }
    }

    public void UseStamina(float amount)
    {
        if(currentenergy - amount >= 0)
        {
            currentenergy -= amount;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (currentenergy < maxenergy)
        {
            currentenergy += maxenergy / 100;
            if (currentenergy > maxenergy)
            {
                currentenergy = maxenergy;
            }
            yield return regenTick;
        }
    }
    private void Swing()
    {
        if (Time.time - wepLastUse > wepCooldown)
        {
            wepLastUse = Time.time;
            UseStamina(useofenergy);
        }
        animator.SetTrigger("Swing");
        SoundManager.PlaySound (SoundManager.Sound.PlayerAttack, transform.position);

    }

}
