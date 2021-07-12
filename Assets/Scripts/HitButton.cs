using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitButton : MonoBehaviour
{
    [SerializeField] Slider _healthBar;

    private float _damageAmount = 0.1f;
    private float _startHealthValue;
    private float _targetHealthValue;

    private HealButton _healButton;

    private void Start()
    {
        _healButton = GetComponent<HealButton>();
    }

    public void OnHitButtonClick()
    {
        _healButton.StopWork();
        _startHealthValue = _healthBar.value;
        _targetHealthValue = _startHealthValue - _damageAmount;

        var hitJob = StartCoroutine(Hit());
    }

    private IEnumerator Hit()
    {
        while (_healthBar.value > _targetHealthValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _healthBar.value - _damageAmount * Time.deltaTime, 0.1f);

            yield return null;
        }
    }

    public void StopWork()
    {
        StopCoroutine(Hit());
    }
}
