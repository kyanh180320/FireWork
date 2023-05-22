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
            createFireWork();
        }

    }
    IEnumerator DelayDestroyFireWork(ParticleSystem firework)
    {
        yield return new WaitForSeconds(1f);
        Destroy(firework.gameObject);
    }
    void createFireWork()
    {
        int random = Random.Range(0, FireWorkPrefab.Length);
        ParticleSystem FireWorkSpawn = Instantiate(FireWorkPrefab[random], transform.position, Quaternion.identity);
        FireWorkSpawn.Play();
        Destroy(gameObject);
        StartCoroutine(DelayDestroyFireWork(FireWorkSpawn));
    }
    private void OnMouseDown()
    {
        createFireWork();
    }
}
