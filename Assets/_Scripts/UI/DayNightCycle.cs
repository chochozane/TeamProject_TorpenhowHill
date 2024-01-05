using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering; // Volume ������Ʈ ������ ���� �ʿ�

public class DayNightCycle : MonoBehaviour
{
    private Volume postprocessingVolume;

    private float tick = 3000f; // tick ���� �ø��� second �� rate �� �����Ѵ�. -- 5000 �ʹ����� , �׽�Ʈ�� 1500 �� ����.
    private float seconds;
    private int mins;
    private int hours;
    private int days = 1;

    private bool isActiveLights; // ��(light)�� �����ִ���
    [SerializeField] private GameObject[] lights; // ����� lights �� (��������� �� ģ����)

    // CLOCK
    [SerializeField] private Transform clockHandTransform;

    void Start()
    {
        postprocessingVolume = GetComponent<Volume>();
    }


    private void FixedUpdate() // Update �Լ��� frame dependant �̱⿡, FixedUpdate Ȱ��
    {
        if (UIManager.isGamePaused)
        {
            UIManager.instance.PauseTime();
        }

        CalculateTime();
        DisplayClock();
    }

    private void CalculateTime() // �ð���� �Լ�
    {
        seconds += Time.fixedDeltaTime * tick; // ��(sec)���� tick �� ���ϱ� �̷����. -- tick ���� �������� second �� ����ϰ���

        if (seconds >= 60f) // 60�� = 1��
        {
            seconds = 0f;
            mins += 1;
        }

        if (mins >= 60) // 60�� = 1�ð�
        {
            mins = 0;
            hours += 1;
        }

        if (hours >= 24) // 24�ð� = 1��
        {
            hours = 0;
            days += 1;
        }

        ControlPPValue(); // �ð���� �� Postprocessing Value ����
    }

    private void ControlPPValue() // Postprocessing Value �� ����
    {
        /*
         * �ð����� : 0�� ~ 24��
         * 23�� ~ 24(=0)�� : �� ���.
         * 0�� ~ 20�� : �� ���ִ� �ð�
         * 
         * 20�� ~ 21�� : �� ����.
         * 21�� ~ 23�� : �������
         */

        // weight �� 0 ���� ����.

        if (hours >= 20 && hours < 21) // 20�� ~ 21�� - ��ο�����
        {
            postprocessingVolume.weight = (float)mins / 60; // ��ο����� �ð��� 1�ð��̱⿡, mins �� 60 ���� ���� (Volume weight) value ���� 0 ���� 1 �� õõ�� �ٲ�Բ� ����.

            if (isActiveLights == false) // ��(light) �� �� �����ٸ�
            {
                if (mins > 45) // wait until pretty dark
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true); // ���� Ű�� !
                    }
                    isActiveLights = true;
                }
            }
        }

        if (hours >= 23 && hours < 24) // 23�� ~ 24�� - �������
        {
            postprocessingVolume.weight = 1 - (float)mins / 60; // 1 to 0 �� �Ǳ� ���� 1 �� ���̳ʽ� �Ѵ�.

            if (isActiveLights == true) // ��(light) �� �����ִٸ�
            {
                if (mins > 45) // wait until pretty bright
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false); // �� �� !!!
                    }
                    isActiveLights = false;
                }
            }
        }
    }

    private void DisplayClock()
    {
        clockHandTransform.eulerAngles = new Vector3(0, 0, -hours * 15f); // �ð�������� �Ϸ��� z�� ȸ���� - �� ���ƾ��Ѵ�. ( 360(�ѹ�������) ������ 24(�ð�) �� 15. )
    }

    //public void DisplayTime() // Shows time and day in ui
    //{

    //    timeDisplay.text = string.Format("{0:00}:{1:00}", hours, mins); // The formatting ensures that there will always be 0's in empty spaces
    //    dayDisplay.text = "Day: " + days; // display day counter
    //}
}
