using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private PlayerControls playerInputs;
    private Animator animator;

    Vector2 moveDirection;

    [Header("Character Data")]
    [SerializeField] private float velocity;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInputs = new PlayerControls();

        playerInputs.PlayerMove.Move.started += OnMoveInput;
        playerInputs.PlayerMove.Move.performed += OnMoveInput;
        playerInputs.PlayerMove.Move.canceled += OnMoveInput;
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        MoveHandler();
    }

    private void MoveHandler()
    {
        transform.Translate(moveDirection * velocity * Time.deltaTime);
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }
}
