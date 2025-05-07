using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ship;
    public GameObject ReturnPlayer()
    {
        return player;
    }

    public GameObject ReturnShip()
    {
        return ship;
    }
}
