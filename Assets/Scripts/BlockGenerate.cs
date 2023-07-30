using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerate : MonoBehaviour
{
    [SerializeField] Transform PointA;
    [SerializeField] Transform PointB;
    [SerializeField] Transform Block;

    [SerializeField] Transform BlockFather;
    [SerializeField] float DistaceUp;

    [SerializeField] int Speed;
    public int Count;

    [SerializeField]GameObject Prefabs;
    [SerializeField]GameObject PrefabsTop;
    [SerializeField]GameObject PrefabsPreviewBlock;
    [SerializeField]GameObject PrefabsPreviewTop; 

    [SerializeField] bool Flag;
    [SerializeField] bool FlagChangeSkin;

    public GameObject ParentObject;

    public GameManager GM;


    void Start()
    {
        FlagChangeSkin = false;
        Flag = false;
        PrefabsPreviewTop.SetActive(false);
        Count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveGenerator();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateBlock();
        }
    }


    void MoveGenerator()
    {
        if (Flag == true){
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        } 

        if (Flag == false){
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        } 

         
        if (Block.position.x >= PointA.position.x) Flag = false;
        if (Block.position.x <= PointB.position.x) Flag = true;

        if(Count == 10)
        {
            PrefabsPreviewBlock.SetActive(false);
            PrefabsPreviewTop.SetActive(true);
            FlagChangeSkin = true;
        }

    }


    void GenerateBlock()
    {
        if(FlagChangeSkin == true)
        {
            Instantiate(PrefabsTop, Block.transform.position, Quaternion.Euler(new Vector3(-90f, 90f, 0f))).transform.parent = ParentObject.transform;
        }
        else
        {
            Instantiate(Prefabs, Block.transform.position, Quaternion.Euler(new Vector3(-90f, 90f, 0f))).transform.parent = ParentObject.transform;
        }

        BlockFather.position = new Vector3(BlockFather.position.x , BlockFather.position.y + DistaceUp, BlockFather.position.z);
    }
}
