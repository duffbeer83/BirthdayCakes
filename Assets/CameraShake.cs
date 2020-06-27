using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitiude)
    {
        //var origPos = transform.localPosition;
        var elapsed = 0f;

        while(elapsed < duration)
        {
            var x = Random.Range(-1f, 1f) * magnitiude;
            var y = Random.Range(-1f, 1f) * magnitiude;

            transform.localPosition = new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition =  new Vector3(0,0,0);
    }
}
