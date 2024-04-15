using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using System.Collections;
using static Character;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;


public class PlayerInput : IMovable
{
    private readonly float _sensRotation;
    private readonly Rigidbody _rb;
    private readonly Transform _transform;
    private readonly float _vel;
    private float _velX;
    private float _velY;
    private bool _activeDirty;
    public bool _isAttacking;

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
        ActivateDirty();
        Character.Instance.ActivateFoots(_activeDirty);
        Character.Instance.WalkAnimations(_velY, _velX);
        Character.Instance.AttackAnimations(AttackAnimations());
       
    }

    
    public void ActivateDirty()
    {
        _activeDirty = _velY > 0;
    }


    public int AttackAnimations()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            return 1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            return 2;
        }

        if (Input.GetMouseButtonDown(1))
        {
            return 3;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            return 4;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            return 5;
        }
        
        return 0;
    }

    public void FixedUpdate()
    {
       
        if (!_isAttacking) 
        {
            Vector3 movement = new Vector3(0f, 0f, _velY).normalized * _vel * Time.deltaTime;
            _transform.Translate(movement);

            float rotation = _velX * _sensRotation * Time.deltaTime;
            _transform.Rotate(0f, rotation, 0f);
        }
        
    }


    public void OnCollisionEnter(Collision collision) {}

    public void OnCollisionExit(Collision collision) {}

    public void OnTriggerEnter(Collider other) {}

    public void OnTriggerExit(Collider other) {}
}