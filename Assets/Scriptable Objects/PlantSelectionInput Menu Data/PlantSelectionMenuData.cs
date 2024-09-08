using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlantSelectionMenuData", menuName = "PlantSelectionMenuData")]
public class PlantSelectionMenuData : ScriptableObject
{

    public Color UninteractableColor;
    public Sprite EmptyImage;

    public GameObject PlantSelectedButton;
    public Vector3 topLeftCoordinate;
    public float rightoffset;

}
