using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMusic : MonoBehaviour
{
    public GameObject prelude;
    public GameObject battle;
    // Start is called before the first frame update
    void Start()
    {
        prelude = GameObject.Find("PreludeSong");
        battle = GameObject.Find("BattleSong");

        prelude.GetComponent<AudioSource>().Play();
        battle.GetComponent<AudioSource>().PlayDelayed(40f);
    }
}
