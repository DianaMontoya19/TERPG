using UnityEngine;
using UnityEngine.AI;


public class Character : MonoBehaviour
{
    [Header("AnimationConfig")]
    [SerializeField] private ParticleSystem dirtFoots;
    

    private Animator _animator;
    private Rigidbody _rb;
    private Transform _transform;
    private NavMeshAgent _navMeshAgent;

    public Animator Animator => _animator;
    public Rigidbody Rb => _rb;
    public Transform Transform => _transform;
    public NavMeshAgent Agent => _navMeshAgent;
    
    private IInput _input;
    private IInputAddons _inputAddons;
    
    // [SerializeField] private float impulso = 5f;
    // public float lastDodgeTime = -1f;
    // public float doubleTap = 0.2f;
    // private bool _isAction;

    private float VelX => _rb.velocity.x;
    private float VelY => _rb.velocity.y;

    public void Configure(IInput input, IInputAddons inputAddons = null)
    {
        _input = input;
        _inputAddons = inputAddons;
    }
    
    protected virtual void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _transform = transform;
        // lastDodgeTime = -1f;
        // _isAction = false;
    }

    private void Start()
    {
        dirtFoots.Stop();
        _navMeshAgent.isStopped = true;
    }

    protected virtual void FixedUpdate()
    {
        _input.Move();
    }

    private void Update()
    {
        // AttacckAnimations();
        // if (!_isAction)
        // {
        //     // HandleDodge();
        //     
        // }
        WalkAnimations();
        DirtyFoots();
    }

    private void OnCollisionEnter(Collision other)
    {
        _inputAddons?.OnCollisionEnter(other);
    }

    private void OnCollisionExit(Collision other)
    {
        _inputAddons?.OnCollisionExit(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        _inputAddons?.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        _inputAddons?.OnTriggerExit(other);
    }

    private void WalkAnimations()
    {
        _animator.SetFloat("VelX", VelY);
        _animator.SetFloat("VelY", VelX);
    }

    private void DirtyFoots()
    {
        if (VelX < -0.6 || VelX > 0.6 || VelY < -0.6 || VelY > 0.6)
        {
            // dirtFoots.Play();
        }
    }
    
    // No es por ahora
    // private void AttacckAnimations()
    // {
    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         isAction = true;
    //         animator.SetTrigger("Attack3");
    //     }
    //
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         isAction = true;
    //         animator.SetTrigger("BlockAttack");
    //     }
    //
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         isAction = true;
    //         animator.SetTrigger("Attack1");
    //     }
    //
    //     if (Input.GetMouseButtonDown(1))
    //     {
    //         isAction = true;
    //         animator.SetTrigger("Attack2");
    //     }
    //
    //     if ( Input.GetKey(KeyCode.Q))
    //     {
    //         animator.SetBool("Block", true);
    //         isAction = true;
    //     }
    //
    //     else
    //     {
    //         animator.SetBool("Block", false);
    //         isAction = false;
    //     }
    // }
    // private void HandleDodge()
    // {
    //     if (Input.GetKeyUp(KeyCode.S))
    //     {
    //         if (Time.time - lastDodgeTime < doubleTap)
    //         {
    //             ImpulseBackDodge();
    //             animator.SetTrigger("DodgeAft");
    //             lastDodgeTime = Time.time;
    //         }
    //         else
    //         {
    //             lastDodgeTime = Time.time;
    //         }
    //     }
    //     if (Input.GetKeyUp(KeyCode.A))
    //     {
    //         if (Time.time - lastDodgeTime < doubleTap)
    //         {
    //             ImpulseLeftDodge();
    //             animator.SetTrigger("DodgeLeft");
    //             lastDodgeTime = Time.time;
    //         }
    //         else
    //         {
    //             lastDodgeTime = Time.time;
    //         }
    //     }
    //     if (Input.GetKeyUp(KeyCode.D))
    //     {
    //         if (Time.time - lastDodgeTime < doubleTap)
    //         {
    //             ImpulseRightDodge();
    //             animator.SetTrigger("DodgeRight");
    //             lastDodgeTime = Time.time;
    //         }
    //         else
    //         {
    //             lastDodgeTime = Time.time;
    //         }
    //     }
    //     if (Input.GetKeyUp(KeyCode.W))
    //     {
    //         if (Time.time - lastDodgeTime < doubleTap)
    //         {
    //             ImpulseForwardDodge();
    //             animator.SetTrigger("DodgeFwd");
    //             lastDodgeTime = Time.time;
    //         }
    //         else
    //         {
    //             lastDodgeTime = Time.time;
    //         }
    //     }
    // }
    //
    // private void ImpulseBackDodge()
    // {
    //     rb.AddForce(-transform.forward * impulso, ForceMode.Impulse);
    // }
    //
    // private void ImpulseRightDodge()
    // {
    //     rb.AddForce(transform.right * impulso, ForceMode.Impulse);
    // }
    //
    // private void ImpulseLeftDodge()
    // {
    //     rb.AddForce(-transform.right * impulso, ForceMode.Impulse);
    // }
    //
    // private void ImpulseForwardDodge()
    // {
    //     rb.AddForce(transform.forward * impulso, ForceMode.Impulse);
    // }
    //
    // public void ResetIsAction()
    // {
    //     isAction = false;
    // }
    //
}
