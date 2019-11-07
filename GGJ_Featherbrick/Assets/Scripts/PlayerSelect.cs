using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerSelect : MonoBehaviour
{

    const float COOLDOWN_TIME = 0.3f;

    class Player
    {
        public bool is_active = false;
        public int selected_character_id = 0;
        public bool is_character_selected = false;
        public Image characterImageHolder;
        public Text pressAText;
        public float cool_down_time = 0;
    }

    Player[] players = new Player[4] { new Player(), new Player() , new Player() , new Player()};


    public GameObject[] Player_Pointers;
    public GameObject[] Player_Press_A;

    public List<Sprite> Character_Art;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            players[i].characterImageHolder = Player_Pointers[i].GetComponent<Image>();
            players[i].pressAText = Player_Press_A[i].GetComponent<Text>();
        }
    }

    
    List<int> takenCharacters = new List<int>();



    // Update is called once per frame


    void TalkToGlobalVars()
    {
        GLOBAL_.player1Score = 0;
        GLOBAL_.player2Score = 0;
        GLOBAL_.player3Score = 0;
        GLOBAL_.player4Score = 0;

        GLOBAL_.is_player_1_active = false;
        GLOBAL_.is_player_2_active = false;
        GLOBAL_.is_player_3_active = false;
        GLOBAL_.is_player_4_active = false;

        if (players[0].is_character_selected)
        {
            GLOBAL_.is_player_1_active = true;
            GLOBAL_.player_1_selected_character = players[0].selected_character_id;
        }
        if (players[1].is_character_selected)
        {
            GLOBAL_.is_player_2_active = true;
            GLOBAL_.player_2_selected_character = players[1].selected_character_id;
        }
        if (players[2].is_character_selected)
        {
            GLOBAL_.is_player_3_active = true;
            GLOBAL_.player_3_selected_character = players[2].selected_character_id;
        }
        if (players[3].is_character_selected)
        {
            GLOBAL_.is_player_4_active = true;
            GLOBAL_.player_4_selected_character = players[3].selected_character_id;
        }
    }


    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (players[i].is_character_selected)
            {
                if (Input.GetButtonDown("Player" + (i + 1) + "B"))
                {
                    players[i].characterImageHolder.color = new Color(1, 1, 1, 1);

                    players[i].is_character_selected = false;
                    takenCharacters.Remove(players[i].selected_character_id);
                    players[i].pressAText.text = " ";
                }
                else if (Input.GetButtonDown("Player" + (i + 1) + "Start"))
                {
                    TalkToGlobalVars();
                    SceneManager.LoadScene("Assets/Scenes/Level1.unity", LoadSceneMode.Single);
                }
            }
            else if (players[i].is_active)
            {

                if (takenCharacters.Contains(players[i].selected_character_id))
                {
                    players[i].characterImageHolder.color = new Color(0.0f, 0.0f, 0.0f, 1);
                }
                else
                {
                    players[i].characterImageHolder.color = new Color(1.0f, 1.0f, 1.0f, 1);
                }
                if (Input.GetAxis("Player"+ (i + 1) + "LH") > 0.3)
                {
                    if (players[i].cool_down_time > 0)
                    {
                        players[i].cool_down_time -= Time.deltaTime;                     
                    }
                    else 
                    {
                        players[i].cool_down_time = COOLDOWN_TIME;
                        players[i].selected_character_id++;
                       if (players[i].selected_character_id > (Character_Art.Count - 1))
                        {
                            players[i].selected_character_id = 0;
                        }
                        players[i].characterImageHolder.sprite = Character_Art[players[i].selected_character_id];
                        
                    }


                }
                else if (Input.GetAxis("Player" + (i + 1) + "LH") < -0.3)
                {
                    if (players[i].cool_down_time > 0)
                    {
                        players[i].cool_down_time -= Time.deltaTime;
                       
                    }
                    else
                    {
                        players[i].cool_down_time = COOLDOWN_TIME;
                        players[i].selected_character_id--;
                        if (players[i].selected_character_id < 0)
                        {
                            players[i].selected_character_id = (Character_Art.Count - 1);
                        }
                        players[i].characterImageHolder.sprite = Character_Art[players[i].selected_character_id];


                    }
                }
                else
                {
                    players[i].cool_down_time = 0;
                }

                if (Input.GetButtonDown("Player" + (i + 1) + "B"))
                {

                    players[i].characterImageHolder.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    players[i].pressAText.text = "Press 'A' to Join!";
                    players[i].is_active = false;

                }
                else if (Input.GetButtonDown("Player" + (i + 1) + "A"))
                {
                    if (!takenCharacters.Contains(players[i].selected_character_id))
                    {
                        takenCharacters.Add(players[i].selected_character_id);
                        players[i].is_character_selected = true;
                        players[i].pressAText.text = "Ready!";
                    }
                }
            }
            else
            {
                if (Input.GetButtonDown("Player" + (i + 1) + "A"))
                {
                    players[i].characterImageHolder.sprite = Character_Art[players[i].selected_character_id];
                    players[i].characterImageHolder.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    players[i].pressAText.text = " ";
                    players[i].is_active = true;
                }
                else if (Input.GetButtonDown("Player" + (i + 1) + "B"))
                {
                    SceneManager.LoadScene("Assets/Scenes/MainMenus.unity", LoadSceneMode.Single);
                    Debug.Log("Error");
                }
            }
        }

        Debug.Log("Player selected_character_id = " + players[0].selected_character_id);
    }
}
