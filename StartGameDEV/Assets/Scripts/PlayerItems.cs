using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Amouonts")]
    [SerializeField] private int totalWood;
    [SerializeField] private float currentWater;
    [SerializeField] private int carrots;
    [SerializeField] private int fishes;

    [Header("limits")]
    private float waterLimit = 50;
    private float carrotsLimit = 10;
    private float woodLimit = 5;
    public float fishesLimit = 3f;

    public int TotalWood
    {
        get { return totalWood; }
        set { totalWood = value; }
    }
    
    public float TotalWater
    {
        get { return currentWater; }
        set { currentWater = value; }
    }
   
    public int TotalCarrots
    {
        get { return carrots; }
        set { carrots = value; }
    }

    public int TotalFishes
    {
        get { return fishes; }
        set { fishes = value; }
    }

    public void WaterLimit(float water)//checando o limite de agua no balde
    {
        if(currentWater <= waterLimit)
        {
            currentWater += water;
        }
    }

    //usados para preenchimnento do UIBar;
    public float CarrotsLimit
    {
        get { return carrotsLimit; }
        set { carrotsLimit = value;}
    }

    public float WoodLimit
    {
        get { return woodLimit; }
        set { woodLimit = value; }
    }

    //limite de agua no balde para uso o waterBarUi
    public float BucketLimit
    {
        get { return waterLimit; }
        set { waterLimit = value;}
    }

    public float FishesLimit
    {
        get { return fishesLimit; }
        set { fishesLimit = value; }
    }



}
