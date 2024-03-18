using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    // Variables to control opacity reduction
    public float opacityReductionAmount = 0.5f; // Amount of opacity reduced per collision
    public float minOpacity = 0f; // Minimum opacity before dirt is disabled

    private bool isDisabled = false; // Flag to track if dirt is disabled

    // Called when a trigger collider enters the GameObject's trigger collider
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Mop collided with dirt");

        // Check if the collider belongs to the mop and the dirt is not disabled
        if (other.CompareTag("Mop") && !isDisabled)
        {
            // Reduce dirt opacity when colliding with the mop
            ReduceOpacity();
        }
    }

    // Reduces the opacity of the dirt and disables it if opacity falls below a threshold
    private void ReduceOpacity()
    {
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
        // Set the flag to indicate that the dirt is disabled
        isDisabled = true;

        // Disable the GameObject
        gameObject.SetActive(false);
    }
}