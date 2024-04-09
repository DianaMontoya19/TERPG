using System;
using UnityEngine;

[Serializable]
public enum FlagStatesEnum
{
    Point,
    Captured,
}

public class FlagManager : MonoBehaviour
{
    private static FlagManager _instance;
    public static FlagManager Instance => _instance;
    
    public Transform flagPosition;
    public Transform flag;
    public FlagStatesEnum currentState;
    public Transform capturedBy;

    private void Awake()
    {
        _instance = this;
    }
}
