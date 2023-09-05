using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public enum Sound
    {
        EnemyHurt,
        FailLevel,
        FinishLevel,
        PlayerJump,
        PlayerHurt,
        PlayerWalk,
        PickUpWater,
    }
    
    [System.Serializable]
    private class SoundAudioClip
    {
        public Sound sound;
        public AudioClip audioClip;
    }
    [SerializeField] private List<SoundAudioClip> audioClips;
    [SerializeField] private List<AudioSource> audioPool;

    private Queue<AudioSource> audioSources;

    private Dictionary<Sound, float> soundTimer;
    private void Start()
    {
        audioSources = new Queue<AudioSource>();
        soundTimer = new Dictionary<Sound, float>();
        foreach (AudioSource source in audioPool)
            audioSources.Enqueue(source);
    }
    public void PlaySound(Sound sound, Vector2 position, float timer = 0f)
    {
        if (CanPlaySound(sound,timer))
        {
            if (audioSources.Count == 0)
            {
                Debug.LogWarning("No available audio sources in the pool.");
                return;
            }

            AudioSource audioSource = audioSources.Dequeue();

            audioSource.transform.position = position;
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();

            StartCoroutine(RequeueAudioSource(audioSource));
        }
    }

    private bool CanPlaySound(Sound sound, float timeBetween)
    {
        switch (sound)
        {
            default: return true;
            case Sound.PlayerWalk:
                if (!soundTimer.ContainsKey(sound))
                {
                    soundTimer[Sound.PlayerWalk] = 0f;
                }
                float lastTimePlayed = soundTimer[sound];
                if (lastTimePlayed + timeBetween < Time.time)
                {
                    soundTimer[Sound.PlayerWalk] = Time.time;
                    return true;
                }
                else
                    return false;
        }
    }

    private AudioClip GetAudioClip(Sound sound)
    {
        foreach(SoundAudioClip clip in audioClips)
        {
            if (clip.sound == sound)
                return clip.audioClip;
        }
        return null;
    }

    private IEnumerator RequeueAudioSource(AudioSource audioSource)
    {
        yield return new WaitForSeconds(audioSource.clip.length);

        audioSources.Enqueue(audioSource);
    }
}
