using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private string gameVersion = "0.0.0";

    public string GameVersion { get { return this.gameVersion; } }

    [SerializeField] private string nickName = "PunFish";
    public string Nickname
    {
        get
        {
            int value = Random.Range(0, 9999);
            return this.nickName + value.ToString();
        }
    }
}
