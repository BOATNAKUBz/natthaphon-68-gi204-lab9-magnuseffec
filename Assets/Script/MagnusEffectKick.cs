using UnityEngine;
using UnityEngine.InputSystem;

public class MagnusEffectKick : MonoBehaviour
{
    public float kickForce;
    public float spinAmount;
    public float manusStrength = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    bool isShot = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isShot)
        {
            rb.AddForce(Vector3.forward * kickForce, ForceMode.Impulse);

            rb.AddTorque(Vector3.down * spinAmount);

            isShot = true;
        }

        
    }
    void FixedUpdate()
    {
        if (!isShot) return;
        {
            Vector3 velocity = rb.linearVelocity;
            Vector3 spin = rb.angularVelocity;

            Vector3 magnusForce = manusStrength * Vector3.Cross(spin, velocity);

            rb.AddForce(magnusForce);
        }
    }
}

