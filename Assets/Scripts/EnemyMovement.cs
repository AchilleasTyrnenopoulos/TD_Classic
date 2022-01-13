using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private List<Waypoint> path = new List<Waypoint>();
    [SerializeField]
    private float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = new Vector3(waypoint.transform.position.x, this.transform.position.y, waypoint.transform.position.z);

            yield return new WaitForSeconds(waitTime);
        }
    }
}
