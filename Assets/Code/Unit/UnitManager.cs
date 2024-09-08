using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager 
{
    PlantUnit[] PlantUnit_Data_List;
    ZombieUnit[] ZombieUnit_Data_List;

    GameObject[] ActivePlants_List;
    ArrayList ActiveZombies_List;

    public UnitManager(PlantUnit[] PlantUnit_Data_List, ZombieUnit[] ZombieUnit_Data_List, RowAndColumnCoordinates rowAndColumnCoordinates)
    {
        this.PlantUnit_Data_List = PlantUnit_Data_List;
        this.ZombieUnit_Data_List = ZombieUnit_Data_List;
        ActivePlants_List = new GameObject[rowAndColumnCoordinates.row_amount*9];
    }


    public static void InstantiatePlant()
    {

    }

    public static void InstantiateZombie()
    {

    }

    public Sprite GetPlantUnitPic(int a)
    {
        if (a<PlantUnit_Data_List.Length)
        {
            return PlantUnit_Data_List[a].UnitPic;
        }
        return null;
    }


    
}
