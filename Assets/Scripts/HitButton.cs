using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitButton : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private int _damageAmount = -10;


    public void OnHitButtonClick()
    {
        _healthBar.ChangeValue(_damageAmount);
    }
}
