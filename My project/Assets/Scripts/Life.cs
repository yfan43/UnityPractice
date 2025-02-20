using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float amount;
    // Update is called once per frame
    void Update()
    {
        if (amount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
