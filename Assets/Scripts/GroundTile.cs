using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnCans();
    }

    private void OnTriggerExit(Collider other) {

        groundSpawner.SpawnTile();
        Destroy(gameObject, 1.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle() {

        //
        int obstacleSpawnIndex = Random.Range(2, 8);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

    }


    public GameObject lata;

    void SpawnCans() {

        int cansToSpawn = 1;
        for (int i = 0; i < cansToSpawn; i++) {

            GameObject temp = Instantiate(lata, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider col) {

        Vector3 point = new Vector3(
            Random.Range(col.bounds.min.x, col.bounds.max.x),

            Random.Range(col.bounds.min.y, col.bounds.max.y),

            Random.Range(col.bounds.min.z, col.bounds.max.z)
            );
        if (point != col.ClosestPoint(point)) {
            point = GetRandomPointInCollider(col);
        }

        point.y = 1;
        return point;
    }
}
