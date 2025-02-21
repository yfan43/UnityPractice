using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    public float amount;
    public UnityEvent onDeath;
    // Update is called once per frame
    void Update()
    {
        if (amount <= 0)
        {
            onDeath.Invoke();
            print(gameObject.name + " died");
            Destroy(gameObject);
        }
    }
}
