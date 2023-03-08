using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]

public class ChangerHalthbar : MonoBehaviour
{
    public float StepChange = 10f;
    public float CurrentValue = 50f;

    public static event UnityAction ChangeHealthBar;

    [SerializeField] private Player _player;


    private void Start()
    {
        _player = GetComponent<Player>();
        ChangeHealthBar += _player.ChangeHealth;
    }

    public void DecreaseHealth()
    {
        CurrentValue -= StepChange;
        ChangeHealthBar.Invoke();
    }

    public void IncreaseHealth()
    {
        CurrentValue += StepChange;
        ChangeHealthBar.Invoke();
    }
}
