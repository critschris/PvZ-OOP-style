using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager 
{

    GameObject BackGround;
    SpriteRenderer BGSprite;

    int InitialWait = 20;
    float waveCounter = 0;
    float waveWaitTime;
    bool SpawnEnemies = false;

    MapData mapData;
    public MapManager(MapData mapData,GameObject BackGround)
    {
        
        this.mapData = mapData;

        this.BackGround = Object.Instantiate(BackGround);
        BGSprite = BackGround.GetComponentInChildren<SpriteRenderer>();

        BackGroundSetUp();

    }

    public void FakeUpdate()
    {
        if (SpawnEnemies)
        {
            //Spawn enemies
        }
        else
        {
            waveCounter = IncrementTimeCounter(waveCounter);
            SpawnEnemies = (waveCounter>=waveWaitTime);
        }
    }

    private float IncrementTimeCounter(float a)
    {
        return a+=Time.fixedDeltaTime;
    }

    private void BackGroundSetUp()
    {
        BGSprite.sprite = mapData.BackGroundMap;
        waveWaitTime = InitialWait;
    }
}
