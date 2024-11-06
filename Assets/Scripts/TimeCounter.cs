using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Időszámláló
public class TimeCounter : MonoBehaviour
{

    //Idő mutatása UI szöveg
    TextMeshProUGUI timeUI;

    //Kezdeti idő
    float startTime;

    //Játék idő
    float ellapsedTime;

    //Logikai változó: Időszámláló fut-e
    bool startCounter;

    //Eltelt idő percei
    int minutes;

    //Eltelt idő másodpercei
    int seconds;

    //Első frame update előtt van meghívva
    void Start()
    {
        //Inicializálás
        startCounter = false;
        timeUI = GetComponent<TextMeshProUGUI>();
    }

    //Számláló elinditása
    public void StartTimeCounter()
    {   
        startTime = Time.time;
        startCounter = true;
    }

    //Számláló megállítása
    public void StopTimeCounter()
    {
        startCounter = false;
    }


    //Minden frame során megvan hívva
    void Update()
    {
        if(startCounter){

           //Eltelt idő kiszámítása
           ellapsedTime =  Time.time - startTime;

           //Eltelt idő kiírása
           minutes = (int)ellapsedTime / 60;
           seconds = (int)ellapsedTime % 60;
           timeUI.text = string.Format("{0:00}:{1:00}", minutes,seconds);
        }
        
    }
}