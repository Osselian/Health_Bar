using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _healthBar;
    private float _newValue;
    private float _maxDelta = 0.1f;
    private Coroutine _changeValueJob;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.value = _player.GetHealth();
    }

    public void ShowValue()
    {
        if (_changeValueJob != null)
            StopCoroutine(_changeValueJob);

        _newValue = _player.GetHealth();
        _changeValueJob = StartCoroutine(ChangeValueJob());
    }

    private IEnumerator ChangeValueJob()
    {
        while (_healthBar.value != _newValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _newValue, _maxDelta);
            yield return null;
        }
    }
}
