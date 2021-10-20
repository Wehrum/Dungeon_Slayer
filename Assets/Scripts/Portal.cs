using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string[] sceneNames;   

    protected override void OnCollide(Collider2D coll)
    {       
        if (coll.tag == "Fighter")        
        {            
            string screneNames = sceneNames[Random.Range(0, sceneNames.Length)];
            GameManager.instance.SaveState();            
            SceneManager.LoadScene(screneNames);
            GameObject.Find("Player").transform.position = GameObject.Find("Spawn Point").transform.position;
        } 
    }    
}
