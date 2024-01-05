using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering; // Volume 컴포넌트 접근을 위해 필요

public class DayNightCycle : MonoBehaviour
{
    private Volume postprocessingVolume;

    private float tick = 3000f; // tick 값을 올리면 second 의 rate 도 증가한다. -- 5000 너무빨라 , 테스트로 1500 이 적당.
    private float seconds;
    private int mins;
    private int hours;
    private int days = 1;

    private bool isActiveLights; // 불(light)이 켜져있는지
    [SerializeField] private GameObject[] lights; // 사용할 lights 들 (껐다켜줬다 할 친구들)

    // CLOCK
    [SerializeField] private Transform clockHandTransform;

    void Start()
    {
        postprocessingVolume = GetComponent<Volume>();
    }


    private void FixedUpdate() // Update 함수는 frame dependant 이기에, FixedUpdate 활용
    {
        if (UIManager.isGamePaused)
        {
            UIManager.instance.PauseTime();
        }

        CalculateTime();
        DisplayClock();
    }

    private void CalculateTime() // 시간계산 함수
    {
        seconds += Time.fixedDeltaTime * tick; // 초(sec)에서 tick 값 곱하기 이루어짐. -- tick 값이 높아지면 second 도 비례하겠죠

        if (seconds >= 60f) // 60초 = 1분
        {
            seconds = 0f;
            mins += 1;
        }

        if (mins >= 60) // 60분 = 1시간
        {
            mins = 0;
            hours += 1;
        }

        if (hours >= 24) // 24시간 = 1일
        {
            hours = 0;
            days += 1;
        }

        ControlPPValue(); // 시간계산 후 Postprocessing Value 변경
    }

    private void ControlPPValue() // Postprocessing Value 값 조절
    {
        /*
         * 시간개념 : 0시 ~ 24시
         * 23시 ~ 24(=0)시 : 해 뜬다.
         * 0시 ~ 20시 : 해 떠있는 시간
         * 
         * 20시 ~ 21시 : 해 진다.
         * 21시 ~ 23시 : 어두컴컴
         */

        // weight 은 0 에서 시작.

        if (hours >= 20 && hours < 21) // 20시 ~ 21시 - 어두워진다
        {
            postprocessingVolume.weight = (float)mins / 60; // 어두워지는 시간이 1시간이기에, mins 을 60 으로 나눠 (Volume weight) value 값이 0 에서 1 로 천천히 바뀌게끔 설정.

            if (isActiveLights == false) // 불(light) 이 안 켜졌다면
            {
                if (mins > 45) // wait until pretty dark
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true); // 불을 키자 !
                    }
                    isActiveLights = true;
                }
            }
        }

        if (hours >= 23 && hours < 24) // 23시 ~ 24시 - 밝아진다
        {
            postprocessingVolume.weight = 1 - (float)mins / 60; // 1 to 0 가 되기 위해 1 을 마이너스 한다.

            if (isActiveLights == true) // 불(light) 이 켜져있다면
            {
                if (mins > 45) // wait until pretty bright
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false); // 불 꺼 !!!
                    }
                    isActiveLights = false;
                }
            }
        }
    }

    private void DisplayClock()
    {
        clockHandTransform.eulerAngles = new Vector3(0, 0, -hours * 15f); // 시계방향으로 하려면 z축 회전이 - 로 돌아야한다. ( 360(한바퀴각도) 나누기 24(시간) 는 15. )
    }

    //public void DisplayTime() // Shows time and day in ui
    //{

    //    timeDisplay.text = string.Format("{0:00}:{1:00}", hours, mins); // The formatting ensures that there will always be 0's in empty spaces
    //    dayDisplay.text = "Day: " + days; // display day counter
    //}
}
