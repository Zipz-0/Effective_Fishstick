using Mono.Cecil;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputActionReference movement;
    public InputActionReference attack;
    public GameObject model;
    Rigidbody rb;
    Animator animator;
    Vector3 Direction;
    Vector3 vel;
    Quaternion lookRotation;

    void Awake()
    {
        Init();
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

            vel = Vector3.Lerp(vel, new Vector3(Direction.x * speed, rb.linearVelocity.y, Direction.z * speed), 0.265f);

            rb.linearVelocity = vel;
            animator.SetFloat("Speed", vel.magnitude);

            model.transform.rotation = lookRotation;
        }
    }

    private void OnEnable()
    {
        attack.action.started += Fire;
    }

    private void OnDisable()
    {
        attack.action.started -= Fire;
    }

    void Init()
    {
        rb = GetComponent<Rigidbody>();
        animator = model.GetComponent<Animator>();
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Attack!");
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
