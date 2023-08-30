using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public static event Action OnInventoryInputPressed;
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

        playerInputs.PlayerMove.Inventory.started += OnInventoryInput;
        playerInputs.PlayerMove.Inventory.started += OnInventoryInput;
    }

    private void Update()
    {
        MoveHandler();
    }

    private void OnInventoryInput(InputAction.CallbackContext context)
    {
        OnInventoryInputPressed?.Invoke();
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
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
