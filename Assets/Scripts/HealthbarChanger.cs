using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]

public class HealthbarChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;

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
        while (_slider.value != _player.CurrentValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.CurrentValue, _player.StepChange * Time.deltaTime);
            yield return null;
        }
    }
}
