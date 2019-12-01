using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BAR_TYPE
{
    HEALTH,
    MANA
}

public class BarController : MonoBehaviour
{

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private BAR_TYPE barType;

    [SerializeField]
    private Image consent;

    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private float MapValue(float value, float inMin,float inMax,float outMin,float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;  
    }

    public void updateValue(float value, float inMin, float inMax)
    {
        if (barType == BAR_TYPE.MANA && animator)
        {
            if(value >= 5)
            {
                animator.SetBool("IsManaReady", true);
            }
            else
            {
                animator.SetBool("IsManaReady", false);
            }
        }
        consent.fillAmount = MapValue(value,inMin,inMax,0,1);
    }
}
