using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Vector2> SpawnPoints;
    
    public GameObject[] PlayerPrefab;
    public GameObject MainCamera;
    //List<Players?>

    List<GameObject> Players = new List<GameObject>();
    public void Start()
    {
         if (GLOBAL_.is_player_1_active)
        {
            GameObject player_stencil = Instantiate(PlayerPrefab[GLOBAL_.player_1_selected_character]);
            player_stencil.GetComponent<CharacterController>().PlayerID = 1;
            player_stencil.transform.position = new Vector3(SpawnPoints[0].x, SpawnPoints[0].y, 0);
            Players.Add(player_stencil);
            MainCamera.GetComponent<DynamicCamera>().ListOfFollowing.Add(player_stencil.transform);
        }
        if (GLOBAL_.is_player_2_active)
        {
            GameObject player_stencil = Instantiate(PlayerPrefab[GLOBAL_.player_2_selected_character]);
            player_stencil.GetComponent<CharacterController>().PlayerID = 2;
            player_stencil.transform.position = new Vector3(SpawnPoints[1].x, SpawnPoints[1].y, 0);
            MainCamera.GetComponent<DynamicCamera>().ListOfFollowing.Add(player_stencil.transform);
            Players.Add(player_stencil);
        }
        if (GLOBAL_.is_player_3_active)
        {
            GameObject player_stencil = Instantiate(PlayerPrefab[GLOBAL_.player_3_selected_character]);
            player_stencil.GetComponent<CharacterController>().PlayerID = 3;
            player_stencil.transform.position = new Vector3(SpawnPoints[2].x, SpawnPoints[2].y, 0);
            MainCamera.GetComponent<DynamicCamera>().ListOfFollowing.Add(player_stencil.transform);
            Players.Add(player_stencil);

        }
        if (GLOBAL_.is_player_4_active)
        {
            GameObject player_stencil = Instantiate(PlayerPrefab[GLOBAL_.player_4_selected_character]);
            player_stencil.GetComponent<CharacterController>().PlayerID = 4;
            player_stencil.transform.position = new Vector3(SpawnPoints[3].x, SpawnPoints[3].y, 0);
            MainCamera.GetComponent<DynamicCamera>().ListOfFollowing.Add(player_stencil.transform);
            Players.Add(player_stencil);
        }
    }

    // Update is called once per frame
    void Update()
    {

 

    }
}
