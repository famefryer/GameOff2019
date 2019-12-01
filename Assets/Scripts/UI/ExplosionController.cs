using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public Animator animator;
    private MonsterController monster;

    private void Start()
    {
        monster = transform.parent.Find("Monster").gameObject.GetComponent<MonsterController>();
    }
    private void HideMonster()
    {
        if (monster)
        {
            monster.gameObject.SetActive(false);
        }
    }

    private void ExplosiveAnimationComplete()
    {
        Debug.Log(555);
        Destroy(transform.parent.gameObject);
    }

}
