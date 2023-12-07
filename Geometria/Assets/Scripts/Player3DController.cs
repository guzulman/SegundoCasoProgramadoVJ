using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player3DController : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 5.0F;

    [SerializeField]
    float runSpeed = 5.0F;

    [SerializeField]
    float rotationSpeed = 500.0F;

    [SerializeField]
    float jumpForce = 25.0F;

    [SerializeField]
    float gravityMultiplier = 12.5F;

    [SerializeField]
    float maximumNumberOfJumps = 2;

    CharacterController _characterController;

    Camera _mainCamera;

    Vector3 _input;
    Vector3 _direction;

    float _inputX;
    float _inputZ;
    float _velocityY;
    float _gravityY;
    float _currentVelocity;

    int _numberOfJumps;

    bool _isMovePressed = false;
    bool _isRunning = false;
    bool _isJumpPressed = false;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;

        _gravityY = Physics.gravity.y;
    }

    void Update()
    {
        HandleInputs();

        HandleGraity();
        HandleRotation();
        HandleMove();
    }

    private void HandleGraity()
    {
        if (IsGrounded())
        {
            if(_velocityY < -1.0F)
            {
                _velocityY = -1;
            }

            if(_isJumpPressed)
            {
                HandleJump();
                StartCoroutine(WaitForGroundedCoroutine());
            }
        }
        else    
        {
            if(_isJumpPressed && maximumNumberOfJumps > 1)
            {
                HandleJump();
            }
            _velocityY += _gravityY * gravityMultiplier * Time.deltaTime;
        }
    }

    private void HandleJump()
    {
        _isJumpPressed = false;

        if(_numberOfJumps >= maximumNumberOfJumps)
        {
            return;
        }

        _numberOfJumps++;
        _velocityY = jumpForce;
    }

    private void HandleRotation()
    {
        if (_input.sqrMagnitude == 0)
        {
            _direction = Vector3.zero;
            return;
        }

        _direction =
            Quaternion.Euler(0.0F, _mainCamera.transform.eulerAngles.y, 0.0F) * new Vector3(_input.x, 0.0F, _input.z);
        Quaternion targetRotation = Quaternion.LookRotation(_direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void HandleMove()
    {
        float speed = _isRunning 
            ? runSpeed
            : walkSpeed;

        _direction.y = _velocityY;
        _characterController.Move(_direction * speed * Time.deltaTime);
    }

    void HandleInputs()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputZ = Input.GetAxisRaw("Vertical");
        _input = new Vector3(_inputX, 0.0F, _inputZ);

        _isMovePressed = _inputX != 0.0F || _inputZ != 0.0F;
        _isRunning = _isMovePressed && Input.GetButton("Fire3");
        _isJumpPressed = Input.GetButtonDown("Jump");
    }

    bool IsGrounded()
    {
        return _characterController.isGrounded;
    }

    IEnumerator WaitForGroundedCoroutine()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(() => IsGrounded());
        _numberOfJumps = 0;
    }
}
