using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float _stepChange = 10f;
    private float _currentValue = 50f;
    private int _maxHealth = 100;
    private int _minHealth = 0;

    [SerializeField] private HealthbarChanger _changerHalthbar;

    public static event UnityAction ChangedHealth;

    public float StepChange => _stepChange;
    public float CurrentValue => _currentValue;

    private void Start()
    {
        ChangedHealth += _changerHalthbar.ChangeHealth;
    }

    private void Update()
    {
        _currentValue = Mathf.Clamp(_currentValue, _minHealth, _maxHealth);
    }

    public void OnDisable()
    {
        ChangedHealth -= _changerHalthbar.ChangeHealth;
    }

    public void Damage()
    {
        _currentValue -= StepChange;
        ChangedHealth.Invoke();
    }

    public void Heal()
    {
        _currentValue += StepChange;
        ChangedHealth.Invoke();
    }
}
