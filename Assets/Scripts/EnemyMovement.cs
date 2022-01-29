using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private List<Waypoint> path = new List<Waypoint>();
    [SerializeField]
    [Range(0f, 10)]
    private float speed = 1f;

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
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;

            float rotationDegrees = DegreesToRotate(this.transform.forward, startPos, endPos);

            while(travelPercent < 1)
            {
                //rotate enemy
                if(travelPercent < 0.25f)
                {
                    float rotationAngle = 4 * rotationDegrees * Time.deltaTime * speed;
                    this.transform.Rotate(new Vector3(0, rotationAngle, 0));
                }

                //move enemy
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);                

                yield return new WaitForEndOfFrame();
            }
            //transform.position = new Vector3(waypoint.transform.position.x, this.transform.position.y, waypoint.transform.position.z);            
        }
    }

    private float DegreesToRotate(Vector3 currentDir, Vector3 currentPosition, Vector3 endPosition)
    {
        Vector3 targetDir = endPosition - currentPosition;
        return Vector3.SignedAngle(currentDir, targetDir, Vector3.up);
    }
}
