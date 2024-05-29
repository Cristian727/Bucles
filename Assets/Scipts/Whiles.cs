using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiles : MonoBehaviour
{
    //float elapsedTime;
    //[SerializeField] float maxTime;
    [SerializeField] Transform objectToMove;
    //[SerializeField] Transform pointA;
    //[SerializeField] Transform pointB;
    [SerializeField] List<Transform> Points;
    [SerializeField] List<Color> Colors;
    [SerializeField] AnimationCurve ease;
    [SerializeField] float AnimationDuration;

    Material material;


    int startPoint = 0;
    int endPoint = 1;

    void Start()
    {
        //elapsedTime = 0;
        //StartCoroutine(Frames());
        material = objectToMove.GetComponent<MeshRenderer>().material;
        StartCoroutine(Count());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Count()
    {
        float elapsedTime;

        while (true)
        {
            elapsedTime = 0;

            while (elapsedTime < AnimationDuration)
            {
                elapsedTime += Time.deltaTime;


                objectToMove.position = Vector3.LerpUnclamped(
                    Points[startPoint].position,
                    Points[endPoint].position,
                    ease.Evaluate(elapsedTime / AnimationDuration)
                );
                objectToMove.rotation = Quaternion.LerpUnclamped(
                    Points[startPoint].rotation,
                    Points[endPoint].rotation,
                    ease.Evaluate(elapsedTime / AnimationDuration)
                );
                material.color = Color.LerpUnclamped(
                    Colors[startPoint],
                    Colors[endPoint],
                    ease.Evaluate(elapsedTime / AnimationDuration)
                );

                yield return null;
            }

            UpdatePoints();

            yield return null;
        }
    }

    void UpdatePoints()
    {
        startPoint = endPoint;
        endPoint = (endPoint + 1) % Points.Count;
    }




    //IEnumerator Frames()
    //{

    //    while (true)
    //    {
    //        while (elapsedTime <= maxTime)
    //        {

    //            elapsedTime += Time.deltaTime;

    //            objectToMove.localPosition = Vector3.Lerp(pointA.position, pointB.position, elapsedTime / maxTime);
    //            print(elapsedTime);

    //            yield return null;
    //        }

    //        elapsedTime = 0;

    //        while (elapsedTime >= 0)
    //        {

    //            elapsedTime += Time.deltaTime;

    //            objectToMove.localPosition = Vector3.Lerp(pointB.position, pointA.position, elapsedTime / maxTime);
    //            print(elapsedTime);

    //            yield return null;

    //        }


    //    }


    //}

    //objectToMove.localPosition = new Vector3(elapsedTime, objectToMove.position.y, objectToMove.position.z);

    //IEnumerator Frames()
    //{
    //    while (frames < maxFrames)
    //    {

    //        print(frames++);

    //        yield return null;
    //    }

    //}
}
