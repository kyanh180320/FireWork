using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    // Start is called before the first frame update
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
