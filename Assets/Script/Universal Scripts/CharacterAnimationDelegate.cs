using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject leftArmAttackPoint, rightArmAttackPoint,
                        leftLegAttackPoint, rightLegAttackPoint;
    public float standUpTime = 2f;
    private CharacterAnimation animScript;

    private EnemyMovement enemMoveScript;
    private CameraShake shakeCam;
    private void Awake()
    {
        animScript = GetComponent<CharacterAnimation>();

        if (gameObject.CompareTag(Tags.ENEMY_TAG))
            enemMoveScript = GetComponentInParent<EnemyMovement>();

        shakeCam = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<CameraShake>();
    }
    void LeftArmAttackPoint_ON()
    {
        leftArmAttackPoint.SetActive(true);
    }
    void LeftArmAttackPoint_OFF()
    {
        if(leftArmAttackPoint.activeInHierarchy)
            leftArmAttackPoint.SetActive(false);
    }
    void RightArmAttackPoint_ON()
    {
        rightArmAttackPoint.SetActive(true);
    }
    void RightArmAttackPoint_OFF()
    {
        if (rightArmAttackPoint.activeInHierarchy)
            rightArmAttackPoint.SetActive(false);
    }
    void LeftLegAttackPoint_ON()
    {
        leftLegAttackPoint.SetActive(true);
    }
    void LeftLegAttackPoint_OFF()
    {
        if (leftLegAttackPoint.activeInHierarchy)
            leftLegAttackPoint.SetActive(false);
    }
    void RightLegAttackPoint_ON()
    {
        rightLegAttackPoint.SetActive(true);
    }
    void RightLegAttackPoint_OFF()
    {
        if (rightLegAttackPoint.activeInHierarchy)
            rightLegAttackPoint.SetActive(false);
    }

    void TagLeftArm()
    {
        leftArmAttackPoint.tag = Tags.LEFT_ARM_TAG;
    }
    void UnTagLeftArm()
    {
        leftArmAttackPoint.tag = Tags.UNTAGGED_TAG;
    }
    void TagLeftLeg()
    {
        leftLegAttackPoint.tag = Tags.LEFT_LEG_TAG;
    }
    void UnTagLeftLeg()
    {
        leftLegAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void EnemyStandUp()
    {
        StartCoroutine(StandUpAfterTimer());
    }
    IEnumerator StandUpAfterTimer()
    {
        yield return new WaitForSeconds(standUpTime);
        animScript.StandUp();
    }
    void DisableEnemScript()
    {
        enemMoveScript.enabled = false;

        //set to default layer to avoid detecting collision while the enemy has been knocked down
        transform.parent.gameObject.layer = 0;
    }
    void EnableEnemScript()
    {
        enemMoveScript.enabled = true;

        //set back to "Enemy" layer to detect collision 
        transform.parent.gameObject.layer = 6;
    }

    void ShakeCamOnFall()
    {
        shakeCam.ShouldShake = true;
    }

    void CharacterDied()
    {
        Invoke("DeactivateGameObject", 2f);
    }

    void DeactivateGameObject()
    {
        EnemyManager.instance.SpawnEnemy();
        gameObject.SetActive(false);
    }
}
