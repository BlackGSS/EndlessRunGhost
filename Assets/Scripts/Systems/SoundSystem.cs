using UnityEngine;
using System.Collections.Generic;

public class SoundSystem
{
    private static GameObject parent;

    private static Dictionary<string, List<AudioSource>> audioSources = new Dictionary<string, List<AudioSource>>();

    public static AudioSource PlaySound(AudioClip audioClip, float volume = 1)
    {
        if (audioSources.TryGetValue(audioClip.name, out List<AudioSource> audioSourcesList))
        {
            for (int i = 0; i < audioSourcesList.Count; i++)
            {
                if (audioSourcesList[i] == null)
                {
                    Clear();
                    break;
                }

                if (!audioSourcesList[i].isPlaying)
                {
                    audioSourcesList[i].volume = volume;
                    audioSourcesList[i].Play();
                    return audioSourcesList[i];
                }
            }
            return SpawnSoundSystem(audioClip, volume);
        }
        return SpawnSoundSystem(audioClip, volume);
    }

    private static AudioSource SpawnSoundSystem(AudioClip audioClip, float volume = 1)
    {
        if (parent == null)
            parent = new GameObject() { name = "Audio Sources" };
        AudioSource audioSource = parent.AddComponent<AudioSource>();
        if (audioSources.ContainsKey(audioClip.name))
            audioSources[audioClip.name].Add(audioSource);
        else
            audioSources.Add(audioClip.name, new List<AudioSource>() { audioSource });

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        return audioSource;
    }

    public static void Clear()
    {
        audioSources.Clear();
    }

    // public static void Mute(bool mute)
    // {
    //     foreach (List<AudioSource> audioSource in audioSources.Values)
    //     {
    //         for (int i = 0; i < audioSource.Count; i++)
    //         {
    //             audioSource[i].mute = mute;
    //         }
    //     }
    // }
}
