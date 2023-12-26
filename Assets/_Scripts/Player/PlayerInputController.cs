using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    #region Fields
    [SerializeField] private Transform _playerSpine;
    private Transform _playerTransform;
    private float _rotX;
    private float _rotY;
    private float _sensitivity = 10f;
    private float _clampAngle = 70f;
    #endregion
    private void Awake()
    {
        _playerTransform = gameObject.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();

        _rotX += -newAim.y * _sensitivity * Time.deltaTime;
        _rotY += newAim.x * _sensitivity * Time.deltaTime;

        _rotX = Mathf.Clamp(_rotX, -_clampAngle, _clampAngle);

        _playerTransform.rotation = Quaternion.Euler(0, _rotY, 0);
        _playerSpine.rotation = Quaternion.Euler(_rotX, _rotY, 0);
    }
}
