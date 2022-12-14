using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPos = transform.localPosition;

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(0f, 1f) * magnitude;
            float y = Random.Range(1.86f, 4f) * magnitude;

            transform.localPosition = new Vector3(x, y, orignalPos.z);
            elapsed += Time.deltaTime;
            print("Tremendo");

            yield return null;
        }

        transform.localPosition = orignalPos;
    }
}
