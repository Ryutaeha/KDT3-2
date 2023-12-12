using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    
    internal void StatusView(GameObject player)
    {
        ItemAbility item = player.GetComponent<PlayerAbility>().PlayerItem;
        PlayerAbility playerAbility = player.GetComponent<PlayerAbility>();
        gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = $"{playerAbility.PlayerAttack + (item != null? item.Attack : 0)}";
        gameObject.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = $"{playerAbility.PlayerDefensive + (item != null ? item.Defensive : 0)}";
        gameObject.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = $"{playerAbility.PlayerHealth + (item != null ? item.Health : 0)}";
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text = $"{playerAbility.PlayerFatal + (item != null ? item.Fatal : 0)}";
    }

    
}
