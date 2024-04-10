using UnityEngine;

public interface IMovable
{
    void Move();
    void OnCollisionEnter(Collision collision);
    void OnCollisionExit(Collision collision);
    void OnTriggerEnter(Collider other);
    void OnTriggerExit(Collider other);
}