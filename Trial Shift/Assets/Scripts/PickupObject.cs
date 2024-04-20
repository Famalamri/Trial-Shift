using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject PickupText;
    public GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
        Object.SetActive(false);
        PickupText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PickupText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);

                Object.SetActive(true);

                PickupText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickupText.SetActive(false);
    }
}
