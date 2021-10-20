using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : Mover
{
    public GameObject DeathScreen;
    //public GameObject UI;
    //public GameObject GameManager;
    //public GameObject Camera;
    private Weapon stamina;
    private Transform playerTransform;
    private void Awake()
    {
        //Finds variables from Weapon class
        GameObject go = GameObject.Find("Weapon1");
        stamina = go.GetComponent<Weapon>();
        //what is my max energy?
        stamina.maxenergy = 10;
        //what should my current energy be?
        stamina.currentenergy = 10;
        //how much energy should I use?
        stamina.useofenergy = 1;
        //how fast should stamina regenerate? Smaller numbers = faster
        stamina.regenTick = new WaitForSeconds(0.1f);
        
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));

        if (x == 0 && y == 0)
            animator.SetBool("SpeedB", true);
        else
            animator.SetBool("SpeedB", false);
    }

    private void Update()
    {
    }

    public override void Death()
    {
        DeathScript.instance.DeathScene();
    }
    //IEnumerator Pause()
    //{
    //    yield return new WaitForSeconds(wait_time);

    //    SceneManager.LoadScene(2);
    //    Destroy(UI);
    //    Destroy(GameManager);
    //    Destroy(gameObject);
    //    Destroy(Camera);
    //}
}

