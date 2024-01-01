using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Vector3 mousePos, transPos, targetPos;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CalTargetPos(); // 목표 위치 계산
        }
        MoveToTarget(); // 목표 위치로 이동
        FlipSprite(); // 스프라이트 뒤집기
    }
    private void CalTargetPos()
    {
        mousePos = Input.mousePosition; // 마우스 위치 가져오기
        transPos = Camera.main.ScreenToWorldPoint(mousePos); // 마우스 위치를 월드 포인트로 변환
        targetPos = new Vector3(transPos.x, transPos.y, 0); // z 좌표는 0으로 설정
    }
    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);  // 목표 위치로 이동
    }
    private void FlipSprite()
    {
        // 수평 이동이 중요한지 확인
        if (Mathf.Abs(targetPos.x - transform.position.x) > 0.01f)
        {
            // 스프라이트를 x축을 기준으로 뒤집기
            transform.localScale = new Vector3(-Mathf.Sign(targetPos.x - transform.position.x), 1f, 1f);
        }
    }
}
