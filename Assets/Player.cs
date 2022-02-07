using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsSit = false;
    public int currentJumpCount = 0;
    public bool isGrounded = false;
    public bool OnceJumpRayCheck = false;

    public bool Is_DownJump_GroundCheck = false;
    float m_MoveX;
    public Rigidbody2D m_rigidbody;
    public CapsuleCollider2D m_CapsulleCollider;
    public Animator m_Anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
