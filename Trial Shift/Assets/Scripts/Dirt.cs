using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    // Variables to control opacity reduction
    public float opacityReductionAmount = 0.4f; // Amount of opacity reduced per collision
    public float minOpacity = 0f; // Minimum opacity before dirt is disabled

    private bool isDisabled = false; // Flag to track if dirt is disabled
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered!");

        // Check if the collider belongs to the mop and the dirt is not disabled
        if (other.CompareTag("Mop") && !isDisabled)
        {
            Debug.Log("Mop collided with dirt");

            // Reduce dirt opacity when colliding with the mop
            ReduceOpacity();
        }
    }

    // Reduces the opacity of the dirt and disables it if opacity falls below a threshold
    private void ReduceOpacity()
    {
        Debug.Log("Reducing dirt opacity...");

        // Get the Renderer component to modify the material color
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Renderer component not found on dirt object!");
            return;
        }

        // Get the current color of the material
        Color currentColor = renderer.material.color;

        // Calculate the new color with reduced opacity
        Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, currentColor.a - opacityReductionAmount);

        // Update the material color with the new opacity
        renderer.material.color = newColor;

        // If opacity falls below the minimum threshold, disable the dirt
        if (newColor.a <= minOpacity)
        {
            DisableDirt();
        }
    }

    // Disables the dirt GameObject
    private void DisableDirt()
    {
        // Play the audio clip
        if (audioClips.Length > 0)
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
        }

        // Start a coroutine to wait for the audio clip to finish before disabling the dirt
        StartCoroutine(DisableAfterAudioFinished());
    }

    // Coroutine to disable the dirt after the audio clip finishes playing
    private IEnumerator DisableAfterAudioFinished()
    {
        // Wait until the audio clip finishes playing
        yield return new WaitForSeconds(audioSource.clip.length);

        // Disable the dirt GameObject
        isDisabled = true;
        gameObject.SetActive(false);
    }
}