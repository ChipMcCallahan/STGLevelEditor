using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using STG;

public class LevelDisplayer : MonoBehaviour
{
    public GameObject tile;

    // Start is called before the first frame update
    void Start()
    {
        var level = new Level();
        level.SizeX = 32;
        level.SizeY = 32;
        level.SizeZ = 1;
        for (int i = 0; i < level.SizeX; i++) {
            for (int j = 0; j < level.SizeY; j++) {
                level.Map[j * 32 + i] = new Cell();
                var id = ElemId.Wall;
                if (Random.Range(0, 2) == 1) {
                    id = ElemId.Floor;
                }
                level.Map[j * 32 + i].Terrain = new Element() {Id = id};
            }
        }
        for (int i = 0; i < level.SizeX; i++) {
            for (int j = 0; j < level.SizeY; j++) {
                var clone = Instantiate(
                    tile, 
                    new Vector3(i + 0.5f, j + 0.5f, 0), 
                    Quaternion.Euler(new Vector3(180, 0, 0)));
                var textureName = "wall";
                if (level.Map[j * 32 + i].Terrain.Id == ElemId.Floor){
                    textureName = "floor";
                }
                clone.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(textureName);
            }
        }

    }
}
