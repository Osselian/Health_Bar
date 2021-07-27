using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private HealthBar _healthBar;

    private void Start()
    {
        _health = 80;
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
        if (_health <0)
            _health = 0;
        _healthBar.ShowValue();
    }

    public void Heal (int healPoints)
    {
        _health += healPoints;
        if (_health > 100)
            _health = 100;
        _healthBar.ShowValue();
    }
    
    public int GetHealth()
    {
        return _health;
    }


}