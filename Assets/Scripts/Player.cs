using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float StepChange = 10f;
    public float CurrentValue = 50f;
    private int _maxHealth = 100;
    private int _minHealth = 0;

    [SerializeField] private ChangerHalthbar _changerHalthbar;

    public static event UnityAction ChangeHealthBar;

    private void Start()
    {
        ChangeHealthBar += _changerHalthbar.ChangeHealth;
    }

    public void DecreaseHealth()
    {
        if (CurrentValue > _minHealth)
        {
            CurrentValue -= StepChange;
            ChangeHealthBar.Invoke();
        }
    }

    public void IncreaseHealth()
    {
        if (CurrentValue < _maxHealth)
        {
            CurrentValue += StepChange;
            ChangeHealthBar.Invoke();
        }
    }
}
