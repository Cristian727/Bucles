using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAnimation : MonoBehaviour
{
    [SerializeField] float targetScale;
    [SerializeField] float animationDuration;
    [SerializeField] AnimationCurve ease;
    float elapsedTime;
    [SerializeField] Transform tile;

    void Start()
    {
        elapsedTime = 0;
        StartCoroutine(Animation());
    }


    IEnumerator Animation()
    {
        Vector3 minVector = Vector3.one;
        Vector3 maxVector = Vector3.one * targetScale;
        //Vector3 maxVector = new Vector3(targetScale, targetScale, targetScale);


            while (elapsedTime <= animationDuration)
            {

                elapsedTime += Time.deltaTime;

                tile.localScale = Vector3.Lerp(
                    minVector,
                    maxVector, 
                    ease.Evaluate(elapsedTime / animationDuration)
                );
                print(elapsedTime);

                yield return null;
            }

            elapsedTime = animationDuration;

    }
}
