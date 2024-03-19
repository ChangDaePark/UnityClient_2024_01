using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExEnemy : MonoBehaviour
{
    private int damage = 20;
    public ExPlayer targetPlayer;

    public void AttackPlayer(ExPlayer player)
    {
        player.TakeDamage(damage);
        Debug.Log("플레이어 공격.");

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackPlayer(targetPlayer);

        }
    }
}
