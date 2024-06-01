using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] Player_Net_con_[] players;

    private void Start()
    {
        players = FindObjectsByType<Player_Net_con_>(FindObjectsSortMode.None);

        foreach (Player_Net_con_ player in players)
        {
            player.SetPlayerActive();
        }
    }
}
