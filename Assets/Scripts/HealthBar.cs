using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    private Slider _healthBar;
    private float _valueChangeDelta;
    private float _targetValue;
    private float _maxDelta = 0.05f;
    private Coroutine _changeValueJob;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _targetValue = _healthBar.value;
    }

    public void ChangeValue(int valueChangeDelta)
    {
        if (_changeValueJob != null)
            StopCoroutine(_changeValueJob);
        
        _valueChangeDelta = valueChangeDelta;
        _targetValue = _targetValue + _valueChangeDelta;
        _changeValueJob = StartCoroutine(ChangeValueJob());
    }

    private IEnumerator ChangeValueJob()
    {
        while (_healthBar.value != _targetValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _targetValue, _maxDelta);
            yield return null;
        }
    }
}
