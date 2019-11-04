using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject platform;
    public Transform generationPoint;
    public float minDistance;
    public float maxDistance;

    private float platformWidth;
    private float currentDistance;
    private bool isFirstTime;
    private GameObject previousPlatform;

    // Start is called before the first frame update
    void Start()
    {
        isFirstTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstTime)
        {
            isFirstTime = false;
            previousPlatform = Instantiate(platform, generationPoint.position, generationPoint.rotation);
            currentDistance = Random.Range(minDistance, maxDistance);
        }

        if (Mathf.Abs(previousPlatform.transform.position.x - transform.position.x) > currentDistance)
        {
            previousPlatform = Instantiate(platform, generationPoint.position, generationPoint.rotation);
            currentDistance = Random.Range(minDistance, maxDistance);
        }
    }
}
