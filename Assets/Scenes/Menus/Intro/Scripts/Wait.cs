using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{
    public float wait_time = 12f;
    void Start()
    {
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
