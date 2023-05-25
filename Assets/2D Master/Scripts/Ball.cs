using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private ParticleSystem[] FireWorkPrefab;
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {

        }

    }

    private void OnMouseDown()
    {
        FindObjectOfType<TouchFireWork>().GetFireWork(gameObject);
        Destroy(gameObject);

    }
}

