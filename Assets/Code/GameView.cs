using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public MapData[] List_of_MapDatas;
    public RowAndColumnCoordinates[] List_of_rowandcolumns;
    public PlantUnit[] PlantUnit_Data_List;
    public ZombieUnit[] ZombieUnit_Data_List;

    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = new GameManager(List_of_MapDatas,List_of_rowandcolumns,PlantUnit_Data_List,ZombieUnit_Data_List);
    }

    // Update is called once per frame
    void Update()
    {
       // GameManager.FakeUpdate();
    }
}
