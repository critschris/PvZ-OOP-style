using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{

    MapData[] List_of_MapDatas;
    RowAndColumnCoordinates[] List_of_rowandcolumns;
    PlantUnit[] PlantUnit_Data_List;
    ZombieUnit[] ZombieUnit_Data_List;

    public static string map = "Day";

    InputManager inputManager;

    public GameManager(MapData[] list_of_MapDatas, RowAndColumnCoordinates[] rowAndColumnCoordinates, PlantUnit[] plantUnit_Data_List, ZombieUnit[] zombieUnit_Data_List)
    {
        //Data Transfer
        List_of_MapDatas = list_of_MapDatas;
        List_of_rowandcolumns = rowAndColumnCoordinates;
        PlantUnit_Data_List = plantUnit_Data_List;
        ZombieUnit_Data_List = zombieUnit_Data_List;

        //Create Other managers
        if (GameManager.map=="Day")
        {

        }
        inputManager = new InputManager(List_of_rowandcolumns);
    }

    public void FakeUpdate()
    {
        inputManager.FakeUpdate();
    }

    public static void ChangeMap(string map)
    {
        if (map!="Day"&&map!="Night"&&map!="Pool")
        {
            return;
        }
        GameManager.map = map;
    }

}
