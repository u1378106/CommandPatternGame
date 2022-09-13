using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InteractionManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject howToPlay;

    private void Start()
    {
        this.GetComponent<Animator>().enabled = false;
        howToPlay.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Animator>().enabled = true;
        this.GetComponent<Animator>().Play("ButtonZoom");
        this.GetComponent<Animator>().speed = 1;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Animator>().Play("ButtonZoomOut");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenHowToPlay()
    {
        howToPlay.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        howToPlay.SetActive(false);
    }
}