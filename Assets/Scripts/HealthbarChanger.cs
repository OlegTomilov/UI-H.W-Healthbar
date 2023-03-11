using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]

public class HealthbarChanger : MonoBehaviour
{
    public Slider Slider;

    private Coroutine _changeValue;

    [SerializeField] private Player _player;


    private void Start()
    {
        _player = GetComponent<Player>();
    }

    public void ChangeHealth()
    {
        if (_changeValue != null)
        {
            StopCoroutine(_changeValue);
        }

        _changeValue = StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        while (Slider.value != _player.CurrentValue)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, _player.CurrentValue, _player.StepChange * Time.deltaTime);
            yield return null;
        }
    }
}
