using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 오브젝트 풀 크기
    public int poolSize = 10;
    // 오브젝트 풀 배열
    public List<GameObject> enemyObjectPool;
    // SpawnPoint 배열
    public Transform[] spawnPoints;

    public List<GameObject> enemyLife3ObjectPool;

    // 현재 시간
    private float currentTime;
    // 일정 시간
    public float createTime = 1f;
    // Enemy 프리팹
    public GameObject enemyFactory;

    // EnemyLife3 프리팹
    public GameObject enemyLife3Factory;

    // 적 생성 시간 간격 최소 시간
    public float minTime = 1f;
    // 적 생성 시간 간격 최대 시간
    public float maxTime = 5f;

    void Start()
    {
        // 처음 적의 생성 시간을 랜덤으로 설정
        createTime = Random.Range(minTime, maxTime);

        // 오브젝트 풀을 에너미들을 담을 수 있는 크기로 만들어 준다.
        enemyObjectPool = new List<GameObject>();
        enemyLife3ObjectPool = new List<GameObject>();

        // 에너미 오브젝트 풀 크기만큼 반복하여
        for (int i = 0; i < poolSize; i++)
        {
            // 에너미 공장에서 에너미를 생성한다.
            GameObject enemy = Instantiate(enemyFactory);
            GameObject enemyLife3 = Instantiate(enemyLife3Factory);
            // 에너미를 오브젝트 풀에 순서대로 넣는다
            enemyObjectPool.Add(enemy);
            enemyLife3ObjectPool.Add(enemyLife3);
            // 비활성화 시킨다.
            enemy.SetActive(false);
            enemyLife3.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 시간이 흐름
        currentTime += Time.deltaTime;

        // 만약 생성 시간이 일정 시간을 초과하면
        if (currentTime > createTime)
        {

            int randomNumber = Random.Range(0, 10);

            if (randomNumber < 2)
            {
                if (enemyLife3ObjectPool.Count > 0)
                {
                    GameObject enemy = enemyLife3ObjectPool[0];
                    enemy.SetActive(true);
                    enemyLife3ObjectPool.Remove(enemy);

                    // 랜덤으로 인덱스 선택
                    int index = Random.Range(0, spawnPoints.Length);
                    // 에너미 위치 시키기
                    enemy.transform.position = spawnPoints[index].position;
                }
            }
            else
            {
                if (enemyObjectPool.Count > 0)
                {
                    GameObject enemy = enemyObjectPool[0];
                    enemy.SetActive(true);
                    enemyObjectPool.Remove(enemy);

                    // 랜덤으로 인덱스 선택
                    int index = Random.Range(0, spawnPoints.Length);
                    // 에너미 위치 시키기
                    enemy.transform.position = spawnPoints[index].position;
                }
            }
            
            // 현재 시간을 0으로 초기화
            currentTime = 0f;

            // 다음 적의 생성 시간을 랜덤으로 설정
            createTime = Random.Range(minTime, maxTime);
        }
    }
}
