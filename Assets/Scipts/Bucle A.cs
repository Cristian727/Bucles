using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucleA : MonoBehaviour
{
    [SerializeField] int times;
    [SerializeField] float timeBetweenPrints;
    [SerializeField] GameObject prefab;
    Vector3 position;
    int numberSpheres = 1;
    [SerializeField] int start;
    [SerializeField] Vector3 rotationSpeed;
    [SerializeField] bool rotate;
    List<GameObject> instantedObjects = new List<GameObject>();
    Coroutine coroutine = null;
    
    void Start()
    {

        StartCoroutine(Loop());
        StartCoroutine(objectRotation());

    }


    IEnumerator betweenNumber()
    {
        //<= start + times - 1
        for (int i = start; i < start + times; i++)
            for(int j = start; j < start + times; j++)
                for (int k = start; k < start + times; k++)
                {
                if((i == start && j == start) || 
                   (i == start && k == start) || 
                   (j == start && k == start) ||
                   (i == start && j == start + times -1) ||
                   (i == start && k == start + times - 1) ||
                   (j == start && k == start + times - 1) ||
                   ((i == start + times - 1) && j == start) ||
                   ((i == start + times - 1) && k == start) ||
                   ((j == start + times - 1) && k == start) ||
                   (i == start + times - 1 && j == start + times - 1) ||
                   (i == start + times - 1 && k == start + times - 1) ||
                   (j == start + times - 1 && k == start + times - 1) 
                   )
                        
                        // || i == start + times -1|| j == start + times -1 || k == start + times -1)
                   {
                    position = new Vector3(i, j, k);
                    //print(Vector3);
                    instantiate(position);
                    yield return new WaitForSeconds(timeBetweenPrints);

                  }
                }
        coroutine = null;
    }
     IEnumerator objectRotation()
     {
        while (true)
        {
             if (rotate == true)
             {
               transform.Rotate(rotationSpeed * Time.deltaTime);
             }
               yield return null;
        }
     }


    void instantiate(Vector3 position)
    {

        GameObject instantiated = Instantiate(
            prefab,
            transform
            );

        instantiated.transform.localPosition = position;

        instantiated.name = "Sphere " + numberSpheres++;
        print(instantiated + "en la ubicaci�n" + position);

        instantedObjects.Add(instantiated);

        
        float Normalize(float value, float min, float max)
        {
            return (value - min) / (max - min);
        }

        instantiated.GetComponent<MeshRenderer>().material.color = new Color(
            Normalize(position.x, 0, 5),
            Normalize(position.y, 0, 5),
            Normalize(position.z, 0, 5));

    }

    IEnumerator destroySpheres()
    {
        while (instantedObjects.Count > 0)
        {
            Destroy(instantedObjects[0]);
            instantedObjects.RemoveAt(0);
            yield return new WaitForSeconds(timeBetweenPrints);
        }

        coroutine = null;
    }

    IEnumerator Loop()
    {
        while (true)
        {
            coroutine = StartCoroutine(betweenNumber());
            while (coroutine != null)
                yield return null;
            coroutine = StartCoroutine(destroySpheres());
            while (coroutine != null)
                yield return null;
        }
    }

    //IEnumerator betweenNumber()
    //{
    //    for (int i = start; i <= start + times - 1; i++)
    //        for (int k = start; k <= i; k++)
    //        {
    //            position = new Vector3(k, k, 0);
    //            //print(Vector3);
    //            instantiate(position);
    //            yield return new WaitForSeconds(timeBetweenPrints);

    //        }

    //}
}
