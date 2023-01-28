using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurntableRecorder : MonoBehaviour
{
    public List<GameObject> objects;

    
    public int captureAngleInterval = 15;
    int captureTimeInterval;
    
    private void Start()
    {
        StartCoroutine(ObjectTurner());
        captureTimeInterval = 360 / captureAngleInterval;
    }

    // private void LateUpdate()
    // {
    //     var objectcount = 0;
    //     while (objectcount < objects.Count)
    //     {
    //         foreach (GameObject obj in objects)
    //         {
    //             obj.SetActive(true);
    //             for (int i = 1; i < captureTimeInterval; i++)
    //             {
    //                 obj.transform.Rotate(0, captureAngleInterval, 0);
    //             }
    //             obj.SetActive(false);
    //             objectcount++;
    //         }
    //     }
    // }

    public IEnumerator ObjectTurner()
    {
        int objectcount = 0;
        while (objectcount < objects.Count)
        {
            foreach (GameObject obj in objects)
            {
                    obj.SetActive(true);
                        yield return new WaitForEndOfFrame();
                        for (int i = 1; i < captureTimeInterval; i++)
                        {
                            obj.transform.Rotate(0, captureAngleInterval, 0);
                            yield return new WaitForEndOfFrame();
                        }
                        obj.SetActive(false);
                        objectcount++;
            }
        }
    }
}
