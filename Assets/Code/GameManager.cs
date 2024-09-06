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

    MapManager mapManager;

    public GameManager(GameData gameData, Camera camera)
    {
        //Data Transfer
        List_of_MapDatas = gameData.List_of_MapDatas;
        List_of_rowandcolumns = gameData.List_of_rowandcolumns;
        PlantUnit_Data_List = gameData.PlantUnit_Data_List;
        ZombieUnit_Data_List = gameData.ZombieUnit_Data_List;

        //Create Other managers

        //Map manager
        int MapInfoIndex = MapToIntConverter(map);
        mapManager = new MapManager(List_of_MapDatas[MapInfoIndex], gameData.BackGround);

        
        //Input manager
        int CoordianteInfoIndex = RowAndCollumnToIntConverter(map);
        inputManager = new InputManager(List_of_rowandcolumns[CoordianteInfoIndex],gameData.HoriInputOutLine , gameData.VertiInputOutLine,camera);

    }

    public void FakeUpdate()
    {
        mapManager.FakeUpdate();
        inputManager.FakeUpdate();
    }

    public static void ChangeMap(string map)
    {
        if (MapToIntConverter(map)==-1)
        {
            Debug.Log("Map does not exist");
            return;
        }
        GameManager.map = map;
    }

    private static int MapToIntConverter(string Map)
    {
        
        switch(Map.ToLower())
        {
            case "day":
                return 0;

            case "night":
                return 1;

            case "pool":
                return 2;

            case "nightPool":
                return 3;

            case "roof":
                return 4;
        }


        return -1;
    }

    private int RowAndCollumnToIntConverter(string Map)
    {
        switch (Map.ToLower())
        {
            case "day":
                return 0;

            case "night":
                return 0;

            case "pool":
                return 1;

            case "nightPool":
                return 1;

            case "roof":
                return 2;
        }


        return -1;
    }

    public static void InputStateChangeToPlantPlacement()
    {
        InputManager.ChangeToPlantPlacementState();
    }
}
