using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ATTACK_TYPE
{
    NORMAL,
    SPECIAL
}

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

    public Transform colliderChecked(ATTACK_TYPE attackType)
    {
        Collider2D hittedCollider = Physics2D.OverlapBox(attackRangeCenter.position, colliderSize,obstacleLayer);

        if (hittedCollider.CompareTag("Monster"))
        {
            MonsterController monster = hittedCollider.GetComponent<MonsterController>();
            GameManager.Instance.currentScore += monster.score;
            Debug.Log(GameManager.Instance.currentScore);
            monster.DestroyItself();
            if(attackType  == ATTACK_TYPE.NORMAL)
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
