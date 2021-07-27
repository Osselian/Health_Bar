using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitButton : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _damageAmount = 10;

    public void OnHitButtonClick()
    {
        _player.GetDamage(_damageAmount);
    }
}
