using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(platform, generationPoint.position, generationPoint.rotation);
    }
}
