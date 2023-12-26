using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Transform body;
    Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * 30f);
    }
    private void Update()
    {
        body.Rotate(new Vector3(20f * Time.deltaTime, 0, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("성공");
    }
}
