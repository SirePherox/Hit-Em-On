using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    private float timer = 2.0f;

    // call func after 2secs to deactivate game object
    void Start()
    {
        Invoke("Deactivate", timer);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
