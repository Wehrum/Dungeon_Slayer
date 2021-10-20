using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        PlayerMove,
        PlayerAttack,
        EnemyHit,
        EnemyDie,
        Chest,
    }
    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.EnemyHit] = .5f;
    }
    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(GetAudioClip(sound));
        }
    }
    public static void PlaySound(Sound sound, Vector3 position)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();
        }
    }

    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;
            case Sound.EnemyHit:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float enemyHitTimerMax = 1.5f;
                    if (lastTimePlayed + enemyHitTimerMax < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else return false;
                }
                else return true;
        }
    }
    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameManager.SoundAudioClip soundAudioClip in GameManager.instance.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }

        }
        Debug.Log("Sound" + sound + " was not found!");
        return null;
    }
    private static Dictionary<Sound, float> soundTimerDictionary;
}
