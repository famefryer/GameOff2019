using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    public float speed;
    private OutlierController outlierController;

    // Start is called before the first frame update
    void Start()
    {
        outlierController = new OutlierController();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * GameManager.Instance.multiplySpeed);

        if (outlierController.IsObjectOutOfOutlier(transform))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LeftOutlier"))
        {
            Destroy(gameObject);
        }
    }
}
