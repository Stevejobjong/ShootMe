using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private ObjectPool _objectPool;
    private void Start()
    {
        _objectPool = GameManager._instance.ObjectPool.GetComponent<ObjectPool>();
    }
    public void SpawnEnemy()
    {
        GameManager._instance.StatePlay();
        GameObject obj = _objectPool.SpawnFromPool("EnemyBullet"); 
        int angle = Random.Range(0, 360);
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * 5f;
        float z = Mathf.Sin(angle * Mathf.Deg2Rad) * 5f;

        Vector3 pos = transform.position + new Vector3(x, Random.Range(1,5), z);
        obj.transform.position = pos;
        obj.SetActive(true);
    }
}