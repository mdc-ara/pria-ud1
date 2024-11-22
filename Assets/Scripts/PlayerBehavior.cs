using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    public float JumpVelocity=5f;
    private bool _isJumping;
    public float DistanceToGround=0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        vInput =Input.GetAxis("Vertical")*moveSpeed;
        hInput =Input.GetAxis("Horizontal")*rotateSpeed;
        _isJumping |= Input.GetKeyDown(KeyCode.J);
        /*
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        */
    }
    void FixedUpdate(){
        Vector3 rotation=Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation*Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput
         * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
        if(_isJumping && IsGrounded()){
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
        _isJumping=false;
    }

    private bool IsGrounded(){
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
         _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_col.bounds.center,
         capsuleBottom, DistanceToGround, GroundLayer,
         QueryTriggerInteraction.Ignore);
         
        return grounded;
    }
}
