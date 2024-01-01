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
            CalTargetPos(); // ��ǥ ��ġ ���
        }
        MoveToTarget(); // ��ǥ ��ġ�� �̵�
        FlipSprite(); // ��������Ʈ ������
    }
    private void CalTargetPos()
    {
        mousePos = Input.mousePosition; // ���콺 ��ġ ��������
        transPos = Camera.main.ScreenToWorldPoint(mousePos); // ���콺 ��ġ�� ���� ����Ʈ�� ��ȯ
        targetPos = new Vector3(transPos.x, transPos.y, 0); // z ��ǥ�� 0���� ����
    }
    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);  // ��ǥ ��ġ�� �̵�
    }
    private void FlipSprite()
    {
        // ���� �̵��� �߿����� Ȯ��
        if (Mathf.Abs(targetPos.x - transform.position.x) > 0.01f)
        {
            // ��������Ʈ�� x���� �������� ������
            transform.localScale = new Vector3(-Mathf.Sign(targetPos.x - transform.position.x), 1f, 1f);
        }
    }
}
