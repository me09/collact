using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public CreateViewManager createViewManager;
    public GameObject crowdView;

    private Transform crowdViewTransform;
    private CrowdManager crowdManager;

    void Awake() {
        crowdViewTransform = crowdView.GetComponent<Transform>();
        crowdManager = crowdView.GetComponent<CrowdManager>();
    }

    public void setToCrowdView() {
        crowdManager.addCrowd(createViewManager.getCurrentCreatedCharacter());
        createViewManager.getCurrentCreatedCharacter().GetComponent<Transform>().SetParent(crowdViewTransform);
    }
}
