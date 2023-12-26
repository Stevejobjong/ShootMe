using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager _instance;
    private ObjectPool _objectPool;
    private void Awake()
    {
        _instance = this;
        _objectPool = GetComponent<ObjectPool>();
    }
    public void ShootBullet(Vector3 startPostiion, Quaternion startRotation,float speed)
    {
        GameObject obj = _objectPool.SpawnFromPool("PlayerBullet");
        obj.transform.position = startPostiion;
        obj.transform.rotation = startRotation;
        obj.GetComponent<PlayerBulletController>().ResetBullet(speed);
        obj.SetActive(true);
    }
}
    