using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    // Audio Sorce that loops the music
    [SerializeField] AudioSource musicPlayer = null;

    //The Vector of sounds to be played
    [SerializeField] Sound levelMusic = null;
    
    // Index for the music sounds vector
    int currentMusicIndex = 0;

    public bool musisIsFading = false;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer.clip = levelMusic.audio;
        musicPlayer.volume = levelMusic.volume;
        musicPlayer.Play();
    }

    IEnumerator FadeOutMusic(float duration)
    {
        float initialVolume = musicPlayer.volume;
        float timeLeft = duration;
        while (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
            musicPlayer.volume = initialVolume * (timeLeft/duration);
            yield return null;
        }
        musicPlayer.volume = 0f;
        musicPlayer.Stop();
    }

    IEnumerator FadeInMusic(Sound sound, float duration)
    {
        musicPlayer.clip = levelMusic.audio;
        musicPlayer.Play();
        float timeLeft = duration;
        float timeToComplete = 0f;
        while (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
            timeToComplete += Time.deltaTime;
            musicPlayer.volume = sound.volume * (timeToComplete/duration);
            yield return null;
        }
        musicPlayer.volume = sound.volume;
    }

    IEnumerator FadeOutFadeInMusic(Sound sound)
    {
        yield return StartCoroutine(FadeOutMusic(2f));
        yield return StartCoroutine(FadeInMusic(sound, 2f));
    }
}
