using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager 
{
    PlantUnit[] PlantUnit_Data_List;
    ZombieUnit[] ZombieUnit_Data_List;

    GameObject[] ActivePlants_List = new GameObject[45];
    ArrayList ActiveZombies_List;

    public UnitManager(PlantUnit[] PlantUnit_Data_List, ZombieUnit[] ZombieUnit_Data_List)
    {
        this.PlantUnit_Data_List = PlantUnit_Data_List;
        this.ZombieUnit_Data_List = ZombieUnit_Data_List;
    }


    public static void InstantiatePlant()
    {

    }

    public static void InstantiateZombie()
    {

    }

    
}
