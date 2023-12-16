using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumesPower : MonoBehaviour
{
    public float charge;
    public float pullRate = 1f;
    public float interval = 2f;
    public float timer;

    public Material unpoweredMaterial; // Variable referencing Unity material
    public Material poweredMaterial; // Variable referencing another Unity material

    // TODO: Move this out to another class. Break up the responsibilities of "consume power" and "perform action"
    private float minChargeForAction = 1000f;
    private float maxCharge = 1005f;

    // TODO: Make this reference an interface instead of a concrete class
    public GeneratesPower generator;

    private Renderer renderer;
    private bool wasCharged = false; // Variable indicating if the cube was in a charged state on the previous frame

    // Start is called before the first frame update
    void Start()
    {
        timer = interval;
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            WithdrawCharge();
            timer = interval;
        }

        bool isCharged = charge > minChargeForAction;
        if (isCharged != wasCharged)
        {
            toggleChargedState();
            wasCharged = isCharged;
        }
    }

    void WithdrawCharge()
    {
        if (charge >= maxCharge)
        {
            return;
        }
        float amount = generator.WithdrawCharge(pullRate);
        charge += amount;
    }

    void toggleChargedState()
    {
        Material[] materials = renderer.materials;

        if (materials[0] == poweredMaterial)
        {
            materials[0] = unpoweredMaterial;
        }
        else
        {
            materials[0] = poweredMaterial;
        }

        renderer.materials = materials;
    }
}
