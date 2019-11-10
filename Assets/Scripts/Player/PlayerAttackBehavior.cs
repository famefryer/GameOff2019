using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehavior
{
    private Transform attackRangeCenter;
    private Vector2 colliderSize;

    private LayerMask obstacleLayer;
    private int manaGained;
    
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
            Debug.Log(hittedCollider.gameObject);
            monster.DestroyItself();
            manaGained += 1;
        }
        return null;
    }

    public int getMana()
    {
        int currentManaGained = manaGained;
        manaGained = 0;
        return currentManaGained;
    }

}
