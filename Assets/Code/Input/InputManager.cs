using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{

    RowAndColumnCoordinates rowandcolumns;
    Transform HoriInputTransform;
    Transform VertiInputTransform;
    SpriteRenderer HoriInputRenderer;
    SpriteRenderer VertiInputRenderer;

    float[] rowLimits;
    float[] collumnLimits;

    float[] RowInputOutLinePOS;
    float[] CollumnInputOutLinePOS;

    Vector2 InputOutlinePOS;

    Camera Onlycamera;

    static float aAmount= 0.227F;

    enum InputState {FreeMovement, PlantPlacement}
    static InputState inputState = InputState.FreeMovement;

    public InputManager(RowAndColumnCoordinates rowandcolumns, GameObject HoriInput,GameObject VertiInput, Camera camera)
    {
        this.rowandcolumns = rowandcolumns;
        camera = Onlycamera;
        HoriInputTransform = HoriInput.transform;
        VertiInputTransform = VertiInput.transform;
        HoriInputRenderer = HoriInput.GetComponentInChildren<SpriteRenderer>();
        VertiInputRenderer = VertiInput.GetComponentInChildren<SpriteRenderer>();

        rowLimits = rowandcolumns.PlantingInputRowLines;
        collumnLimits = rowandcolumns.PlantingInputCollumnLines;

        RowInputOutLinePOS = rowandcolumns.RowInputOutLinePOS;
        CollumnInputOutLinePOS = rowandcolumns.CollumnInputOutLinePOS;

    }

    public void FakeUpdate()
    {
        if (inputState==InputState.PlantPlacement)
        {
            EnableInputOutLine();
            PlantInput();


            if (Input.GetMouseButtonDown(0))
            {

                DisableInputOutLine();
                ChangeToFreeMovementState();
            }
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
        Color tempcolor = new Color(HoriInputRenderer.color.r, HoriInputRenderer.color.g, HoriInputRenderer.color.b,aAmount);
        HoriInputRenderer.color = tempcolor;
        VertiInputRenderer.color = tempcolor;
    }

    private void DisableInputOutLine()
    {
        Color tempcolor = new Color(HoriInputRenderer.color.r, HoriInputRenderer.color.g, HoriInputRenderer.color.b, 0);
        HoriInputRenderer.color = tempcolor;
        VertiInputRenderer.color = tempcolor;
    }

    private void OutLineCoordinateToTransform_xy_Setter()
    {
        HoriInputTransform.position = new Vector3(HoriInputTransform.position.x, RowInputOutLinePOS[(int)InputOutlinePOS.y],0F);
        VertiInputTransform.position = new Vector3(CollumnInputOutLinePOS[(int)InputOutlinePOS.x], VertiInputTransform.position.y, 0F);
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
                InputOutlinePOS.y = rowLimits.Length+1;
                break;
            }

            if (MousePOS.y < rowLimits[i]&& MousePOS.y > rowLimits[i+1])
            {
                InputOutlinePOS.y = i;
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

            if (i == rowLimits.Length - 1 && (MousePOS.x > collumnLimits[i]))
            {
                InputOutlinePOS.x = rowLimits.Length + 1;
                break;
            }

            if (MousePOS.x > rowLimits[i] && MousePOS.x < collumnLimits[i + 1])
            {
                InputOutlinePOS.x = i;
                break;
            }
        }

        OutLineCoordinateToTransform_xy_Setter();
    }
    
}
