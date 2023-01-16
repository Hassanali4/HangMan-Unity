using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void OnEnable()
    {
        originalPos = transform.localPosition;
    }

    public void Shakeit()
    {
        StartCoroutine(Shake());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Shake());
        }
    }
    public IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < 0.5f)
        {
            float x = Random.Range(-1f, 1f) * shakeAmount;
            float y = Random.Range(-1f, 1f) * shakeAmount;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}