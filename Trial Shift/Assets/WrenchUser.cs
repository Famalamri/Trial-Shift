using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchUser : MonoBehaviour
{
    bool canTrigger;


    // Start is called before the first frame update
    void Start()
    {
        canTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canTrigger)
        {
            GetComponent<Animator>().SetTrigger("Wrenching");
            canTrigger = false;
            Invoke("Trigger", 0.5f);

        }    
    }

    void Trigger()
    {
        canTrigger = true;
    }


}
