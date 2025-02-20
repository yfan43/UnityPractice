using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractDestroyer : MonoBehaviour
{
    // void OnTriggerEnter()
    // {
    //     Destroy(gameObject);
    // }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
