using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameDataCollection", menuName = "GameDataCollection")]
public class GameData : ScriptableObject
{
    public MapData[] List_of_MapDatas;
    public RowAndColumnCoordinates[] List_of_rowandcolumns;
    public PlantUnit[] PlantUnit_Data_List;
    public ZombieUnit[] ZombieUnit_Data_List;

    public PlantSelectionMenuData plantSelectionMenuData;
    public Color ColorForOutLine;
    public GameObject HoriInputOutLine;
    public GameObject VertiInputOutLine;

    public GameObject BackGround;
}
