using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RowAndColumnCoordinates", menuName = "MapStructure")]
public class RowAndColumnCoordinates : ScriptableObject
{
    public enum Map { Day, Night, Pool, NightPool, Roof };
    public Map map;

    public int row_amount;

    public float first_row_Coordinate;
    public float first_column_Coordinate;

    public float row_offset;
    public float column_offset;

    public float[] PlantingInputRowLines;
    public float[] PlantingInputCollumnLines;

    public float[] RowInputOutLinePOS;
    public float[] CollumnInputOutLinePOS;
}
