using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Er_ParallaxBackground : MonoBehaviour
{
    public Er_ParallaxCamera parallaxCamera;
    List<Er_ParallaxLayer> parallaxLayers = new List<Er_ParallaxLayer>();
  
   void Start()
   {
       if (parallaxCamera == null)
         parallaxCamera = Camera.main.GetComponent<Er_ParallaxCamera>();
       if (parallaxCamera != null)
         parallaxCamera.onCameraTranslate += Move;
       SetLayers();
   }
  
   void SetLayers()
   {
       parallaxLayers.Clear();
       for (int i = 0; i < transform.childCount; i++)
       {
           Er_ParallaxLayer layer = transform.GetChild(i).GetComponent<Er_ParallaxLayer>();
  
           if (layer != null)
           {
               layer.name = "Layer-" + i;
               parallaxLayers.Add(layer);
           }
       }
     }
     void Move(float delta)
     {
         foreach (Er_ParallaxLayer layer in parallaxLayers)
       {
           layer.Move(delta);
       }
   }
}
