using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private bool isPlaceable;

    private void OnMouseOver()
    {
        if(isPlaceable)
            print(transform.name);
    }

}
