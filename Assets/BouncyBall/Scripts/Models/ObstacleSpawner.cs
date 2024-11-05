using System.Collections;
using System.Collections.Generic;
using Games.GameStateFramework;
using UnityEngine;

namespace Games.BouncyBall
{
    public class ObstacleSpawner : MonoBehaviour, IGameStart, IGameOver
    {
        [SerializeField] private CircleEdgeCollider edgeCollider;
        [SerializeField] private List<GameObject> obstacles;
        [SerializeField] private GameObject obstaclePrefab;
        [SerializeField] private int numberOfObstacles;
        [SerializeField] private GameObject obstacleParent;
        [SerializeField] private List<Vector2> instantiatePoints;
        [SerializeField] private int minObstacles;
        [SerializeField] private int maxObstacles;

        private void OnEnable()
        {
            ServiceLocatorFramework.ServiceLocator.Current.Get<GameStateManager>().Register(this);
        }

        private void OnDisable()
        {
            ServiceLocatorFramework.ServiceLocator.Current.Get<GameStateManager>().Unregister(this);
        }

        private void InstantiateObstacles()
        {
            DestroyObstacles();
            numberOfObstacles = Random.Range(minObstacles, maxObstacles);
            for (int instantateObjectIndex = 0; instantateObjectIndex < numberOfObstacles;)
            {
                Vector2 point = edgeCollider.points[Random.Range(0, edgeCollider.points.Count - 1)];
                if (!CheckIsInstantiatePointInList(instantiatePoints, point))
                {
                    instantiatePoints.Add(point);
                    GameObject obstacle = Instantiate(obstaclePrefab, obstacleParent.transform);
                    obstacle.transform.position = new Vector3(point.x, point.y, 0);
                    Vector2 differenceVector = transform.position - obstacle.transform.position;
                    obstacle.transform.rotation = Quaternion.FromToRotation(Vector2.up, obstacle.transform.position - transform.position);
                    obstacles.Add(obstacle);
                    instantateObjectIndex++;
                }
            }
        }

        private void DestroyObstacles()
        {
            foreach (var obstacle in obstacles)
            {
                Destroy(obstacle);
            }
            obstacles.Clear();
            instantiatePoints.Clear();
        }

        public bool CheckIsInstantiatePointInList(List<Vector2> points, Vector2 point)
        {
            if (points != null)
            {
                if (point == points.Find(x => x.x == point.x && x.y == point.y))
                    return true;
                return false;
            }
            return false;
        }

        public void StartGame()
        {
            InstantiateObstacles();
        }

        public void GameOver()
        {
            DestroyObstacles();
        }
    }
}