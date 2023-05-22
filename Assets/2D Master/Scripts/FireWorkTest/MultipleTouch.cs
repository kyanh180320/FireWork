using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTouch : MonoBehaviour
{
    public List<TouchLocation> touches = new List<TouchLocation>();
    public ParticleSystem[] arrayFireWork;
    public GameObject Scia;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if(t.phase == TouchPhase.Began)
            {
                Debug.Log("touch began");
                touches.Add(new TouchLocation(t.fingerId, createScia(t),createFireWork(t)));
            }
            else if (t.phase == TouchPhase.Ended)
            {
                print("touch ended");
                TouchLocation thisTouch = touches.Find(TouchLocation => TouchLocation.touchId == t.fingerId);

                if (thisTouch != null)
                {
                    thisTouch.FireWork.transform.position = getTouchPosition(t.position);
                    thisTouch.FireWork.gameObject.SetActive(true);
                    thisTouch.FireWork.Play();
                    Destroy(thisTouch.scia);
                    StartCoroutine(DelayDestroy(thisTouch));
                    touches.RemoveAt(touches.IndexOf(thisTouch));

                }

            }
            else if (t.phase == TouchPhase.Moved)
            {
                print("touch is moving");
                TouchLocation thisTouch = touches.Find(TouchLocation => TouchLocation.touchId == t.fingerId);
                if (thisTouch != null)
                {
                    thisTouch.scia.transform.position = getTouchPosition(t.position);
                }
            }
            i++;
        }
        Vector2 getTouchPosition(Vector2 touchPosition)
        {
            //return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
            return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
        }
        GameObject createScia(Touch t)
        {
            GameObject c = Instantiate(Scia);
            c.name = "Touch" + t.fingerId;
            c.transform.position = t.position;
            return c;
        }
        ParticleSystem createFireWork(Touch t)
        {
            int random = Random.Range(0, arrayFireWork.Length);
            ParticleSystem f = Instantiate(arrayFireWork[random]);
            f.transform.position = t.position;
            f.gameObject.SetActive(false);
            return f;
        }
        IEnumerator DelayDestroy(TouchLocation touchLocation)
        {
            yield return new WaitForSeconds(1f);
            Destroy(touchLocation.FireWork.gameObject);
        }
     
 
    }
}
