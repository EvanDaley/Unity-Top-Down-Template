using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratesPower : MonoBehaviour
{
    public float charge;
    public float incrementRate = 1f;
    public float incrementInterval = 2f;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = incrementInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            charge += incrementRate;
            timer = incrementInterval;
        }
    }

    public float WithdrawCharge(float amount)
    {
        if (charge >= amount)
        {
            charge -= amount;
            return amount;
        }
        else
        {
            return 0;
        }
    }
}
