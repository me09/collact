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
    private WalkingController manWalkingController;
    private CharacterSettingController manSettingController;

    private int pooledAmount = 100;

    void Start()
    {
        mans = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++) {
            GameObject man = Instantiate(manPrefab);

            manTransform = man.GetComponent<Transform>();
            manWalkingController = man.GetComponent<WalkingController>();
            manSettingController = man.GetComponent<CharacterSettingController>();
            manTransform.SetParent(this.transform);
            
            int ranX, ranZ;
            ranX = Random.Range(0, 10);
            ranZ = Random.Range(0, 10);
            manTransform.position = new Vector3(ranX, 0, ranZ - 5);
            manTransform.rotation = Quaternion.Euler(manTransform.up * Random.Range(0, 359));

            manWalkingController.moveSpeed = Random.Range(1, 3) * 1f;
            manWalkingController.rotSpeed = Random.Range(50, 100) * 1f;
            manSettingController.setCharacterAttribute((i % 7) + 1, Random.Range(0, 100) * 0.01f, (i % 10) + 1);
        }
    }

    
}
