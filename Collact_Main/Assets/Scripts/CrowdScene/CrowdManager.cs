using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EIDTOR
#endif

public class CrowdManager : MonoBehaviour
{
    public GameObject manPrefab;

    private List<GameObject> mans;
    private Transform manTransform;
    private CreateController manCreateController;
    private WalkingController manWalkingController;

    private createCrowed maker;



    private int pooledAmount =3;

    void Start()
    {
        mans = new List<GameObject>();
        maker = manPrefab.GetComponent<createCrowed>();

        for (int i = 0; i < pooledAmount; i++) {
            GameObject man = Instantiate(maker.CreatCrowdCharacter(i,(i%7)+1,0.5f,(i%10)));

            // maker.CreatCrowdCharacter(i,(i%7) + 1,0.5f,(i%10));
            manTransform = man.GetComponent<Transform>();
            manWalkingController = man.GetComponent<WalkingController>();
            manTransform.SetParent(this.transform);
            
            int ranX, ranZ;
            ranX = Random.Range(0, 10);
            ranZ = Random.Range(0, 10);
            manTransform.position = new Vector3(ranX, 0, ranZ - 5);
            // manTransform.position = new Vector3(0, 0, -5);
            manTransform.rotation = Quaternion.Euler(manTransform.up * Random.Range(0, 359));

            manWalkingController.moveSpeed = Random.Range(1, 3) * 1f;
            manWalkingController.rotSpeed = Random.Range(50, 100) * 1f;
            // manCreateController.field = (i % 7) + 1;
            // manCreateController.create((i % 7) + 1);
            // manCreateController.changeJacketColor();
            // manCreateController.createAcc((i % 10));
        
        }
    }

    
}
