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
        GameManager = new GameManager(GameDataCollection, Onlycamera);
    }

    // Update is called once per frame
    void Update()
    {
       GameManager.FakeUpdate();
    }

    private void FixedUpdate()
    {
        GameManager.FakeFixedUpdate();
    }

    public static void InputStateChangeToPlantPlacement()
    {
        GameManager.InputStateChangeToPlantPlacement();
    }

    

}
