//Script criado por Wellington F. Baldo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private string state = "Menu"; //Menu, ComoJogar, Creditos, Volume, Jogar

    //booleanos
    private bool menuRedefinido = false;
    private bool initTrocaCena = false;
    private bool tocandoAudio = false;

    //Time
    private float initTime = 0f;
    private float currentTime = 0f;

    //GameObjects
    private GameObject texto;
    private GameObject buttons;
    private GameObject comoJogar;
    private GameObject volume;
    private GameObject creditos;
    private GameObject blackOut;
    private GameObject zoio;

    //volume do jogo
    private float volumeGeral = 1f;

    //AudioClips
    public AudioClip Interruptor;
    public AudioClip Assovio;

    //AudioSource
    private AudioSource audioSource;

    void Start()
    {
        if(PlayerPrefs.GetString("MenuStatus") != string.Empty)
        {
            state = PlayerPrefs.GetString("MenuStatus");
        }

        PlayerPrefs.DeleteAll();

        //Guardando gameObjects na memória
        texto = gameObject.transform.GetChild(1).gameObject;
        buttons = gameObject.transform.GetChild(2).gameObject;
        comoJogar = gameObject.transform.GetChild(3).gameObject;
        volume = gameObject.transform.GetChild(4).gameObject;
        creditos = gameObject.transform.GetChild(5).gameObject;
        blackOut = gameObject.transform.GetChild(6).gameObject;
        zoio = gameObject.transform.GetChild(7).gameObject;

        //Guardando audioSource na memoria
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        switch (state)
        {
            case "Jogar":
                if (!menuRedefinido)
                {
                    texto.SetActive(false);
                    buttons.SetActive(false);
                    comoJogar.SetActive(false);
                    volume.SetActive(false);
                    creditos.SetActive(false);
                    blackOut.SetActive(true);
                    zoio.SetActive(true);
                    menuRedefinido = true;
                }
                CarregarCena();
                break;

            case "Menu":
                if (!menuRedefinido)
                {
                    texto.SetActive(true);
                    buttons.SetActive(true);
                    comoJogar.SetActive(false);
                    volume.SetActive(false);
                    creditos.SetActive(false);
                    blackOut.SetActive(false);
                    zoio.SetActive(false);
                    menuRedefinido = true;
                }
                break;

            case "ComoJogar":
                if (!menuRedefinido)
                {
                    texto.SetActive(false);
                    buttons.SetActive(false);
                    comoJogar.SetActive(true);
                    volume.SetActive(false);
                    creditos.SetActive(false);
                    blackOut.SetActive(false);
                    zoio.SetActive(false);
                    menuRedefinido = true;
                }
                MenuComoJogar();
                break;

            case "Volume":
                if (!menuRedefinido)
                {
                    texto.SetActive(false);
                    buttons.SetActive(false);
                    comoJogar.SetActive(false);
                    volume.SetActive(true);
                    creditos.SetActive(false);
                    blackOut.SetActive(false);
                    zoio.SetActive(false);
                    menuRedefinido = true;
                }
                break;

            case "Creditos":
                if (!menuRedefinido)
                {
                    texto.SetActive(false);
                    buttons.SetActive(false);
                    comoJogar.SetActive(false);
                    volume.SetActive(false);
                    creditos.SetActive(true);
                    blackOut.SetActive(false);
                    zoio.SetActive(false);
                    menuRedefinido = true;
                }
                MenuCreditos();
                break;
                
            default:
                Debug.Log("Status não definido");
                break;
        }
    }

    public void VoltarMenu()
    {
        state = "Menu";
        menuRedefinido = false;
    }

    public void Jogar()
    {
        audioSource.clip = Interruptor;
        audioSource.volume = volumeGeral;
        audioSource.Play();
        state = "Jogar";
        menuRedefinido = false;
    }

    public void ComoJogar()
    {
        audioSource.clip = Interruptor;
        audioSource.volume = volumeGeral;
        audioSource.Play();
        state = "ComoJogar";
        menuRedefinido = false;
    }

    public void Volume()
    {
        audioSource.clip = Interruptor;
        audioSource.volume = volumeGeral;
        audioSource.Play();
        state = "Volume";
        menuRedefinido = false;
    }

    public void Creditos()
    {
        audioSource.clip = Interruptor;
        audioSource.volume = volumeGeral;
        audioSource.Play();
        state = "Creditos";
        menuRedefinido = false;
    }

    private void CarregarCena()
    {
        if (!initTrocaCena)
        {
            gameObject.GetComponent<AudioSource>().volume = volumeGeral;
            initTrocaCena = true;
            initTime = Time.time;
            zoio.GetComponent<Animator>().SetTrigger("Jogar");
        }

        currentTime = Time.time - initTime;

        if(currentTime > 1f && !tocandoAudio)
        {
            audioSource.clip = Assovio;
            audioSource.volume = volumeGeral;
            audioSource.Play();
            tocandoAudio = true;
        }else if (currentTime > 6f)
        {
            PlayerPrefs.SetFloat("Volume", volumeGeral);
            SceneManager.LoadScene(1);
        }
    }

    private void MenuComoJogar()
    {
        if (Input.anyKeyDown)
        {
            state = "Menu";
            menuRedefinido = false;
        }
    }

    private void MenuCreditos()
    {
        if (Input.anyKeyDown)
        {
            state = "Menu";
            menuRedefinido = false;
        }
    }

    public void setVolume(float valor)
    {
        valor = valor / 100f;
        volumeGeral = valor;
    }
}