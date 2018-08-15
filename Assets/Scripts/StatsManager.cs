using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//[System.Serializable]
public class StatsManager : MonoBehaviour
{

    [Header("Mote Caps")]
    public int maxPersonal;
    public int maxPeripheral;
    public int maxWillpower;
    public int maxPersonalFixed;
    public int maxPeripheralFixed;
    public int essence;
    [Header("Consumables")]
    public int personalMotes;
    public int peripheralMotes;
    public int willpower;
    public int committedPersonal;
    public int commitedPeripheral;
    [Header("Attributes")]
    public int str;
    public int dex;
    public int sta;
    public int cha;
    public int man;
    public int app;
    public int per;
    public int inte;
    public int wit;
    [Header("Combat Specifics")]
    public int wounds;
    public int onslaught;
    public int turnCount;
    public int initiative;
    [Header("Battlegroup Stats")]
    public int size;
    public int magnitude;
    public int might;
    public int battlegroupInitiative;


    [Header("Input Fields")]
    public InputField personalInput;
    public InputField peripheralInput;
    public InputField willpowerInput;
    public InputField committedPersonalInput;
    public InputField committedPeripheralInput;
    public InputField initiativeInput;
    public InputField woundsInput;
    public InputField onslaughtInput;
    public InputField essenceInput;
    public InputField personalCapInput;
    public InputField peripheralCapInput;
    public InputField willpowerCapInput;
    public InputField sizeInput;
    public InputField magnitudeInput;
    public InputField mightInput;
    public InputField battlegroupInitiativeInput;

