using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerInput : IMovable
{
    private readonly float _sensRotation;
    private readonly Rigidbody _rb;
    private readonly Transform _transform;
    private readonly float _vel;
    private float _velX;
    private float _velY;

    public PlayerInput(float sensRotation, Rigidbody rb, Transform transform, float vel)
    {
        _sensRotation = sensRotation;
        _rb = rb;
        _transform = transform;
        _vel = vel;
    }

    public void Update() 
    {
         _velX = Input.GetAxis("Horizontal");
         _velY = Input.GetAxis("Vertical");
        

    }
    public void FixedUpdate()
    {
        Vector3 movement = new Vector3(_velX, 0f, _velY).normalized;
        _rb.MovePosition(_transform.position + movement * _vel * Time.deltaTime);

        Debug.Log(_transform.position + movement);
            
        float rotation = _velX * _sensRotation * Time.deltaTime;
        _transform.Rotate(0f, rotation, 0f);
    }

    public void OnCollisionEnter(Collision collision) {}

    public void OnCollisionExit(Collision collision) {}

    public void OnTriggerEnter(Collider other) {}

    public void OnTriggerExit(Collider other) {}
}