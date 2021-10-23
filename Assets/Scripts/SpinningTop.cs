using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningTop : MonoBehaviour
{

    [SerializeField] GameObject meshBase = null;
    [SerializeField] float accelerationSpeed = 2000f;
    [SerializeField] float startingRotationSpeed = 1000f;
    float currentRotationSpeed;

    [SerializeField] float collisionMultiplier = 100f;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        currentRotationSpeed = startingRotationSpeed;
    }
    void Update()
    {
        meshBase.transform.Rotate(transform.up, Time.deltaTime * currentRotationSpeed);
    }

    public void Move(Vector3 pushForce) 
    {
        rb.AddForce(pushForce.normalized * accelerationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(IsCollisionValid(collision)) 
        {
            Rigidbody hitRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            SpinningTop hitTop = collision.gameObject.GetComponent<SpinningTop>();
            if (rb.velocity.sqrMagnitude > hitRigidbody.velocity.sqrMagnitude) 
            {
                rb.AddForce(-rb.velocity.normalized * collisionMultiplier * startingRotationSpeed / currentRotationSpeed * 2);
                hitRigidbody.AddForce(rb.velocity.normalized * collisionMultiplier * startingRotationSpeed / currentRotationSpeed);
            }
            else 
            {
                hitRigidbody.AddForce(-hitRigidbody.velocity.normalized * collisionMultiplier / 2);
                rb.AddForce(hitRigidbody.velocity.normalized * collisionMultiplier);
            }
        }
    }

    bool IsCollisionValid(Collision collision) 
    {
        bool sameLayer = collision.gameObject.layer == gameObject.layer;
        bool higherPriority = collision.gameObject.GetInstanceID() < gameObject.GetInstanceID();
        return sameLayer && higherPriority;
    }

}
