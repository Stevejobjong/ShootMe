# ShootMe 
## Chapter 3-3 Unity 게임개발 심화 개인과제 (임종운)

</br>

> Unity 3D 슈팅게임입니다.
> 플레이어를 향해 날아오는 거대한 탄환을 탄환으로 막는 게임입니다. 플레이어의 시점이 아니라서 조작이 어려울 수 있습니다.
> 개발 기간은 4일(2023.12.26~2023.12.29)입니다.

</br>

## 게임 시작 화면
* 게임 시작과 게임 종료
  
![GIF 2023-12-29 금요일 오전 9-59-12](https://github.com/Stevejobjong/ShootMe/assets/58843907/4980cf83-6b17-403c-8369-5c410abef7cf)

총으로 표지판을 맞추면 게임이 시작됩니다.

## 게임 화면
* EnemyBullet, PlayerBullet 오브젝트풀링

![image](https://github.com/Stevejobjong/ShootMe/assets/58843907/e82589d1-ebd5-4d64-b382-e03f78382dbe) ![image](https://github.com/Stevejobjong/ShootMe/assets/58843907/c3d076a1-225b-4260-9f5e-0eff26cf0cb4)

</br>


* EnemyBullet 랜덤 위치 생성

플레이어의 마우스 상하 조작의 각도가 제한되어 있어서 EnemyBullet의 랜덤 생성 위치의 y값은 일정한 범위를 정했습니다.
```
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
```

</br>


* 슬로우 모션 연출


![image](https://github.com/Stevejobjong/ShootMe/assets/58843907/f3f65d04-990e-4869-b724-b906c131edb9)

![GIF 2023-12-29 금요일 오전 10-36-44](https://github.com/Stevejobjong/ShootMe/assets/58843907/f8757abb-acf0-4fe2-86ca-575e72952395)

SphereCast를 활용하여 Ray가 EnemyBullet에 hit하는 중에 탄환을 쏘면 탄환의 속도를 낮춰 슬로우 모션 효과를 줬습니다.

</br>


* 스코어

![GIF 2023-12-29 금요일 오전 10-46-32](https://github.com/Stevejobjong/ShootMe/assets/58843907/32bd0bf3-1e94-469b-9b61-9b4727709aa2)

총을 일단 쏘면 10점이 깎입니다. 0점 미만으로는 내려가지 않습니다. 빗맞으면(슬로우 모션이 발동되지 않을 경우) 그냥 100점을 획득하고 슬로우 모션이 발동되면 100점을 추가로 획득합니다.

</br>


* 죽음

![GIF 2023-12-29 금요일 오전 10-54-07](https://github.com/Stevejobjong/ShootMe/assets/58843907/332ecff2-a344-400e-b060-31d1fc67fca3)

캐릭터를 EnemyBullet의 방향으로 회전 시킨 뒤 애니메이션을 실행시켰습니다. Playerprefs를 활용하여 최고 점수와 현재 점수를 표시했습니다.

