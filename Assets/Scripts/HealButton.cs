using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealButton : MonoBehaviour
{
    [SerializeField] Slider _healthBar;

    private float _damageAmount = 0.1f;
    private float _startHealthValue;
    private float _targetHealthValue;

    private HitButton _hitButton;

    private void Start()
    {
        _hitButton = GetComponent<HitButton>();
    }
    public void OnHealButtonClick()
    {
        _hitButton.StopWork();

        _startHealthValue = _healthBar.value;
        _targetHealthValue = _startHealthValue + _damageAmount;
         var healJob = StartCoroutine(Heal());
    }

    private IEnumerator Heal()
    {
        while (_healthBar.value < _targetHealthValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _healthBar.value + _damageAmount * Time.deltaTime, 0.1f);

            yield return null;
        }
    }

    public void StopWork()
    {
        StopCoroutine(Heal());
    }

}
