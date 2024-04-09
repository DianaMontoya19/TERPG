using UnityEngine;

public class PlayerInput : IInput
{
    private readonly float _sensRotation;
    private readonly Rigidbody _rb;
    private readonly Transform _transform;
    private readonly float _vel;

    public PlayerInput(float sensRotation, Rigidbody rb, Transform transform, float vel)
    {
        _sensRotation = sensRotation;
        _rb = rb;
        _transform = transform;
        _vel = vel;
    }

    public void Move()
    {
        float velX = Input.GetAxis("Horizontal");
        float velY = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(velX, 0f, velY).normalized;
        if (velY < 0)
        {
            _rb.MovePosition(_rb.position + _transform.TransformDirection(direction) * _vel / 2 * Time.fixedDeltaTime);
        }
        else
        {
            _rb.MovePosition(_rb.position + _transform.TransformDirection(direction) * (_vel * Time.fixedDeltaTime));
        }

        float rotation = velX * _sensRotation * Time.deltaTime * 0.5f;
        _transform.Rotate(0f, rotation, 0f);
    }
    
}