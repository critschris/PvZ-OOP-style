using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{

    [SerializeReference]
    GameData GameDataCollection;

    [SerializeField]
    Camera Onlycamera;

    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject BackGround = Instantiate(GameDataCollection.BackGround);
        GameObject HoriInput = Instantiate(GameDataCollection.HoriInputOutLine);
        GameObject VertiInput = Instantiate(GameDataCollection.VertiInputOutLine);
        
        GameManager = new GameManager(GameDataCollection,new GameObject[] { HoriInput,VertiInput, BackGround}, Onlycamera);
    }

    // Update is called once per frame
    void Update()
    {
       GameManager.FakeUpdate();
    }

    public static void InputStateChangeToPlantPlacement()
    {
        GameManager.InputStateChangeToPlantPlacement();
    }

    

}
