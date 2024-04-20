using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArgumentTrigger : MonoBehaviour
{
    //REMINDER CONSIDER ON TRIGGER EXIT TO STOP RETRIGGERING AUDIO?
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    public static bool isPlaying = false; // Flag to track if an instance of the script is currently playing a sound
    private float lastTriggerTime = -Mathf.Infinity; // Initialize to a value representing "no cooldown"
    private float cooldownTime = 15f; // Cooldown time in seconds

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        // Check if collision involves player and if enough time has passed since the last trigger
        if (other.CompareTag("Player") && Time.time - lastTriggerTime >= cooldownTime && !isPlaying)
        {
            Debug.Log("Audio trigger detected.");

            // Play a random audio clip
            int randomIndex = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomIndex];
            audioSource.Play();

            // Set the flag to true to indicate that the sound is currently playing
            isPlaying = true;

            // Update the last trigger time
            lastTriggerTime = Time.time;
        }
    }

    // Callback method called when the audio source finishes playing
    public void Update()
    {
        // If audio has finished playing, reset the flag and start the cooldown
        if (!audioSource.isPlaying && isPlaying)
        {
            isPlaying = false;
            lastTriggerTime = Time.time; // Start cooldown after audio finishes playing
        }
    }
}