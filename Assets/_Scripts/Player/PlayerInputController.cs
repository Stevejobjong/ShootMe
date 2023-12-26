using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    #region Fields
    [SerializeField] private Transform _playerSpine;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private GameObject _bullet;

    private Transform _playerTransform;
    private float _rotX;
    private float _rotY;
    private float _sensitivity = 10f;
    private float _clampAngle = 70f;
    private float bulletSpeed = 50f;

    public LayerMask BulletLayer;
    private bool _isHit;
    #endregion

    #region MonoBehaviours
    private void Awake()
    {
        _playerTransform = gameObject.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion

    //마우스 이동시 호출되는 함수
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();

        _rotX += -newAim.y * _sensitivity * Time.deltaTime;
        _rotY += newAim.x * _sensitivity * Time.deltaTime;

        _rotX = Mathf.Clamp(_rotX, -_clampAngle, _clampAngle);

        _playerTransform.rotation = Quaternion.Euler(0, _rotY, 0);
        _playerSpine.rotation = Quaternion.Euler(_rotX, _rotY, 0);
    }

    public void OnFire(InputValue value)
    {
        BulletManager._instance.ShootBullet(_muzzle.position, _muzzle.rotation, bulletSpeed);
    }

    void OnDrawGizmos()
    {

        float maxDistance = 100;
        RaycastHit hit;
        _isHit = Physics.Raycast(_muzzle.position, _muzzle.forward, out hit, maxDistance, BulletLayer);

        Gizmos.color = Color.red;

        if (_isHit)
        {
            Gizmos.DrawRay(_muzzle.position, _muzzle.forward * hit.distance);
        }
        else
        {
            Gizmos.DrawRay(_muzzle.position, _muzzle.forward * maxDistance);
        }
    }
}
