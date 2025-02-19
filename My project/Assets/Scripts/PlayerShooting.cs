using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootpoint;
    // void Start()
    // {
    //     Cursor.visible = false;
    //     Cursor.lockState = CursorLockMode.Locked;
    // }
    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootpoint.transform.position;
            clone.transform.rotation = shootpoint.transform.rotation;
        }
    }
    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Mouse0))
    //     {
    //         print("Fire");
    //         GameObject clone = Instantiate(prefab);
    //         clone.transform.position = shootpoint.transform.position;
    //         clone.transform.rotation = shootpoint.transform.rotation;
    //     }
    // }
}
