using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 총알 이동 방향
        Vector3 dir = Vector3.up;

        // 총알 이동 구현
        transform.position += dir * speed * Time.deltaTime;
    }
}
