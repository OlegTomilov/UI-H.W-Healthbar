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

    [SerializeField] private HealthbarChanger _changerHalthbar;

    public static event UnityAction ChangedHealth;

    private void Start()
    {
        ChangedHealth += _changerHalthbar.ChangeHealth;
    }

    private void Update()
    {
        CurrentValue = Mathf.Clamp(CurrentValue, _minHealth, _maxHealth);
    }

    public void OnDisable()
    {
        ChangedHealth -= _changerHalthbar.ChangeHealth;
    }

    public void Damage()
    {
        CurrentValue -= StepChange;
        ChangedHealth.Invoke();
    }

    public void Heal()
    {
        CurrentValue += StepChange;
        ChangedHealth.Invoke();
    }
}
