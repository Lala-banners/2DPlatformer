using System.Collections;
using UnityEngine;

public class CrawlingEnemy : MonoBehaviour
{
    public Vector2 pointA;
    public Vector2 pointB;
    
    IEnumerator Start() {
        pointA = transform.position;

        while (true)
        {
            yield return StartCoroutine(Move(transform, pointA, pointB, 5.0f));
            yield return StartCoroutine(Move(transform, pointB, pointA, 5.0f));
        }
    }

    private IEnumerator Move(Transform thisT, Vector3 startPos, Vector3 endPos, float time) {
        float index = 0.0f;
        float rate = 1.0f / time;

        while (index < 1.0f)
        {
            index += Time.deltaTime * rate;
            thisT.position = Vector3.Lerp(startPos, endPos, index);
            yield return null;
        }
    }
}
