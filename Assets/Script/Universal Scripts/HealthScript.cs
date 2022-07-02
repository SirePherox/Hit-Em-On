using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float charHealth = 100f;

    private CharacterAnimation animScript;
    private EnemyMovement enemMoveScript;
    private HealthUi healthUiScript;

    public bool charDied;
    public bool isPlayer;

    private void Awake()
    {
        animScript = GetComponentInChildren<CharacterAnimation>();

        if (isPlayer)
        {
            healthUiScript = GetComponent<HealthUi>();
        }
    }

    public void ApplyDamage(float damage, bool knockdown)
    {
        if (charDied)
            return;

        charHealth -= damage;

        //display health UI
        healthUiScript.DisplayHealth(charHealth);

        if(charHealth <= 0f)
        {
            animScript.Death();
            charDied = true;

            //check if player is holding this script , if its player that died
            if (isPlayer)
            {
                GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
            }
            return;
        }

        if (!isPlayer)
        {
            if (knockdown)
            {
                if (Random.Range(0, 2) > 0) //creates a 50/50 probability
                    animScript.KnockDown();
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                    animScript.Hit();
            }
        }
    }//ApplyDamage func
}
