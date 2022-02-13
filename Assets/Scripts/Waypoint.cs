using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private bool isPlaceable;

    [SerializeField]
    private GameObject buildingPrefab;

    private void OnMouseOver()
    {
        if (isPlaceable)
        {
            print(transform.name);

            //check if player clicked
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(buildingPrefab, transform);
                isPlaceable = false;
            }
        }
    }

}
