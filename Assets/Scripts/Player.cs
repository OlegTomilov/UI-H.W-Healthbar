using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField] private ChangerHalthbar _changerHalthbar;

    public Slider Slider;

    private void Update()
    {
        ChangeHealth();
    }

    public void ChangeHealth()
    {
        Slider.value = Mathf.MoveTowards(Slider.value, _changerHalthbar.CurrentValue, _changerHalthbar.StepChange * Time.deltaTime);
    }
}
