using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangerHalthbar : MonoBehaviour
{
    public float StepChange = 10f;
    public float CurrentValue = 50f;


    public void DecreaseHealth()
    {
        CurrentValue -= StepChange;
    }

    public void IncreaseHealth()
    {
        CurrentValue += StepChange;
    }
}
