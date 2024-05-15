using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    private Collider[] colliders;

    void Start()
    {
        // Get all colliders of child objects
        colliders = GetComponentsInChildren<Collider>();

        // Disable all colliders except for the first weapon
        SetCollidersActive(currentWeapon);
    }

    void Update()
    {
        SetWeaponActive();
        ProcessScrollWheelInput();
    }

    private void ProcessScrollWheelInput()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            // Disable current weapon collider
            //SetColliderActive(currentWeapon, false);

            // Update current weapon index
            currentWeapon += (int)Mathf.Sign(scroll);
            if (currentWeapon < 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else if (currentWeapon >= transform.childCount)
            {
                currentWeapon = 0;
            }

            // Enable new current weapon collider
            SetColliderActive(currentWeapon, true);
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    private void SetCollidersActive(int index)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = (i == index);
        }
    }

    private void SetColliderActive(int index, bool isActive)
    {
        if (index >= 0 && index < colliders.Length)
        {
            colliders[index].enabled = isActive;
        }
    }
}