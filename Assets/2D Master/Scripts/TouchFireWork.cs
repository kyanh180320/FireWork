using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchFireWork : MonoBehaviour
{
    public List<TouchFireWorkLocation> touches = new List<TouchFireWorkLocation>();
    public ParticleSystem[] arrayFireWork;
    public GameObject Scia;
    CircleCollider2D circleCollider;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;
    }
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                //circleCollider.enabled = true;
                Debug.Log("touch began");
                touches.Add(new TouchFireWorkLocation(t.fingerId, createScia(t)));
            }
            else if (t.phase == TouchPhase.Ended)
            {
                circleCollider.enabled = false;
                print("touch ended");
                TouchFireWorkLocation thisTouch = touches.Find(TouchFireWorkLocation => TouchFireWorkLocation.touchId == t.fingerId);

                if (thisTouch != null)
                {
                  
                    Destroy(thisTouch.scia);
                    touches.RemoveAt(touches.IndexOf(thisTouch));

                }

            }
            else if (t.phase == TouchPhase.Moved)
            {
                transform.position = getTouchPosition(t.position);
                print("touch is moving");
                TouchFireWorkLocation thisTouch = touches.Find(TouchFireWorkLocation => TouchFireWorkLocation.touchId == t.fingerId);
                if (thisTouch != null)
                {
                    thisTouch.scia.transform.position = getTouchPosition(t.position);
                }
                circleCollider.enabled = true;
            }
            i++;
        }
        Vector2 getTouchPosition(Vector2 touchPosition)
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
        }
        GameObject createScia(Touch t)
        {
            GameObject c = Instantiate(Scia);
            c.name = "Touch" + t.fingerId;
            c.transform.position = t.position;
            return c;
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    int random = Random.Range(0, arrayFireWork.Length);
    //    ParticleSystem fireworkSpawn = Instantiate(arrayFireWork[random], collision.gameObject.transform.position, Quaternion.identity);
    //    fireworkSpawn.Play();
    //    StartCoroutine(DelayDestroyFireWork(fireworkSpawn));
    //    Destroy(collision.gameObject);
    //}
    //IEnumerator DelayDestroyFireWork(ParticleSystem firework)
    //{
    //    yield return new WaitForSeconds(1f);
    //    Destroy(firework.gameObject);
    //}
}
