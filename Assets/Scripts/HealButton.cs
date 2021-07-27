using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _healAmount = 10;

    public void OnHealButtonClick()
    {
        _player.Heal(_healAmount);
    }
}
