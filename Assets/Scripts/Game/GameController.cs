//Script criado por Wellington F. Baldo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Coleta de dados
    private float volume;

    //Faixas de Audio
    public AudioClip coracao;

    //AudioSource
    private AudioSource audioSource;

    //AudioClip
    public AudioClip assovio;

    //GameObjects
    private GameObject blackout;
    private GameObject zoio;

    //boolean
    private bool initEndGame = false;

    //time
    private float currentTime = 0f;
    private float initTime;

    
    void Start()
    {
        //Passando Configurações de audio
        volume = PlayerPrefs.GetFloat("Volume");
        Message.lightPoints = 7;

        //Adicionando Audio Source a memoria
        audioSource = GetComponent<AudioSource>();
        blackout = GameObject.Find("blackout");
        zoio = GameObject.Find("zoio");
        blackout.SetActive(false);
        zoio.SetActive(false);
    }
    
    void Update()
    {

        if (initEndGame)
        {
            currentTime = Time.time - initTime;
            if(currentTime > 5f)
            {
                EndGame();
            }
        }
    }

    public void EndGame()
    {
        PlayerPrefs.SetString("MenuStatus", "Creditos");
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        audioSource.clip = assovio;
        audioSource.volume = volume;
        blackout.SetActive(true);
        zoio.SetActive(true);
        zoio.GetComponent<Animator>().SetTrigger("Jogar");
        initEndGame = true;
        Message.lightPoints = 7;
        initTime = Time.time;
    }
}
