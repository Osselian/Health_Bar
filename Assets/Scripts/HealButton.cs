using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private int _healAmount = 10;

    public void OnHealButtonClick()
    {
        _healthBar.ChangeValue(_healAmount);
    }
}
