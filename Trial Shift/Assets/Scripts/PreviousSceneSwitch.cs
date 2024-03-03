using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousSceneSwitch : MonoBehaviour
{

    public int SceneToEnter;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneToEnter);
    }
}