    [Header("Other")]
	public Text turnCountText;
    public Canvas combatCanvas, statsCanvas, battleGroupCanvas;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ////Initialise
        maxPersonalFixed = 0;
        maxPeripheralFixed = 0;
        maxWillpower = 0;
        ResetValues();
        statsCanvas.enabled = true;
        combatCanvas.enabled = false;
        battleGroupCanvas.enabled = false;
    }

    public void ModifyCap(string capID)
    {
        
        switch (capID)
        {
            case "AddPersonal":
                maxPersonalFixed++;
                maxPersonal = maxPersonalFixed;
                personalCapInput.text = maxPersonal.ToString();
                break;
            case "AddPeripheral":
                maxPeripheralFixed++;
                maxPeripheral = maxPeripheralFixed;
                peripheralCapInput.text = maxPeripheral.ToString();
                break;
            case "AddWillpower":
                maxWillpower++;
                willpowerCapInput.text = maxWillpower.ToString();
                break;
            case "SubPersonal":
                if (maxPersonalFixed > 0)
                {
                    maxPersonalFixed--;
                    maxPersonal = maxPersonalFixed;
                }
                personalCapInput.text = maxPersonal.ToString();
                break;
            case "SubPeripheral":
                if (maxPeripheralFixed > 0)
                {
                    maxPeripheralFixed--;
                    maxPeripheral = maxPeripheralFixed;
                }
                peripheralCapInput.text = maxPeripheral.ToString();
                break;
            case "SubWillpower":
                if (maxWillpower > 0)
                    maxWillpower--;
                willpowerCapInput.text = maxWillpower.ToString();
                break;
        }
    }

    public void ParseInt(GameObject thisInput)
    {
        Debug.Log(str);
        InputField thisField = thisInput.gameObject.GetComponent<InputField>();
        int changeTo = Convert.ToInt32(thisField.text);
        str = changeTo;
        thisField.text = str.ToString(); 
        Debug.Log(str);
    }

    public void ModifyValue(string valueID GameObject thisInput)
    {
       InputField thisField = thisInput.gameObject.GetComponentInParent<InputField>();
        str++;
        thisField.text = str.ToString();

        switch (valueID)
        {
            case "AddEssence":
                essence++;
                essenceInput.text = essence.ToString();
                maxPersonalFixed = (essence * 3) + 10;
                maxPeripheralFixed = (essence * 7) + 27;
                personalInput.text = personalMotes.ToString() + " / " + maxPersonal.ToString();
                committedPersonalInput.text = committedPersonal.ToString();


                break;

            case "SubEssence":
                if (essence >= 0) { essence--; }
                essenceInput.text = essence.ToString();
                maxPersonalFixed = (essence * 3) + 10;
                maxPeripheralFixed = (essence * 7) + 27;
                personalInput.text = personalMotes.ToString() + " / " + maxPersonal.ToString();
                committedPersonalInput.text = committedPersonal.ToString();


                break;

            //Personal Motes
            case "AddPersonal":
                if (personalMotes < maxPersonal) { personalMotes++; }
                personalInput.text = personalMotes.ToString() + " / " + maxPersonal.ToString();
                break;

            case "AddPersonalCommit":
                if (committedPersonal > -1 && personalMotes > 0)
                {
                    committedPersonal++;
                    maxPersonal--;
                    personalMotes--;
                    personalInput.text = personalMotes.ToString() + " / " + maxPersonal.ToString();
                    committedPersonalInput.text = committedPersonal.ToString();
                }
                break;

            case "SubPersonal":
                if (personalMotes >= 1) { personalMotes--; }
                personalInput.text = personalMotes.ToString() + " / " + maxPersonal.ToString();
                break;

            case "SubPersonalCommit":
                if (committedPersonal >= 1)
                {
                    committedPersonal--;
                    maxPersonal++;
                    personalInput.text = personalMotes.ToString() + " / " + maxPersonal.ToString();
                    committedPersonalInput.text = committedPersonal.ToString();
                }
                break;

            //Peripheral Motes
            case "AddPeriph":
                if (peripheralMotes < maxPeripheral) { peripheralMotes++; }
                peripheralInput.text = peripheralMotes.ToString() + " / " + maxPeripheral.ToString();
                break;

            case "AddPeriphCommit":
                if (commitedPeripheral > -1 && peripheralMotes > 0)
                {
                    commitedPeripheral++;
                    maxPeripheral--;
                    peripheralMotes--;
                    peripheralInput.text = peripheralMotes.ToString() + " / " + maxPeripheral.ToString();
                    committedPeripheralInput.text = commitedPeripheral.ToString();
                }
                break;

            case "SubPeriph":
                if (peripheralMotes >= 1) { peripheralMotes--; }
                peripheralInput.text = peripheralMotes.ToString() + " / " + maxPeripheral.ToString();
                break;

            case "SubPeriphCommit":
                if (commitedPeripheral >= 1)
                {
                    commitedPeripheral--;
                    maxPeripheral++;
                    peripheralInput.text = peripheralMotes.ToString() + " / " + maxPeripheral.ToString();
                    committedPeripheralInput.text = commitedPeripheral.ToString();
                }
                break;

            //Initiative
            case "AddInitiative":
                initiative++;
                initiativeInput.text = initiative.ToString();
                break;
            case "SubInitiative":
                initiative--;
                initiativeInput.text = initiative.ToString();
                break;

            //Onslaught
            case "AddOnslaught":
                onslaught++;
                onslaughtInput.text = onslaught.ToString();
                break;
            case "SubOnslaught":
                if (onslaught > 0)
                { onslaught--; onslaughtInput.text = onslaught.ToString(); }
                break;

            //Wounds
            case "AddWounds":
                wounds++;
                woundsInput.text = wounds.ToString();
                break;
            case "SubWounds":
                if (wounds > 0)
                { wounds--; woundsInput.text = wounds.ToString(); }
                break;

            //Willpower
            case "AddWillpower":
                if (willpower < maxWillpower)
                {
                    willpower++;
                    willpowerInput.text = willpower.ToString() + " / " + maxWillpower.ToString();
                }
                break;
            case "SubWillpower":
                if (willpower > 0)
                {
                    willpower--;
                    willpowerInput.text = willpower.ToString() + " / " + maxWillpower.ToString();
                }
                break;

            case "AddStr":
                if (str <= 4)
                {
                    Debug.Log("Str Add");
                    str++;
                //    thisField.text = str.ToString();
                }
                break;
            case "SubStr":
                if (str > 0)
                {
                    willpower--;
                    willpowerInput.text = willpower.ToString() + " / " + maxWillpower.ToString();
                }
                break;
        }
    }

    public void EditBattlegroup(string battleGroupID)
    {
        switch(battleGroupID)
        {
            case "AddSize":
                if(size <= 4)
                {
                    size++;
                    sizeInput.text = size.ToString();
                }
                break;
            case "SubSize":
                if(size > 0)
                {
                    size--;
					sizeInput.text = size.ToString();

				}
                break;
            case "AddMagnitude":
                magnitude++; magnitudeInput.text = magnitude.ToString();
                break;
            case "SubMagnitude":
                if (magnitude > 0)
					magnitude--; magnitudeInput.text = magnitude.ToString();
                break;
            case "AddMight":
                if (might <= 2)
                    might++; mightInput.text = might.ToString();
                break;
            case "SubMight":
                if (might > 0)
                    might--; mightInput.text = might.ToString();
                break;
            case "AddInitiative":
                battlegroupInitiative++; battlegroupInitiativeInput.text = battlegroupInitiative.ToString();
                break;
            case "SubInitiative":
				battlegroupInitiative--; battlegroupInitiativeInput.text = battlegroupInitiative.ToString();
				break;
		}

    }

    public void ResetValues()
    {
        maxPersonal = maxPersonalFixed;
        maxPeripheral = maxPeripheralFixed;
        personalMotes = maxPersonal;
        peripheralMotes = maxPeripheral;
        willpower = maxWillpower;
        commitedPeripheral = 0;
        committedPersonal = 0;
        wounds = 0;
        onslaught = 0;
        turnCount = 1;
        initiative = 0;
        ResetStrings();

    }

    public void ResetBattlegroup()
    {
        size = 0;
        magnitude = 0;
        might = 0;
        battlegroupInitiative = 0;
        ResetStrings();
    }

    public void ResetStrings()
    {
        //Player strings
		personalInput.text = personalMotes.ToString() + " / " + maxPersonal.ToString();
		peripheralInput.text = peripheralMotes.ToString() + " / " + maxPeripheral.ToString();
		willpowerInput.text = willpower.ToString() + " / " + maxWillpower.ToString();
		committedPeripheralInput.text = commitedPeripheral.ToString();
		committedPersonalInput.text = committedPersonal.ToString();
		woundsInput.text = wounds.ToString();
		onslaughtInput.text = onslaught.ToString();
		initiativeInput.text = initiative.ToString();
		turnCountText.text = "Turn# " + turnCount.ToString();
        personalCapInput.text = maxPersonalFixed.ToString();
        peripheralCapInput.text = maxPeripheralFixed.ToString();
        willpowerCapInput.text = maxWillpower.ToString();
        //Battlegroup Strings
		sizeInput.text = size.ToString();
        magnitudeInput.text = magnitude.ToString();
        mightInput.text = might.ToString();
        battlegroupInitiativeInput.text = battlegroupInitiative.ToString();
	}

    public void NextRound()
    {

        onslaught = 0;

        for (int i = 0; i < 5; i++)
        {
            if (peripheralMotes < maxPeripheral)
                peripheralMotes++;
            else if (personalMotes < maxPersonal)
                personalMotes++;
        }
        turnCount++;
        ResetStrings();
    }

    public void SwitchScreen(string screenID)
    {

        switch(screenID)
        {
            case "Stats":
				statsCanvas.enabled = true;
				combatCanvas.enabled = false;
                battleGroupCanvas.enabled = false;
                ResetStrings();
                break;
			case "Combat":
                statsCanvas.enabled = false;
				combatCanvas.enabled = true;
				battleGroupCanvas.enabled = false;
                ResetStrings();
				break;
			case "Battlegroup":
                statsCanvas.enabled = false;
				combatCanvas.enabled = false;
                battleGroupCanvas.enabled = true;
                ResetStrings();
				break;
        }

        ResetStrings();

    }
}
