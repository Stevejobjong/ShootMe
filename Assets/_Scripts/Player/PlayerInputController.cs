using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    #region Fields
    [SerializeField] private Transform _playerSpine;
    [SerializeField] private Transform _muzzle;
    private Transform _playerTransform;
    private float _rotX;
    private float _rotY;
    private float _sensitivity = 10f;
    private float _clampAngle = 70f;

    public LayerMask BulletLayer;
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
    void OnDrawGizmos()
    {

        float maxDistance = 100;
        RaycastHit hit;
        // Physics.Raycast (레이저를 발사할 위치, 발사 방향, 충돌 결과, 최대 거리)
        bool isHit = Physics.Raycast(_muzzle.position, _muzzle.right, out hit, maxDistance, BulletLayer);

        Gizmos.color = Color.red;

        if (isHit)
        {
            Gizmos.DrawRay(_muzzle.position, _muzzle.right * hit.distance);
        }
        else
        {
            Gizmos.DrawRay(_muzzle.position, _muzzle.right * maxDistance);
        }
    }
}
