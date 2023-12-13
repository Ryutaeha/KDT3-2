using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleInfo : MonoBehaviour
{


    private void Start()
    {
        GameManager.Instance.PlayerSet += SetUI;
    }

    public void SetUI(GameObject player)
    {
        PlayerAbility ability = player.GetComponent<PlayerAbility>();
        gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = ability.PlayerJob;
        gameObject.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = $"Lv. {ability.PlayerLevel} {ability.PlayerId}";
        gameObject.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = ability.PlayerSelfIntroduction;
        GameManager.Instance.PlayerSet -= SetUI;
    }
}
