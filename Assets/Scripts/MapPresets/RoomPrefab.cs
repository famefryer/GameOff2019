using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPrefab : MonoBehaviour
{

    private bool isNextMapGenerated = false;
    private OutlierController outlierController;

    private void Start()
    {
        outlierController = new OutlierController();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Tiggered");
        GenerateNextMap();
    }

    public void GenerateNextMap()
    {
        //Debug.Log("Should be generated");
        if (!isNextMapGenerated)
        {
            //TODO: Generate next map here. Get next map from GameManager by calling GameManager.nextMap().
            SpawnMap(GameManager.Instance.nextRoom());
            isNextMapGenerated = true;
        }
    }

    private void Update()
    {
        //Debug.Log(GameManager.Instance.currentSpeed);
        //Debug.Log(Vector2.left * GameManager.Instance.currentSpeed * Time.deltaTime);
        transform.Translate(Vector2.left * GameManager.Instance.currentSpeed * Time.deltaTime);
        if (outlierController.IsObjectOutOfOutlier(transform))
        {
            Destroy(gameObject);
        }
    }

    public void SpawnMap(RoomPrefab nextRoomPrefab)
    {
        var lastTileBounds = GetComponent<SpriteRenderer>().sprite.bounds;
        Instantiate(nextRoomPrefab,
            new Vector2(transform.position.x + lastTileBounds.size.x * transform.localScale.x,
            0),
            transform.rotation
            );
    }

}
