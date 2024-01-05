using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.Rendering; // used to access the volume component

public class DayNightCycle : MonoBehaviour
{
    private Volume postprocessingVolume;

    private float tick = 1500f; // Increasing the tick, increases second rate -- 5000 너무빨라
    private float seconds;
    private int mins;
    private int hours;
    private int days = 1;

    //private bool isActiveLights; // checks if lights are on
    //private GameObject[] lights; // all the lights we want on when its dark
    //private SpriteRenderer[] stars; // star sprites

    // Start is called before the first frame update
    void Start()
    {
        postprocessingVolume = GetComponent<Volume>();
    }

    //private void Update()
    //{
    //    CalculateTime();
    //}

    private void FixedUpdate() // Update 함수는 frame dependant 이기에, FixedUpdate 사용
    {
        CalculateTime();
        //DisplayClock();
    }

    private void CalculateTime() // used to calculate sec, min, hours
    {
        seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick
        //seconds += Time.deltaTime * tick; // for update()

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

    private void ControlPPValue() // used to adjust the post processing slider
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

        if (hours >= 20 && hours < 21) // dusk at 9pm - until 10pm
        {
            postprocessingVolume.weight = (float)mins / 60; // since dusk is 1 hr, we just divide the mins by 60 which will slowly increase from 0 to 1

            //if (isActiveLights == false) // if lights havent been turned on
            //{
            //    if (mins > 45) // wait until pretty dark
            //    {
            //        for (int i = 0; i < lights.Length; i++)
            //        {
            //            lights[i].SetActive(true); // turn the lights on
            //        }
            //        isActiveLights = true;
            //    }
            //}
        }

        if (hours >= 23 && hours < 24) // Dawn at 4am - until 5am
        {
            postprocessingVolume.weight = 1 - (float)mins / 60; // 1 to 0 가 되기 위해 1 을 마이너스 한다.

            //if (isActiveLights == true)
            //{
            //    if (mins > 45) // wait until pretty bright
            //    {
            //        for (int i = 0; i < lights.Length; i++)
            //        {
            //            lights[i].SetActive(false);
            //        }
            //        isActiveLights = false;
            //    }
            //}
        }
    }

    private void DisplayClock()
    {
        throw new NotImplementedException();
    }
}
