using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerTurnController : MonoBehaviour
{

    [SerializeField] int NumberOfMatches;
    [SerializeField] bool LimitlessMatches;
    [Space]
    [SerializeField]
    int HumanPlayers;
    [SerializeField] int AIPlayers;
    [Space]
    [SerializeField]
    GameObject PlayerPrefab;
    [SerializeField] GameObject AIPrefab;

    int matchNumber;

    void Start()
    {

    }

}
