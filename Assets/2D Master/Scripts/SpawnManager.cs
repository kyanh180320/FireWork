using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject bom;
    public BoxCollider2D grid;
    public float minAngle = -15f;
    public float maxAngle = 15f;
    float thrust;
    bool randomBom;
    Vector2 direction;
    void Start()
    {
        InvokeRepeating("SpawnBall", 1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
    }
    void SpawnBall()
    {
        randomBom = (Random.value > 0.7f) ? true : false;
        int maxBall = Random.Range(1, 4);
        for (int i = 0; i < maxBall; i++)
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
            thrust = Random.Range(60, 80);
            Bounds bounds = grid.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            Vector2 spawnBallPos = new Vector2(x, y);
            GameObject ballSpawn = Instantiate(ball, spawnBallPos, rotation);
         
            ballSpawn.GetComponent<Rigidbody2D>().AddForce(DirectionSpawn(direction,x) * thrust);
            if (randomBom)
            {
                int thrustBom = Random.Range(60,80);
                float bomSpawnX = Random.Range(bounds.min.x, bounds.max.x);
                float bomSpawnY = Random.Range(bounds.min.y, bounds.max.y);
                Vector2 spawnBomPos = new Vector2(bomSpawnX, bomSpawnY);
                GameObject bomSpawn = Instantiate(bom, spawnBomPos, rotation);
                bomSpawn.GetComponent<Rigidbody2D>().AddForce(DirectionSpawn(direction,bomSpawnX) * thrustBom);
                randomBom = false;

            }
        }


    }
    Vector2 DirectionSpawn(Vector2 direction, float x)
    {
        if (x < 0)
        {
            direction = new Vector2(1, 6);
        }
        else if (x > 0)
        {
            direction = new Vector2(-1, 6);
        }
        else
        {
            direction = Vector2.up;
        }
        return direction;   
    }
    
}
