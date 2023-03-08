using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public Slider Slider;

    [SerializeField] private ChangerHalthbar _changerHalthbar;

    public void ChangeHealth()
    {
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (Slider.value != _changerHalthbar.CurrentValue)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, _changerHalthbar.CurrentValue, _changerHalthbar.StepChange * Time.deltaTime);
            yield return null;
        }
    }
}
