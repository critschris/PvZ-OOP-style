using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RowAndColumnCoordinates", menuName = "MapStructure")]
public class RowAndColumnCoordinates : ScriptableObject
{
    public int row_amount;

    public float first_row_Coordinate;
    public float first_column_Coordinate;

    public float row_offset;
    public float column_offset;
}
