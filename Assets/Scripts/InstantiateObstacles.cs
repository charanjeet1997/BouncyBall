using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObstacles : MonoBehaviour
{
    public CircleEdgeCollider edgeCollider;

    public GameObject obstaclePrefab;
    public int numberOfObstacles;
    public GameObject obstacleParent;
    public List<Vector2> instantiatePoints;
    float angle = 0;
    public int minObstacles;
    public int maxObstacles;
    private void Start()
    {
        numberOfObstacles = Random.Range(minObstacles, maxObstacles);
        for (int instantateObjectIndex = 0; instantateObjectIndex < numberOfObstacles;)
        {
            Vector2 point = edgeCollider.points[Random.Range(0, edgeCollider.points.Count - 1)];
            if(!CheckIsInstantiatePointInList(instantiatePoints,point))
            {
                instantiatePoints.Add(point);
                GameObject obstacle = Instantiate(obstaclePrefab,obstacleParent.transform);
                obstacle.transform.position = new Vector3(point.x, point.y, 0);
                Vector2 differenceVector = transform.position - obstacle.transform.position;
                obstacle.transform.rotation = Quaternion.FromToRotation(Vector2.up, obstacle.transform.position - transform.position);
                
                instantateObjectIndex++;
            }
        }
    }


    public float CalculateAngle(Vector2 firstPoint,Vector2 secondPoint)
    {
        angle = Vector2.SignedAngle(firstPoint, secondPoint);
        return angle;
    }

    public bool CheckIsInstantiatePointInList(List<Vector2> points,Vector2 point)
    {
        if(points!=null)
        {
            if (point == points.Find(x => x.x == point.x && x.y == point.y))
                return true;
            return false;
        }
        return false;
    }
}
