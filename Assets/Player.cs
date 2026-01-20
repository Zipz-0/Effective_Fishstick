using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputActionReference movement;
    public GameObject model;
    Rigidbody rb;
    Vector3 Direction;
    Quaternion lookRotation;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Direction = movement.action.ReadValue<Vector3>();
        Look();
    }

    void FixedUpdate()
    {
        if(rb)
        {
            float speed = 5f;
            Vector3 vel = new Vector3(Direction.x * speed, rb.linearVelocity.y, Direction.z * speed);

            rb.linearVelocity = vel;

            model.transform.rotation = lookRotation;
        }
    }

    void Look()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);

        Physics.Raycast(ray, out RaycastHit hitInfo, 1000f, LayerMask.GetMask("Ground"));
        if(hitInfo.collider != null)
        {
            Vector3 lookPoint = hitInfo.point;
            lookPoint.y = transform.position.y;

            Vector3 lookDir = (lookPoint - transform.position).normalized;
            if(lookDir != Vector3.zero)
            {
                lookRotation = Quaternion.LookRotation(lookDir);
                
            }

        }
    }
}
