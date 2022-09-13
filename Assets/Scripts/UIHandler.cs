using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject playerWeapon, cpuWeapon, timerText, infoPanel, undoButton, resultPanel, undoTimerPanel;

    [SerializeField]
    private TextMeshProUGUI resultDeclareText;

    [SerializeField]
    private Image playerImg, cpuWeaponImg;

    public string infoText = "";

    private Animator playerWeaponAnim;
    private Animator cpuWeaponAnim;

    AIHandler aIHandler;
    AudioManager audioManager;

    private static bool isFirstPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        aIHandler = GameObject.FindObjectOfType<AIHandler>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();

        playerWeaponAnim = playerWeapon.GetComponent<Animator>();
        playerWeaponAnim.enabled = false;

        cpuWeaponAnim = cpuWeapon.GetComponent<Animator>();
        cpuWeaponAnim.enabled = false;

        playerWeapon.SetActive(false);
        cpuWeapon.SetActive(false);
        timerText.SetActive(false);
        undoTimerPanel.SetActive(false);
       
        resultPanel.SetActive(false);

        StartCoroutine(AnimateCam());
    }

    IEnumerator AnimateCam()
    {
        Camera.main.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(6f);
        Camera.main.GetComponent<Animator>().enabled = false;
        infoPanel.SetActive(true);

    }

    public void StartBattle(string objectName)
    {
        infoPanel.SetActive(false);
        StartCoroutine(Shuffle(objectName));
    }

    IEnumerator Shuffle(string objectName)
    {
        undoTimerPanel.SetActive(true);
        timerText.SetActive(true);
        undoButton.SetActive(true);
        yield return new WaitForSeconds(3f);

        objectName = RPSCommand.buttonNames[0];
        undoTimerPanel.SetActive(false);
        playerWeapon.SetActive(true);
        playerWeapon.GetComponent<Image>().sprite = Resources.Load<Sprite>(objectName) as Sprite;
        playerWeaponAnim.enabled = true;

        cpuWeapon.SetActive(true);
        cpuWeaponAnim.enabled = true;
        aIHandler.InitializeEnemyAI();

        timerText.SetActive(false);
        undoButton.SetActive(false);

        yield return new WaitForSeconds(2f);

        resultPanel.SetActive(true);
        ShowResult(objectName);

    }

    public void ShowResult(string playerWeapon)
    {
        switch (aIHandler.objectName)
        {
            case "Rock":
                switch (playerWeapon)
                {
                    case "Rock":
                        resultDeclareText.text = "Tie!";
                        break;

                    case "Paper":
                        resultDeclareText.text = "The paper covers the rock, you win!";
                        break;

                    case "Scissor":
                        resultDeclareText.text = "The rock destroys the scissors, you lose!";
                        break;

                }

                playerImg.sprite = Resources.Load<Sprite>(playerWeapon) as Sprite;
                cpuWeaponImg.sprite = Resources.Load<Sprite>(aIHandler.objectName) as Sprite;

                break;

            case "Paper":
                switch (playerWeapon)
                {
                    case "Rock":
                        resultDeclareText.text = "The paper covers the rock, you lose!";
                        break;

                    case "Paper":
                        resultDeclareText.text = "Tie!";
                        break;

                    case "Scissor":
                        resultDeclareText.text = "The scissors cuts the paper, you win!";
                        break;

                }

                playerImg.sprite = Resources.Load<Sprite>(playerWeapon) as Sprite;
                cpuWeaponImg.sprite = Resources.Load<Sprite>(aIHandler.objectName) as Sprite;

                break;

            case "Scissor":
                switch (playerWeapon)
                {
                    case "Rock":
                        resultDeclareText.text = "The rock destroys the scissors, you win!";
                        break;

                    case "Paper":
                        resultDeclareText.text = "The scissors cuts the paper, you win!";
                        break;

                    case "Scissor":
                        resultDeclareText.text = "Tie!";
                        break;

                }

                playerImg.sprite = Resources.Load<Sprite>(playerWeapon) as Sprite;
                cpuWeaponImg.sprite = Resources.Load<Sprite>(aIHandler.objectName) as Sprite;

                break;
        }
    }

    public void RestartGame()
    {
        audioManager.PlayMouseClickSound();
        RPSCommand.priorityCounter = 0;
        RPSCommand.buttonNames.Clear();
        SceneManager.LoadScene(1);
    }
}
