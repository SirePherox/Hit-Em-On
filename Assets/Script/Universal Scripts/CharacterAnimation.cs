using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool move)
    {
        anim.SetBool(AnimationTags.MOVEMENT,move);
    }

    public void Kick1()
    {
        anim.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }

    public void Kick2()
    {
        anim.SetTrigger(AnimationTags.KICK_2_TRIGGER);
    }
    public void Punch1()
    {
        anim.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
    }
    public void Punch2()
    {
        anim.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
    }
    public void Punch3()
    {
        anim.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    }

    public void EnemyAttack(int attack)
    {
        if(attack == 0)
        {
            anim.SetTrigger(AnimationTags.ATTACK_1_TRIGGER);
        }
        if (attack == 1)
        {
            anim.SetTrigger(AnimationTags.ATTACK_2_TRIGGER);
        }
        if (attack == 2)
        {
            anim.SetTrigger(AnimationTags.ATTACK_3_TRIGGER);
        }
    }

    public void PlayIdleAnim()
    {
        anim.Play(AnimationTags.IDLE_ANIMATION);
    }
    public void KnockDown()
    {
        anim.SetTrigger(AnimationTags.KNOCK_DOWN_TRIGGER);
    }
    public void Hit()
    {
        anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    }
    public void StandUp()
    {
        anim.SetTrigger(AnimationTags.STAND_UP_TRIGGER);
    }
    public void Death()
    {
        anim.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }
}
