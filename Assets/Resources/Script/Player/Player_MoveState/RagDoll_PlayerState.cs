using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll_PlayerState : Player_StateMachine
{
    public override void EnterState(Player_Controller player)
    {
        player.gooseAnimator.SetBool("Runnig", false);
    }

    public override void UpdateState(Player_Controller player)
    {
        ChangeState(player);
    }

    public void ChangeState(Player_Controller player)
    {
        if (!player.playerRedDoll.IsRagDoll)
        {
            player.playerRedDoll.RagDollOff();
            player.ChangeState(player.walk_PlayerState);
        }

        if (player.playerRespawnScrp.IsDead)
        {
            player.vidaParaoTitanic--;
            player.playerRedDoll.RagDollOff();
            player.playerRespawnScrp.IsDead = false;
            player.ChangeState(player.spawning_PlayerState);
        }
    }
}
