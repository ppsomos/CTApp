using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    [SerializeField] float WalkSpeed;
    [SerializeField] float RunSpeed;
    [SerializeField] float turnsmoothTime = 0.1f;

    [SerializeField] bool isGrounded;
    [SerializeField] float GroundCheckDistance;
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] float Gravity;
    [SerializeField] float jumpHeight;
    [SerializeField] Transform Cam;

    float turnSmoothVelocity;
    Vector3 MoveDir;
    Vector3 Velocity;
    CharacterController controler;
    bool isRun;
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controler=GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, GroundCheckDistance, GroundLayer);
        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }
        float Hor =ControlFreak2.CF2Input.GetAxis("Horizontal");
        float Ver = ControlFreak2.CF2Input.GetAxis("Vertical");
        MoveDir = new Vector3(Hor, 0f, Ver).normalized;
        if(MoveDir.magnitude > .1f)
        {
            float targetangle = Mathf.Atan2(MoveDir.x, MoveDir.z) * Mathf.Rad2Deg +Cam.eulerAngles.y;
            float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnSmoothVelocity, turnsmoothTime);
            transform.rotation = Quaternion.Euler(0f, angel, 0f);
            Vector3 MDirection=Quaternion.Euler(0f,angel,0f) * Vector3.forward;
            controler.Move(MDirection.normalized * MoveSpeed * Time.deltaTime);
            
        }
        if (MoveDir != Vector3.zero && !isRun)
        {
            Walk();
        }
        else if (MoveDir != Vector3.zero  && isRun)
        {
            Run();
        }
        else if (MoveDir == Vector3.zero)
        {
            Idle();
        }
        if (ControlFreak2.CF2Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        else
        {
            anim.SetBool("Isjump", false);
        }

        Velocity.y += Gravity * Time.deltaTime;
        controler.Move(Velocity * Time.deltaTime);
    }
    void Walk()
    {
        MoveSpeed = WalkSpeed;
        anim.SetFloat("Speed", .25f,.1f,Time.deltaTime);
    }
    void Run()
    {
        MoveSpeed = RunSpeed;
        anim.SetFloat("Speed", .5f, .1f, Time.deltaTime);
    }
    void Idle()
    {
        MoveSpeed = 0;
        anim.SetFloat("Speed", 0f, .1f, Time.deltaTime);
    }
    void Jump()
    {
        Velocity.y = Mathf.Sqrt(jumpHeight * -2 * Gravity) ;
        anim.SetBool("Isjump", true);
    }
    public void OnRunBtmPress()
    {
        isRun=true;
    }
    public void OnRunBtmRealese()
    {
        isRun = false;
    }
    
}
