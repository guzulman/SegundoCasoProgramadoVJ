using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    MouseSensitivity mouseSensitivity;

    [SerializeField]
    CameraAngle cameraAngle;

    float _distanceToTarget;

    Vector2 _input;

    CameraRotation _cameraRotation;

    private void Awake()
    {
        _distanceToTarget = Vector3.Distance(transform.position, target.position);
    }

    private void Update()
    {
        HandleInputs();
        HandleRotation();
    }

    private void LateUpdate()
    {
        transform.eulerAngles = new Vector3(_cameraRotation.pitch, _cameraRotation.yaw, 0.0f);

        transform.position = target.position - transform.forward * _distanceToTarget;
    }

    private void HandleInputs()
    {
        if (Input.GetMouseButton(0))
        {

            _input = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            return;
        }

        _input = Vector2.zero;
    }

    private void HandleRotation()
    {
        _cameraRotation.yaw += 
            _input.x * mouseSensitivity.horizontal * Helper.BoolToInt(mouseSensitivity.invertHorizontal) * Time.deltaTime;
        _cameraRotation.pitch += 
            _input.y * mouseSensitivity.vertical * Helper.BoolToInt(mouseSensitivity.invertVertical) * Time.deltaTime;
        _cameraRotation.pitch = Mathf.Clamp(_cameraRotation.pitch, cameraAngle.min, cameraAngle.max);
    }
}
