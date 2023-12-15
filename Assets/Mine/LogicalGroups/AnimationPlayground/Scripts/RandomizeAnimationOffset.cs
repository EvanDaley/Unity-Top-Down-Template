using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAnimationOffset : MonoBehaviour
{
    private Animator animator;
    private float randomSpeedAdjustment;
    private float randomOffset;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        randomSpeedAdjustment = Random.Range(-0.1f, 0.1f);
        randomOffset = Random.Range(0f, 1f);
        animator.Play("Armature|TailWag_002", -1, randomOffset);
        animator.speed += randomSpeedAdjustment;
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic here if needed
    }
}
