using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _healthChanged;

    private int _maxHealth = 100;
    private int _minHealth = 0;

    public event UnityAction HealthChanged
    {
        add => _healthChanged.AddListener(value);
        remove => _healthChanged.RemoveListener(value);
    }

    private void OnEnable()
    {
        _health = 80;
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
        if (_health < _minHealth)
            _health = _minHealth;
        _healthChanged?.Invoke();
    }

    public void Heal (int healPoints)
    {
        _health += healPoints;
        if (_health > _maxHealth)
            _health = _maxHealth;
        _healthChanged?.Invoke();
    }
    
    public int GetHealth()
    {
        return _health;
    }


}