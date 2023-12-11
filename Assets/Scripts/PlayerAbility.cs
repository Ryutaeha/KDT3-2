using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private string playerId;
    [SerializeField] private int playerLevel;
    [SerializeField] private int playerGold;
    [SerializeField] private int playerHealth;
    [SerializeField] private int playerAttack;
    [SerializeField] private int playerDefensive;
    [SerializeField] private int playerfatal;

    public string PlayerId { get { return playerId; } set { playerId = value; } }
    public int PlayerLevel { get { return playerLevel; } set { playerLevel = value; } }
    public int PlayerGold { get { return playerGold; } set { playerGold = value; } }
    public int PlayerHealth { get { return playerHealth; } set { playerHealth = value; } }
    public int PlayerAttack { get { return playerAttack; } set { playerAttack = value; } }
    public int PlayerDefensive { get { return playerDefensive; } set { playerDefensive = value; } }
    public int Playerfatal { get { return playerfatal; } set { playerfatal = value; } }

}
