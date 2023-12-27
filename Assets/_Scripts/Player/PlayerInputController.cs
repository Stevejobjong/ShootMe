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

    private EnemyBullet _currentTarget;
    private PlayerInput _playerInput;
    private Transform _playerTransform;
    private float _rotX;
    private float _rotY;
    private float _sensitivity = 10f;
    private float _clampAngle = 70f;

    public LayerMask BulletLayer;
    private bool _isHit;
    #endregion

    #region MonoBehaviours
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerTransform = gameObject.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (_currentTarget == null || _currentTarget.gameObject.activeSelf == false)
            ScanNearBy();

        if (!_playerInput.isActiveAndEnabled && GameManager._instance.CurrentGameState == GameState.PLAY)
            _playerInput.enabled = true;

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
        if (_isHit)
        {
            _playerInput.enabled = false;
            GameManager._instance.StateHit();
            _currentTarget.ResetBullet();
        }

        GameManager._instance.ShootBullet(_muzzle.position, _muzzle.rotation);
    }

    private void ScanNearBy()
    {
        float closestDistance = 10f;
        Transform closestTarget = null;
        Collider[] nearbyTargets = Physics.OverlapSphere(transform.position, 5f, BulletLayer);

        if (nearbyTargets.Length <= 0) return;

        for (int i = 0; i < nearbyTargets.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, nearbyTargets[i].transform.position);

            if (distance < closestDistance)
            {
                closestTarget = nearbyTargets[i].transform;
                closestDistance = distance;
            }
        }
        _currentTarget = closestTarget.GetComponent<EnemyBullet>();
        _currentTarget.TurnOnCam();
    }

    void OnDrawGizmos()
    {

        Gizmos.DrawWireSphere(transform.position, 5f);

        float maxDistance = 100;
        RaycastHit hit;
        _isHit = Physics.SphereCast(_muzzle.position, 0.02f, _muzzle.forward, out hit, maxDistance, BulletLayer);

        Gizmos.color = Color.red;

        if (_isHit)
        {
            Gizmos.DrawRay(_muzzle.position, _muzzle.forward * hit.distance);
            Gizmos.DrawWireSphere(_muzzle.position + _muzzle.forward * hit.distance, 0.02f);
        }
        else
        {
            Gizmos.DrawRay(_muzzle.position, _muzzle.forward * maxDistance);
        }
    }
    public Vector3 GetTargetPos()
    {
        return _currentTarget.transform.position;
    }
}
