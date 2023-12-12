using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    internal void StatusView(GameObject player)
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = player.GetComponent<PlayerAbility>().PlayerAttack.ToString();
        gameObject.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = player.GetComponent<PlayerAbility>().PlayerDefensive.ToString();
        gameObject.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = player.GetComponent<PlayerAbility>().PlayerHealth.ToString();
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text = player.GetComponent<PlayerAbility>().PlayerFatal.ToString();
    }
}
