  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float power = 0.2f;
    public float duration = 0.2f;
    public float slowDownAmount = 1f;
    public float initialDuration;
    public bool shouldShake;

    public bool ShouldShake
    {
        get
        {
            return shouldShake;
        }
        set
        {
            shouldShake = value;
        }
    }
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        Shake();
    }

    void Shake()
    {
        if (shouldShake)
        {
            if(duration > 0f)
            {
                transform.localPosition = startPos + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                transform.localPosition = startPos;
            }
        }

    }
}
