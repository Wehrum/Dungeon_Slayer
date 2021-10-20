using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    //Damage
    public float damage = 1f;
    public float pushForce = 5;
    public Animator animator;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            //create a new damage object, then send it to fighter                
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };            
            coll.SendMessage("RecieveDamage", dmg);
            SoundManager.PlaySound(SoundManager.Sound.EnemyHit, transform.position);

        }

    }
}


