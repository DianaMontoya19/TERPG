using UnityEngine;


public interface IInput
{
    void Move();
}

public interface IInputAddons
{
    void OnCollisionEnter(Collision collision);
    void OnCollisionExit(Collision collision);
    void OnTriggerEnter(Collider other);
    void OnTriggerExit(Collider other);
}