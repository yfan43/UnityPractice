using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Vector2 movementValue;
    private float lookValue;
    private Rigidbody rigidbody;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rigidbody = GetComponent<Rigidbody>();
    }
    public void OnMove(InputValue value)
    {
      movementValue = value.Get<Vector2>() * speed;
    }

    public void onLook(InputValue value)
    {
       lookValue = value.Get<Vector2>().x * rotationSpeed;
    }

   //  public void OnMove(InputValue value)
   //  {
   //     movementValue = value.Get<Vector2>() * speed;
   //  }

   //  public void onLook(InputValue value)
   //  {
   //     lookValue = value.Get<Vector2>().x * rotationSpeed;
   //  }

   //  // Update is called once per frame
   //  void Update()
   //  {
   //     transform.Translate(movementValue.x * Time.deltaTime, 
   //     0, 
   //     movementValue.y * Time.deltaTime);
   //     transform.Rotate(0, lookValue * Time.deltaTime, 0);
   //  }
   void Update() {
      // if (Input.GetKey(KeyCode.W)) {
      //    transform.Translate(0, 0, speed * Time.deltaTime);
      // }
      rigidbody.AddRelativeForce(movementValue.x * Time.deltaTime, 0, movementValue.y * Time.deltaTime);
      rigidbody.AddRelativeTorque(0, lookValue * Time.deltaTime, 0);
   }
}
