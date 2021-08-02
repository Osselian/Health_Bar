using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    
    private int _maxHealth = 100;
    private int _minHealth = 0;

    public event UnityAction<int> HealthChanged;

    private void OnEnable()
    {
        _health = 80;
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
        if (_health < _minHealth)
            _health = _minHealth;
        HealthChanged?.Invoke(_health);
    }

    public void Heal (int healPoints)
    {
        _health += healPoints;
        if (_health > _maxHealth)
            _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }
    
    public int GetHealth()
    {
        return _health;
    }


}