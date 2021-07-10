using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] Slider _healthBar;

    private float _damageAmount = 0.1f;
    private float _startHealthValue;
    private float _targetHealthValue;

    public void OnHealButtonClick()
    {
        StopCoroutine(Hit());

        _startHealthValue = _healthBar.value;
        _targetHealthValue = _startHealthValue + _damageAmount;
         var healJob = StartCoroutine(Heal());
    }

    public void OnHitButtonClick()
    {
        StopCoroutine(Heal());

        _startHealthValue = _healthBar.value;
        _targetHealthValue = _startHealthValue - _damageAmount;

        var hitJob = StartCoroutine(Hit());
    }

    private IEnumerator Heal()
    {
        while (_healthBar.value < _targetHealthValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _healthBar.value + _damageAmount * Time.deltaTime, 0.1f);

            yield return null;
        }
    }

    private IEnumerator Hit()
    {
        while (_healthBar.value > _targetHealthValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _healthBar.value - _damageAmount * Time.deltaTime, 0.1f);

            yield return null;
        }
    }

}
