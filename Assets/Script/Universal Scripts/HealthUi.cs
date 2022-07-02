using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    [SerializeField]
    private Image healthUi;

    private void Awake()
    {
        healthUi = GameObject.FindGameObjectWithTag(Tags.HEALTH_UI).GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisplayHealth(float value)
    {
        value /= 100;

        if (value < 0)
            value = 0f;

        healthUi.fillAmount = value;
    }
}
