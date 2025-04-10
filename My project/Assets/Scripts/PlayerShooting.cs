using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootpoint;

    public int bulletsAmount;
    // public float fireRate;
    // public AudioSource shootSound;
    // Animator animator;
    // void Start()
    // {
    //     Cursor.visible = false;
    //     Cursor.lockState = CursorLockMode.Locked;
    // }
    // private void Awake()
    // {
        // animator = GetComponent<Animator>();
    // }
    public void OnFire(InputValue value)
    {
        // animator.SetBool("Shooting", value.isPressed);
        if (value.isPressed && bulletsAmount > 0 && Time.timeScale > 0)
        {
            bulletsAmount--;
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootpoint.transform.position;
            clone.transform.rotation = shootpoint.transform.rotation;
            // shootSound.Play();
        }
    }


    // have the code but does not work
    // private void Shoot()
    // {
    //     if (bulletsAmount > 0 && Time.timeScale > 0)
    //     {
    //         bulletsAmount--;
    //         GameObject clone = Instantiate(prefab);
    //         clone.transform.position = shootpoint.transform.position;
    //         clone.transform.rotation = shootpoint.transform.rotation;
    //     }
    // }

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
