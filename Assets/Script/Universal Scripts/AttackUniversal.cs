using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionlayer;
    public float radius = 2f;
    public float hitDamage = 1f;

    public bool is_Player, is_Enemy;

    public GameObject hit_FX_prefab;

    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }
    
    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionlayer);
        if(hit.Length > 0)
        {
            if (is_Player)
            {
                Vector3 hitFXPos = hit[0].transform.position;
                hitFXPos.y += 1.3f;
                if (hit[0].transform.position.x > 0)
                    hitFXPos.x += 0.3f;
                else if(hit[0].transform.position.x < 0)
                    hitFXPos.x -= 0.3f;

                Instantiate(hit_FX_prefab, hitFXPos, Quaternion.identity);

                if(gameObject.CompareTag(Tags.LEFT_ARM_TAG) ||
                    gameObject.CompareTag(Tags.LEFT_LEG_TAG)){

                    hit[0].GetComponent<HealthScript>().ApplyDamage(hitDamage, true);
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(hitDamage, false);
                }
            }//player

            if (is_Enemy)
            {
                hit[0].gameObject.GetComponent<HealthScript>().ApplyDamage(hitDamage, false);
            }
            gameObject.gameObject.SetActive(false);
        }
    }
}
