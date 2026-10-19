using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class InOutPortalRender : MonoBehaviour
{
    public Material[] inPortalMaterials;
    public Material[] outPortalMaterials;

    private void Awake()
    {
        foreach (var m in inPortalMaterials)
        {
            m.SetFloat("_DisssolveAmount", 0);
        }

        foreach (var m in outPortalMaterials)
        {
            m.SetFloat("_DisssolveAmount", 1);
        }
    }

    public void OutPortal()
    {
        LeanTween.value(0, 1, 0.5f).setOnUpdate((float val) =>
          {
              foreach (var m in inPortalMaterials)
              {
                  m.SetFloat("_DisssolveAmount", val);
              }
          });

        LeanTween.value(1, 0, 0.5f).setOnUpdate((float val) =>
        {
            foreach (var m in outPortalMaterials)
            {
                m.SetFloat("_DisssolveAmount", val);
            }
        });

    }

    public void Disapper()
    {      

        LeanTween.value(0, 1, 1f).setOnUpdate((float val) =>
        {
            foreach (var m in outPortalMaterials)
            {
                m.SetFloat("_DisssolveAmount", val);
            }
        });

    }
}
