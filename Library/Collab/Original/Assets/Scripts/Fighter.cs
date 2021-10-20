using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Fighter : MonoBehaviour
{
    //Resources
    public float hitPoint = 10f;
    public float maxHitPoint = 10f;
    public float pushRecoverySpeed = .2f;
    public ParticleSystem _particleSystem;
    public float energy = 10f;

    //play animation
    public Animator animator;

    //Immunity
    protected float immuneTime = 1f;
    protected float lasImmune;

    //Push
    protected Vector3 pushDirection;

    public float HitPoint { get => hitPoint; set => hitPoint = value; }
    public float MaxHitPoint { get => maxHitPoint; set => maxHitPoint = value; }

    //All fighters RecieveDamage / Die
    public virtual void RecieveDamage(Damage dmg)
    {
        if (Time.time - lasImmune > immuneTime)
        {
            lasImmune = Time.time;
            HitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            animator.SetTrigger("Hit");
            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.up * 30, .5f); 

            if (HitPoint <= 0)
            {
                HitPoint = 0;
                Death();
                _particleSystem.Play();
            }
        }
    }
    public virtual void Death()
    {

    }
}
