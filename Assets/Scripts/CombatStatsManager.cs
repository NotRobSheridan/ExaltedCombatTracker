using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStatsManager : MonoBehaviour {

	//Variable stats
	public int personalMotes, PeripheralMotes, willpower, committedPersonal, commitedPeripheral;
	//Trackables
	public int wounds, onslaught, roundCount;

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(gameObject);
	}
	
}
