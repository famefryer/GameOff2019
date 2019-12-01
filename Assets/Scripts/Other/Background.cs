using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    public float startX;
    public float endX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * GameManager.Instance.multiplySpeed);

        if(transform.position.x <= endX)
        {
            Vector2 newPosition = new Vector2(startX, transform.position.y);
            transform.position = newPosition;
        }
    }
}
