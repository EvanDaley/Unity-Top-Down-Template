using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            if (renderer != null)
            {
                Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0.5f, 1f), 0f);
                renderer.material.color = randomColor;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
