using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefabs;     //동전 프리팹을 선언한다.
    public GameObject MissilePrefabs;  //미사일 프리팹을 선언한다.

    [Header("스폰 타이밍 설정")]         
    public float minSpawnInterval = 0.5f; //최소 생성 간격(초)
    public float maxSpawnInterval = 2.0f;   //최대 생성 간격(초)

    [Header("동전 확률 스폰 설정")]
    [Range(0, 100)]
    public int coinSpawnChance = 50;         //50% 확률로 동전이 생성된다.

    public float timer = 0.0f;             //타이머
    public float nextSpawnTime;            //다음 생성 시간

    // Start is called before the first frame update
    void Start()
    {
        SetNextSpawnTime();         //함수 호출
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;            //시간이 0에서 점점 증가한다

        if(timer >= nextSpawnTime)         //생성 시간이 되면 오브젝트를 생성한다.
        {
            SpawnObject();
            timer = 0.0f;                  //시간을 초기화 시켜준다.
            SetNextSpawnTime();            //다시 함수 호출
        }
    }
   void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);    //최소-최대 사이의 랜덤한 시간 설정
    }

    void SpawnObject()
    {   
        Transform spawnTransform = transform;                    //스포너 오브젝트의 위치와 회전값을 가져온다 (지역 변수)

        //확률에 따라 동전 또는 미사일 생성
        int randomValue = Random.Range(0, 100);
        if(randomValue < coinSpawnChance)
        {
            Instantiate(coinPrefabs, spawnTransform.position, spawnTransform.rotation);
        }
        else
        {
            Instantiate(MissilePrefabs, spawnTransform.position, spawnTransform.rotation);
        }
        
    }
}
