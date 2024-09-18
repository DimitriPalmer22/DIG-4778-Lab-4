using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    // Reference to the AudioSource component
    private AudioSource audioSource;

    // Assign the audio clip in the Inspector or through script
    public AudioClip backgroundMusic;

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();

        // Set the clip to play (optional, if you want to assign it in script)
        audioSource.clip = backgroundMusic;

        // Enable looping
        audioSource.loop = true;

        // Play the background music
        PlayMusic();
    }

    void PlayMusic()
    {
        // Check if the audio source and clip are set
        if (audioSource != null && backgroundMusic != null)
        {
            audioSource.Play();  // Plays the audio clip in a loop
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is not set.");
        }
    }
}