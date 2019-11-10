using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlierController
{

    private float xOutlier = -48;
    public bool IsObjectOutOfOutlier(Transform transform)
    {
        if (transform.position.x <= xOutlier)
        {
            return true;
        }
        return false;
    }
}
