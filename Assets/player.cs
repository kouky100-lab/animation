using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;
    Vector3 input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.maxAngularVelocity = 20f;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        input = new Vector3(h, 0f, v);
    }

    void FixedUpdate()
    {

        if (input.magnitude < 0.1f)
        {
            rb.angularVelocity *= 0.95f;
            return;
        }


        rb.angularVelocity *= 0.8f;


        Vector3 torque = new Vector3(input.z, 0, -input.x) * speed;
        rb.AddTorque(torque, ForceMode.Force);
    }
}

