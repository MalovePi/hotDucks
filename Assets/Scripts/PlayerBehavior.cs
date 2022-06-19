using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 75f;
    [SerializeField] private float jumpVelocity = 5f;
    [SerializeField] private float distanceToGround = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private float _verticalInput;
    private float _horizontalInput;
    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;

    private GameBehavior _gameMenager;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _gameMenager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void Update()
    {
        _verticalInput = Input.GetAxis("Vertical") * moveSpeed;
        _horizontalInput = Input.GetAxis("Horizontal") * rotateSpeed;           

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }       
    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _horizontalInput;  
        Quaternion angleRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rigidbody.MovePosition(this.transform.position + this.transform.forward * _verticalInput * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * angleRotation); 
    }

    private bool IsGrounded ()
    {
        Vector3 capsuleBottom = new Vector3(_capsuleCollider.bounds.center.x, _capsuleCollider.bounds.min.y, _capsuleCollider.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_capsuleCollider.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "EnemyDuck")
        {
            _gameMenager.PlayerHP -= 1;
        }
    }
}