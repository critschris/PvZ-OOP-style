using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager 
{

    RowAndColumnCoordinates rowandcolumns;
    GameObject HoriInput;
    GameObject VertiInput;

    Transform HoriInputTransform;
    Transform VertiInputTransform;
    SpriteRenderer HoriInputRenderer;
    SpriteRenderer VertiInputRenderer;

    PlantSelectionMenuData plantSelectionMenuData;
    PlantSelectionMenuComponent plantSelectionMenu;
    GameObject[] List_Of_Chosen_Plants;
    GameObject[] List_Of_Plant_Selection;

    UnitManager unitManager;

    bool InputOutLineIsEnabled;

    float[] rowLimits;
    float[] collumnLimits;

    float[] RowInputOutLinePOS;
    float[] CollumnInputOutLinePOS;

    Vector2 InputOutlinePOS;

    Camera Onlycamera;

    Color Transparent_Color;

    enum InputState {FreeMovement, PlantPlacement}
    static InputState inputState = InputState.FreeMovement;

    public InputManager(RowAndColumnCoordinates rowandcolumns, GameObject HoriInput,GameObject VertiInput, Camera camera, Color Tcolor, PlantSelectionMenuData plantSelectionMenuData,UnitManager unitManager)
    {
        this.rowandcolumns = rowandcolumns;
        Onlycamera = camera;
        this.HoriInput = Object.Instantiate(HoriInput);
        this.VertiInput = Object.Instantiate(VertiInput);
        HoriInputTransform = this.HoriInput.transform;
        VertiInputTransform = this.VertiInput.transform;
        HoriInputRenderer = this.HoriInput.GetComponentInChildren<SpriteRenderer>();
        VertiInputRenderer = this.VertiInput.GetComponentInChildren<SpriteRenderer>();

        Transparent_Color = Tcolor;

        rowLimits = rowandcolumns.PlantingInputRowLines;
        collumnLimits = rowandcolumns.PlantingInputCollumnLines;

        RowInputOutLinePOS = rowandcolumns.RowInputOutLinePOS;
        CollumnInputOutLinePOS = rowandcolumns.CollumnInputOutLinePOS;
        InputOutLineIsEnabled = false;

        GameObject tempGO = Object.FindObjectOfType<Canvas>().gameObject;
        plantSelectionMenu = tempGO.GetComponentInChildren<PlantSelectionMenuComponent>();
        List_Of_Plant_Selection = plantSelectionMenu.ListOfPlantButtons;
        this.plantSelectionMenuData = plantSelectionMenuData;

        this.unitManager = unitManager;
        SetupPlantSlectionButtons();
    }

    public void FakeFixedUpdate()
    {
        if (inputState == InputState.PlantPlacement)
        {
            if (!InputOutLineIsEnabled) { 
                EnableInputOutLine();
            }
            PlantInput();
        }
    }

    public void FakeUpdate()
    {
        if (Input.GetMouseButtonDown(0)&& InputOutLineIsEnabled)
        {
            DisableInputOutLine();
            ChangeToFreeMovementState();
        }
    }

    private void SetupPlantSlectionButtons()
    {

        bool EndOfList = false;
        for (int i=0; i<List_Of_Plant_Selection.Length;i++)
        {
            if (!EndOfList)
            {
                Sprite tempSprite = unitManager.GetPlantUnitPic(i);
                if (tempSprite==null)
                {
                    List_Of_Plant_Selection[i].GetComponent<Image>().sprite = plantSelectionMenuData.EmptyImage;
                    EndOfList = true;
                    continue;
                }
                List_Of_Plant_Selection[i].GetComponent<Image>().sprite = tempSprite;
                continue;
            }
            List_Of_Plant_Selection[i].GetComponent<Image>().sprite = plantSelectionMenuData.EmptyImage;
        }
    }

    private Vector3 MouseLocationToWorld()
    {

        Vector3 mousePOS = Onlycamera.ScreenToWorldPoint(Input.mousePosition);
        mousePOS.z = 0;
        return mousePOS;
    }

    public static void ChangeToPlantPlacementState()
    {
        inputState = InputState.PlantPlacement;

    }

    private static void ChangeToFreeMovementState()
    {
        inputState = InputState.FreeMovement;

    }

    private void EnableInputOutLine()
    {
        HoriInputRenderer.color = Transparent_Color;
        VertiInputRenderer.color = Transparent_Color;
        InputOutLineIsEnabled = true;
    }

    private void DisableInputOutLine()
    {
        Color tempcolor = new Color(HoriInputRenderer.color.r, HoriInputRenderer.color.g, HoriInputRenderer.color.b, 0);
        HoriInputRenderer.color = tempcolor;
        VertiInputRenderer.color = tempcolor;
        InputOutLineIsEnabled = false;
    }

    private void PlantInput()
    {
        Vector3 MousePOS = MouseLocationToWorld();

        for (int i =0;i<rowLimits.Length ;i++)
        {
            if (i==0&& (MousePOS.y > rowLimits[i]))
            {
                InputOutlinePOS.y = 0;
                break;
            }

            if (i == rowLimits.Length - 1 &&(MousePOS.y<rowLimits[i]))
            {
                InputOutlinePOS.y = rowLimits.Length;
                break;
            }

            if ((i< rowLimits.Length) &&MousePOS.y < rowLimits[i]&& MousePOS.y > rowLimits[i+1])
            {
                InputOutlinePOS.y = i+1;
                break;
            }
        }

        for (int i =0;i<collumnLimits.Length ;i++)
        {
            
            if (i == 0 && (MousePOS.x < collumnLimits[i]))
            {
                InputOutlinePOS.x = 0;
                break;
            }

            if (i == collumnLimits.Length - 1 && (MousePOS.x > collumnLimits[i]))
            {
                InputOutlinePOS.x = collumnLimits.Length;
                break;
            }

            if ((i< collumnLimits.Length - 1) &&MousePOS.x > collumnLimits[i] && MousePOS.x < collumnLimits[i + 1])
            {
                InputOutlinePOS.x = i+1;
                break;
            }
        }

        HoriInputTransform.position = new Vector3(HoriInputTransform.position.x, RowInputOutLinePOS[(int)InputOutlinePOS.y], 0F);

        VertiInputTransform.position = new Vector3(CollumnInputOutLinePOS[(int)InputOutlinePOS.x], VertiInputTransform.position.y, 0F);

    }
    
}
