using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossManager : MonoBehaviour
{
    public enum LeftOperation
    {
        Plus,
        Multiply
    }
    public enum RightOperation
    {
        Plus,
        Multiply
    }

    [Header("LeftOperation")]
    [SerializeField] LeftOperation leftOperation;
    public int LeftValue;
    [Header("RightOperation")]
    [SerializeField] RightOperation rightOperation;
    public int RightValue;

    [SerializeField] TextMeshPro LeftText;
    [SerializeField] TextMeshPro RightText;
    void Awake()
    {
        if (leftOperation == LeftOperation.Plus)
        {
            LeftText.text = "+ " + LeftValue;
        }
        else
        {
            LeftText.text = "x " + LeftValue;
        }
        if (rightOperation == RightOperation.Plus)
        {
            RightText.text = "+ " + RightValue;
        }
        else
        {
            RightText.text = "x " + RightValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
