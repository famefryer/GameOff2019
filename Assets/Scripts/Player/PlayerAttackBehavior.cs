using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehavior
{
    private Transform attackRangeCenter;
    private Vector2 colliderSize;

    private LayerMask obstacleLayer;

    public PlayerAttackBehavior(Transform attackRangeCenter, Vector2 colliderSize,LayerMask obstacleLayer)
    {
        this.attackRangeCenter = attackRangeCenter;
        this.colliderSize = colliderSize;
        this.obstacleLayer = obstacleLayer;
    }

    public Transform colliderChecked()
    {
        Collider2D hittedCollider = Physics2D.OverlapBox(attackRangeCenter.position, colliderSize,obstacleLayer);
        if (hittedCollider.CompareTag("Monster"))
        {
            MonsterController monster = hittedCollider.GetComponent<MonsterController>();
            monster.DestroyItself();
        }
        return null;
    }

}
