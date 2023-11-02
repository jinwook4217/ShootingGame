using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // 배경 매터리얼
    public Material backgroundMaterial;

    // 스크롤 속도
    public float scrollSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 스크롤 방향 설정
        Vector2 dir = Vector2.up;

        // 배경 스크롤
        backgroundMaterial.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
    }
}
