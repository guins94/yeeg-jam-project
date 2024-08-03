using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource = null;
    [SerializeField] List<AudioSource> audioSourceList = new List<AudioSource>();

    // Timers For The Sounds
    readonly Dictionary<Sound, float> soundDurationDictionary = new Dictionary<Sound, float>();

    // Keeps the audio sorce that played the sound
    readonly Dictionary<Sound, int> soundAudioSourceDictionary = new Dictionary<Sound, int>();

    /// <summary>
    /// References the music player for the game
    /// </summary>
    public static MusicPlayer player { get; private set; } = null;

    // Stores the index of the next audio music to be played
    private int nextAudioSorceID = 0;

    // A vector to store the coroutines of sounds still playing
    List<Coroutine> soundCoroutines = new List<Coroutine>();
    Coroutine newSoundCoroutine = null;

    void Awake()
    {
        if (player == null) player = GetComponentInChildren<MusicPlayer>();
    }

    /// <summary>
    /// Generic Function that plays a sound if it's not playing already.
    /// </summary>
    public void PlaySound(Sound sound)
    {
        if (audioSourceList[nextAudioSorceID] == null) return; 
        if (CanPlaySound(sound))
        {
            newSoundCoroutine = StartCoroutine(PlaySoundCoroutine(sound));
        } 
    }

    /// <summary>
    /// Swap the current sound being played until it reaches the end, giving room on the dictionary
    /// </summary>
    IEnumerator PlaySoundCoroutine(Sound sound)
    {
        Coroutine coroutine = newSoundCoroutine;
        audioSourceList[nextAudioSorceID].loop = sound.loop;
        audioSourceList[nextAudioSorceID].PlayOneShot(sound.audio, sound.volume);
        soundCoroutines.Add(soundPlayCoroutine);
        ManageAudioSource(sound);
        yield return new WaitForSeconds(sound.audio.length);
        RemoveSoundCoroutine(soundPlayCoroutine);
        soundAudioSourceDictionary.Remove(sound);
    }

    /// <summary>
    /// Removes a sound coroutine from the list.
    /// </summary>
    void RemoveSoundCoroutine(Coroutine coroutine)
    {
        for (int i = 0; i < soundCoroutines.Count ; i++)
        {
            if (soundCoroutines[i] == coroutine)
            {
                soundCoroutines[i] = null;
                soundCoroutines.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Stops a spcecified sound.
    /// </summary>
    public void StopSound(Sound sound)
    {
        if (soundAudioSourceDictionary.ContainsKey(sound)) audioSourceList[soundAudioSourceDictionary[sound]].Stop();
        // TODO: Stop the specific sound from the coroutine.
    }

    /// <summary>
    /// Plays a random sound from a list of sounds.
    /// </summary>
    public void PlayRandomSound(Sound[] sounds)
    {
        if (sounds == null) return;
        Sound s = null;
        int index = UnityEngine.Random.Range(0, sounds.Length - 1);
        s = sounds[index];
        if (s == null)
        {
            Debug.LogWarning("Sound: not found!");
            return;
        }
        PlaySound(s);
    }

    /// <summary>
    /// Checks in the dictionary if the sound is already playing.
    /// </summary>
    public bool CanPlaySound(Sound sound)
    {
        // If the sound delay is 0, it can be played
        if (!soundDurationDictionary.ContainsKey(sound)) 
        {
            if (sound.delay <= 0f) return true;
            else soundDurationDictionary.Add(sound, 0f);
        }
        float lastTimePlayed = soundDurationDictionary[sound];

        if (lastTimePlayed + sound.delay < Time.time)
        {
            soundDurationDictionary[sound] = Time.time;
            return true;
        }
        else return false;
    }

    private void ManageAudioSource(Sound sound)
    {
        soundAudioSourceDictionary.TryAdd(sound, nextAudioSorceID);
        nextAudioSorceID++;
        if (nextAudioSorceID >= audioSourceList.Count) nextAudioSorceID = 0;
    }
}
