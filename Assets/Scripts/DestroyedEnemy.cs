using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//Elpusztított ellenségek számolása
public class DestroyedEnemy : MonoBehaviour
{
    //Játék kezelő
    public GameObject GameManagerGO;

    //Játékos
    public GameObject Player;

    //Kiiktatást számláló UI szöveg
    TextMeshProUGUI killsTextUI;

    int kills; //Kiiktatásokat számláló
    public int Kills
    {

        get
        {
            return this.kills;
        }
        set
        {
            this.kills = value;
            UpdateScoreTextUI();
        }

    }

    //Első frame update előtt van meghívva
    void Start()
    {
        //Kiiktatás számlálót UI szöveg inicializálása
        killsTextUI = GetComponent<TextMeshProUGUI>();
    }

    //Kiiktatásokat számláló UI frissítése
    void UpdateScoreTextUI()
    {

        //UI frissítés
        string killsStr = string.Format("{0:0}", kills);
        killsTextUI.text = killsStr;

        //A az első és harmadik pályánál nézi meg, hogy mi a küldetés
        if ((GameManagerGO.GetComponent<GameManager>().level == 1) || (GameManagerGO.GetComponent<GameManager>().level == 3))
        {
            GameManagerGO.GetComponent<GameManager>().Missions();
            //UnlockNewLevel();
        }
    }

    //Új szint feloldása és feloldott szintek elmentése
    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnclokedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }



}