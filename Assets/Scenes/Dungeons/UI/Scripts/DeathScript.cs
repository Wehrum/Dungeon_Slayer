using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScript : MonoBehaviour
{
    public GameObject DeathScreen;
    public GameObject Player;
    public GameObject UI;
    public GameObject GameManager;
    public GameObject Camera;
    public static DeathScript instance;
    private float wait_time = 8f;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of found!");
            return;
        }
        instance = this;
    }

    public void DeathScene()
    {
        DeathScreen.SetActive(true);
        Destroy(Player);
        Destroy(UI);
        Debug.Log("You dead");
        StartCoroutine(Pause());
    }
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene(2);
        Destroy(GameManager);
        Destroy(Camera);
    }
}

