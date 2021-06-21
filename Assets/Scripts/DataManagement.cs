using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagement : MonoBehaviour
{
    public Player player;

    public void Awake()
    {
        LoadPlayer();
    }

    public void SavePlayer ()
    {
        SaveSystem.SavePlayer(player);
    }

    public void LoadPlayer ()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        player.level = data.level;
        player.health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        player.transform.position = position;
    }
}
