using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {

        if (GameManager.instance != null)
        {    
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
        SoundManager.Initialize();
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(GameObject.Find("UI"));
        DontDestroyOnLoad(GameObject.Find("Main Camera"));
    }
    //resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponsSprites;
    public List<int> weaponPrice;
    public List<int> xpTable;

    // Refrences
    public Player player;

    //public weapon weapon...

    //SoundClips
    public SoundAudioClip[] soundAudioClipArray;

    //FloatingTextManager
    public FloatingTextManager floatingTextManager;

    // Logic
    public int gold;
    public int experience;
    public float hitPoint = 10f;
    public float energy = 10f;

    //Floating Text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    /*
     * int perfered skin
     * int gold
     * int exp
     * int weaponLevel
     */
    //Loading and Saving your game
    public void SaveState()
    {
        string s = "";
        s += "0"  + "|";
        s += energy.ToString()  + "|";
        s += hitPoint.ToString()  + "|";
        s += gold.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0" + "|";       

        PlayerPrefs.SetString("SaveState", s);

        Debug.Log("Save State");
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {         
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        
        //change player skin
        //Amount of Gold
        energy = int.Parse(data[1]);
        hitPoint = int.Parse(data[2]);
        gold = int.Parse(data[3]);
        //experience = int.Parse(data[4]);        

        //
        //

        Debug.Log("LoadState");
        if(player != null)
        {
            player.transform.position = GameObject.Find("Spawn Point").transform.position;
        }
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

}
