using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSize : MonoBehaviour
{
    public float minSize = 0.5f;
    public float maxSize = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        RandomizeObjectSize();
    }

    void RandomizeObjectSize()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }
}
