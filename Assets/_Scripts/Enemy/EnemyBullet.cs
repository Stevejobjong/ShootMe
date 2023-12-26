using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Transform body;
    [SerializeField] private GameObject cam;
    private Rigidbody _rb;
    private float speed = 10f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        TurnOffCam();
    }
    private void Start()
    {
        _rb.AddForce(transform.forward * speed);
    }
    private void Update()
    {
        if(GameManager._instance.CurrentGameState == GameManager.GameState.CLEAR)
        {
            _rb.velocity = Vector3.zero;
        }
        body.Rotate(new Vector3(20f * Time.deltaTime, 0, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            print("게임 오버");
        }
        else
        {
            print("클리어");
            _rb.AddForce(collision.transform.position -  body.position);
        }
    }

    public void TurnOnCam()
    {
        cam.SetActive(true);
    }
    public void TurnOffCam()
    {
        cam.SetActive(false);
    }
}
