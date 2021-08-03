using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{    
    private int _maxHealth = 100;
    private int _minHealth = 0;

    public int Health { get; private set; }

    public event UnityAction<int> HealthChanged;

    private void OnEnable()
    {
        Health = 80;
    }

    public void GetDamage(int damage)
    {
        Health -= damage;
        if (Health < _minHealth)
            Health = _minHealth;
        HealthChanged?.Invoke(Health);
    }

    public void Heal (int healPoints)
    {
        Health += healPoints;
        if (Health > _maxHealth)
            Health = _maxHealth;
        HealthChanged?.Invoke(Health);
    }
}