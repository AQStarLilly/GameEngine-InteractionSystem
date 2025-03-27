using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D playerRigidbody;
    public Vector2 moveVector = Vector2.zero;

    [SerializeField]
    private float moveSpeed = 3.0f;

    [SerializeField]
    private float sprintMultiplier = 2f;

    private float currentSpeed;
    public float magnitudeDebug;

    public bool canMove = true;

    // Start is called before the first frame update
    void Awake()
    {
        Actions.MoveEvent += UpdateMoveVector;
        Actions.SprintEvent += UpdateSprintState;

        currentSpeed = moveSpeed;
    }

    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleAnimation();
    }
    private void UpdateMoveVector(Vector2 InputVector)
    {
        if (!canMove)
        {
            moveVector = Vector2.zero;
            return;
        }
        moveVector = InputVector;
    }

    private void UpdateSprintState(bool isSprinting)
    {
        currentSpeed = isSprinting ? moveSpeed * sprintMultiplier : moveSpeed;
    }

    void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    void HandlePlayerMovement()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + moveVector * currentSpeed * Time.fixedDeltaTime);
    }

    void HandleAnimation()
    {
        if(moveVector.magnitude != 0)
        {
            animator.SetFloat("Horizontal", moveVector.x);
            animator.SetFloat("Vertical", moveVector.y);
            animator.SetFloat("LastMoveHorizontal", moveVector.x);
            animator.SetFloat("LastMoveVertical", moveVector.y);
            animator.SetBool("Moving", true);
        }
        else
        {          
            animator.SetBool("Moving", false);
        }

    }

    void OnDisable()
    {
        Actions.MoveEvent -= UpdateMoveVector;
        Actions.SprintEvent -= UpdateSprintState;
    }
}
