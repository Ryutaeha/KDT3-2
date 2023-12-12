using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    //더미 데이터
    [SerializeField] private string playerId;
    [SerializeField] private int playerLevel;
    [SerializeField] private string playerJob;
    [SerializeField] private int playerGold;
    [SerializeField] private int playerHealth;
    [SerializeField] private int playerAttack;
    [SerializeField] private int playerDefensive;
    [SerializeField] private int playerFatal;
    [SerializeField] private string playerSelfIntroduction;


    private ItemAbility playerItem = null;

    public ItemAbility PlayerItem { get { return playerItem; }}

    public void playerItemSet(ItemAbility item)
    {
        playerItem = item;
    }
    public string PlayerId { get { return playerId; } set { playerId = value; } }
    public int PlayerLevel { get { return playerLevel; } set { playerLevel = value; } }
    public string PlayerJob { get { return playerJob; } set { playerJob = value; } }
    public int PlayerGold { get { return playerGold; } set { playerGold = value; } }
    public int PlayerHealth { get { return playerHealth; } set { playerHealth = value; } }
    public int PlayerAttack { get { return playerAttack; } set { playerAttack = value; } }
    public int PlayerDefensive { get { return playerDefensive; } set { playerDefensive = value; } }
    public int PlayerFatal { get { return playerFatal; } set { playerFatal = value; } }
    public string PlayerSelfIntroduction { get { return playerSelfIntroduction; } set { playerSelfIntroduction = value; } }
}

