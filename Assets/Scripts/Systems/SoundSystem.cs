using UnityEngine;

public static class SoundSystem
{
    private static GameObject parent;
    private static AudioSource audioSources;

    public static void PlaySound(AudioClip audioClip)
    {
        if (audioSources == null)
        {
            if (parent == null)
                parent = new GameObject();

            audioSources = parent.AddComponent<AudioSource>();
        }
        
        audioSources.clip = audioClip;
        audioSources.Play();
    }
}
