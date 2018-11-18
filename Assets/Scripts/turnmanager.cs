using System;
using System.Collections;
using UnityEngine;

class TurnManager : MonoBehaviour
{
    bool is_host_turn = false;
    const int turn_timer = 45; // 45 second turn timer
    int cur_turn_timer;


    void Start()
    {
        cur_turn_timer = turn_timer;
    }


    private void OnMatchStart()
    {
        StartCoroutine(TurnTimer());
    }


    private void OnChangeTurnAttempt()
    {
        // Receive Message
        // ChangeTurn(msg.unit_id);
    }


    private void ChangeTurn(bool is_host)
    {
        if(is_host == is_host_turn)
        {
            is_host_turn = !is_host_turn;
            cur_turn_timer = turn_timer;
        }
        // Send change turn message   
    }


    private IEnumerator TurnTimer()
    {
        turn_timer--;

        if(turn_timer == 0)
        {
            ChangeTurn(is_host_turn);
        }

        while(true)
        {
            yield return WaitForSeconds(1);
        }
    }
}