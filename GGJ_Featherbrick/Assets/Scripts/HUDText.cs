using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HUDText : MonoBehaviour
{
    public Text score1, score2, score3, score4;
    public Text timer;
    private float _timer;
    public Text EndText;

    // Start is called before the first frame update
    void Start()
    {
        EndText.gameObject.SetActive(false);

        UpdateText();

        UpdateText();
        _timer = 60.0f;
        timer.text = _timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        UpdateTimer();
    }

    void UpdateText()
    {
        score1.text = "Player 1 Points: " + GLOBAL_.player1Score;
        score2.text = "Player 2 Points: " + GLOBAL_.player2Score;
        score3.text = "Player 3 Points: " + GLOBAL_.player3Score;
        score4.text = "Player 4 Points: " + GLOBAL_.player4Score;
    }

    void UpdateTimer()
    {

         _timer -= Time.deltaTime;
        timer.text = _timer.ToString("f1");


        if(_timer <= 0.0f)
        {
            EndText.gameObject.SetActive(true);
            int x = Mathf.Max(GLOBAL_.player1Score, GLOBAL_.player2Score, GLOBAL_.player3Score, GLOBAL_.player4Score);

            if (GLOBAL_.player1Score == x)
            {
                EndText.text = "Well Done Player 1! You win!";
            }
            else if (GLOBAL_.player2Score == x)
            {

                EndText.text = "Well Done Player 2! You win!";
            }
            else if (GLOBAL_.player3Score == x)
            {

                EndText.text = "Well Done Player 3! You win!";
            }
            else if (GLOBAL_.player4Score == x)
            {

                EndText.text = "Well Done Player 4! You win!";
            }

            if (_timer <= -5.0f)
            {
                SceneManager.LoadScene("Assets/Scenes/MainMenus.unity");
            }
        }

    }
}
