using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation playerAnim;

    private bool activateTimerToReset;

    private float defaultComboTime = 0.4f;
    private float currentComboTime;

    private ComboState currentComboState;

    public enum ComboState
    {
        NONE,
        PUNCH1,
        PUNCH2,
        PUNCH3,
        KICK1,
        KICK2
    }
    private void Awake() => playerAnim = GetComponentInChildren<CharacterAnimation>();
 
    // Start is called before the first frame update
    void Start()
    {
        currentComboTime = defaultComboTime;
        currentComboState = ComboState.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        ResetComboState();
        ComboAttacks();
    }
    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(currentComboState == ComboState.PUNCH3 ||
                currentComboState == ComboState.KICK1 ||
                currentComboState == ComboState.KICK2)
            {
                return;
            }

            currentComboState++;
            currentComboTime = defaultComboTime;
            activateTimerToReset = true;
            if (currentComboState == ComboState.PUNCH1)
                playerAnim.Punch1();
            if (currentComboState == ComboState.PUNCH2)
                playerAnim.Punch2();
            if (currentComboState == ComboState.PUNCH3)
                playerAnim.Punch3();
        }
            
        if (Input.GetKeyDown(KeyCode.X))
        {
            //if combostate is punch3/kick2 ,return since there is no combo to perform
            if (currentComboState == ComboState.PUNCH3 || currentComboState == ComboState.KICK2)
                return;
            //if combostate is none/punch1/punch2 , chain the action with kick1
            if (currentComboState == ComboState.NONE ||
                currentComboState == ComboState.PUNCH1 ||
                currentComboState == ComboState.PUNCH2)
            {
                currentComboState = ComboState.KICK1;
            }
            //if combostate is kick1 chain with kick2
            else if(currentComboState == ComboState.KICK1)
            {
                currentComboState++;
            }
            //with these above conditions we can have these chains only if the X key is pressed continously 
            //none-kick1    none-kick1-kick2
            //punch1-kick1   punch1-kick1-kick2
            //punch2-kick1    punch2-kick1-kick2

            activateTimerToReset = true;
            currentComboTime = defaultComboTime;

            if (currentComboState == ComboState.KICK1)
                playerAnim.Kick1();
            if (currentComboState == ComboState.KICK2)
                playerAnim.Kick2();

        }
           
    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            currentComboTime -= Time.deltaTime;
            if(currentComboTime < 0f)
            {
                currentComboState = ComboState.NONE;
                activateTimerToReset = false;
                currentComboTime = defaultComboTime;
            }
        }
    }
}
