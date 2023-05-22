using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private float sizeY;
    Vector2 startPos;
    void Start()
    {
        startPos = transform.position;  
        sizeY = GetComponent<SpriteRenderer>().bounds.size.y;
        print(sizeY);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed*Time.deltaTime);
        if (transform.position.y < startPos.y - sizeY)
        {
            transform.position = startPos;
        }

    }
}
