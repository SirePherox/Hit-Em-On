using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnim;
    private Rigidbody myBody;

    public float speed = 1.5f;
    private Transform playerTarget;

    public float attackDistance = 1.5f;
    public float chasePlayerAfterAttack = 1.0f;
    private float currrentAttackTime;
    private float defaultAttackTime = 2.0f;

    public bool attackPlayer, followPlayer;
    // Start is called before the first frame update

    private void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();
        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }
  
    
    void Start()
    {
        followPlayer = true;
        currrentAttackTime = defaultAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        //return if we arent supposed to follow players, succeedding statements wont be executed
        if (!followPlayer)
        {
            return;
        }//

        //checks distance of enemy and player
        if(Vector3.Distance(transform.position,playerTarget.position) > attackDistance)
        {
            followPlayer = true;
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;

            //check to see if the enemy is moving, that is , velocity is being applied to its rigidbody
            if (myBody.velocity.sqrMagnitude != 0)
                enemyAnim.Walk(true);

        }
        else if(Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);
            //transform.LookAt(playerTarget);
            followPlayer = false;
            attackPlayer = true;
        }
    }//FollowTarget

    void Attack()
    {
        //if we are NOT supposed to attack player , exit the function
        if (!attackPlayer)
            return;

        currrentAttackTime += Time.deltaTime;

        if(currrentAttackTime > defaultAttackTime)
        {
            enemyAnim.EnemyAttack(Random.Range(GameValues.RANDOM_GEN_MIN, GameValues.RANDOM_GEN_MAX));
            currrentAttackTime = 0f;
        }
        
        //if player moves away after being hit, give him sometime before attacking again
        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            followPlayer = true;
            attackPlayer = false;
        }
    }//Attack
}
