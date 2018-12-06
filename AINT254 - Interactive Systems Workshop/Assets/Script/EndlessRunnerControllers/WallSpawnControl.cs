using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnControl : MonoBehaviour {
    public GameObject OrdinaryWall;
    public GameObject BounceyWall;
    public GameObject OneMoving;
    public GameObject TwoMoving;

    private float SpawningSpeed;
    private float SpawningDeacceleration;
    private Transform SpawnPos1;
    private Transform SpawnPos2;
    private Transform SpawnPos3;
    private Transform SpawnPos4;
    private int PreviousInt = 0;


    void Start()
    {
        SpawnPos1 = GameObject.Find("SpawnerLocation1").GetComponent<Transform>();
        SpawnPos2 = GameObject.Find("SpawnerLocation2").GetComponent<Transform>();
        SpawnPos3 = GameObject.Find("SpawnerLocation3").GetComponent<Transform>();
        SpawnPos4 = GameObject.Find("SpawnerLocation4").GetComponent<Transform>();
    }

    void Update()
    {
        if (CameraTransform.SpawnObstacles == true) {
            ChooseCombination();
            CameraTransform.SpawnObstacles = false;
        }
    }

    // Update is called once per frame
    void ChooseCombination() {
        //Random Number chooses the combinaton, call appropriate method to spawn objects
        int RandomInt = Random.Range(1, 14);
        if (RandomInt == PreviousInt) {
            ChooseCombination();
        }
        else
        {
            Invoke("Combination" + RandomInt, 0f);
        }

    }

    void Combination1() // - DONE
    {
        //Ordinary Wall in Pos1 & Pos4
        var Wall = Instantiate(OrdinaryWall,
            SpawnPos1.position,
            SpawnPos1.rotation);
        var Wall2 = Instantiate(OrdinaryWall,
            SpawnPos4.position,
            SpawnPos4.rotation);
    }
    void Combination2() // - DONE
    {
        //Ordinary Wall in Pos2 & Pos3
        var Wall = Instantiate(OrdinaryWall,
            SpawnPos2.position,
            SpawnPos2.rotation);
        var Wall2 = Instantiate(OrdinaryWall,
            SpawnPos3.position,
            SpawnPos3.rotation);
    }
    void Combination3() // - DONE
    {
        //Ordinary Wall in Pos1 & Pos3
        var Wall = Instantiate(OrdinaryWall,
            SpawnPos1.position,
            SpawnPos1.rotation);
        var Wall2 = Instantiate(OrdinaryWall,
            SpawnPos3.position,
            SpawnPos3.rotation);
    }
    void Combination4() // - DONE
    {
        //Ordinary Wall in Pos2 & Pos4
        var Wall = Instantiate(OrdinaryWall,
            SpawnPos2.position,
            SpawnPos2.rotation);
        var Wall2 = Instantiate(OrdinaryWall,
            SpawnPos4.position,
            SpawnPos4.rotation);
    }
    void Combination5()
    {
        //One Moving Wall in Pos1
        var Wall = Instantiate(OneMoving,
            SpawnPos1.position,
            SpawnPos1.rotation);
    }
    void Combination6()
    {
        //Two Moving Walls in Pos1
        var Wall = Instantiate(TwoMoving,
            SpawnPos1.position,
            SpawnPos1.rotation);
    }
    void Combination7()
    {
        //Ordinary Wall in Pos1 & Bouncey Wall in Pos4
        var Wall = Instantiate(OrdinaryWall,
            SpawnPos1.position,
            SpawnPos1.rotation);
        var Wall2 = Instantiate(BounceyWall,
            SpawnPos4.position,
            SpawnPos4.rotation);
    }
    void Combination8()
    {
        //Bouncey Wall in Pos1 & Ordinary Wall in Pos4
        var Wall = Instantiate(BounceyWall,
            SpawnPos1.position,
            SpawnPos1.rotation);
        var Wall2 = Instantiate(OrdinaryWall,
            SpawnPos4.position,
            SpawnPos4.rotation);
    }
    void Combination9()
    {
        //Ordinary Wall in Pos2 & Bouncey Wall in Pos3
        var Wall = Instantiate(OrdinaryWall,
            SpawnPos2.position,
            SpawnPos2.rotation);
        var Wall2 = Instantiate(BounceyWall,
            SpawnPos3.position,
            SpawnPos3.rotation);
    }
    void Combination10()
    {
        //Bouncey Wall in Pos2 & Ordinary Pos3
        var Wall = Instantiate(BounceyWall,
            SpawnPos2.position,
            SpawnPos2.rotation);
        var Wall2 = Instantiate(OrdinaryWall,
            SpawnPos3.position,
            SpawnPos3.rotation);
    }
    void Combination11()
    {
        //Ordinary Wall in Pos1 & Bouncey Wall in Pos3
        var Wall = Instantiate(OrdinaryWall,
            SpawnPos1.position,
            SpawnPos1.rotation);
        var Wall2 = Instantiate(BounceyWall,
            SpawnPos3.position,
            SpawnPos3.rotation);
    }
    void Combination12()
    {
        //Bouncey Wall in Pos1 & Ordinary Wall in Pos3
        var Wall = Instantiate(BounceyWall,
            SpawnPos1.position,
            SpawnPos1.rotation);
        var Wall2 = Instantiate(OrdinaryWall,
            SpawnPos3.position,
            SpawnPos3.rotation);
    }
    void Combination13()
    {
        //Ordinary Wall in Pos2 & Bouncey Wall in Pos4
        var Wall = Instantiate(OrdinaryWall,
            SpawnPos2.position,
            SpawnPos2.rotation);
        var Wall2 = Instantiate(BounceyWall,
            SpawnPos4.position,
            SpawnPos4.rotation);
    }
    void Combination14()
    {
        //Bouncey Wall in Pos2 & Ordinary Wall in Pos4
        var Wall = Instantiate(BounceyWall,
            SpawnPos2.position,
            SpawnPos2.rotation);
        var Wall2 = Instantiate(OrdinaryWall,
            SpawnPos4.position,
            SpawnPos4.rotation);
    }
}
