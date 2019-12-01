using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image consent;

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
        consent.fillAmount = MapValue(value,inMin,inMax,0,1);
    }
}
