using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private ObjectPool _objectPool;
    private void Start()
    {
        _objectPool = GameManager._instance.ObjectPool.GetComponent<ObjectPool>();
    }
    public void ShootBullet(Vector3 startPostiion, Quaternion startRotation)
    {
        GameObject obj = _objectPool.SpawnFromPool("PlayerBullet");
        obj.transform.position = startPostiion;
        obj.transform.rotation = startRotation;
        obj.GetComponent<PlayerBullet>().ResetBullet();
        obj.SetActive(true);
    }
}
    