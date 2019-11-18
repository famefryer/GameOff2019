using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPrefab : MonoBehaviour
{

    private bool isNextMapGenerated = false;

    private void OnTriggerEnter(Collider other)
    {
        GenerateNextMap();
    }

    public void GenerateNextMap()
    {
        if (!isNextMapGenerated)
        {
            //TODO: Generate next map here. Get next map from GameManager by calling GameManager.nextMap().

            isNextMapGenerated = true;
        }
    }

}
