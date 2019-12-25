﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Shark
{
    public class SharkVisionControl : MonoBehaviour
    {
        public static Camera cam;
        public static bool active
        {
            get
            {
                Vehicle vehicle = Player.main.GetVehicle();
                if(!vehicle)
                {
                    return false;
                }

                if(vehicle.GetType() != typeof(Shark))
                {
                    return false;
                }

                return _enabled;
            }
        }

        public static bool _enabled;

        public void Awake()
        {
            if(!cam)
            {
                Camera newCam = new GameObject("wallcam").AddComponent<Camera>();
                newCam.transform.parent = SNCameraRoot.main.mainCam.transform;
                newCam.transform.localPosition = Vector3.zero;
                newCam.transform.localEulerAngles = Vector3.zero;
                newCam.clearFlags = CameraClearFlags.Depth;
                newCam.depth = 1;
                newCam.cullingMask = 8388608;
                cam = newCam;
            }
        }

        public void Update()
        {
            cam.fieldOfView = SNCameraRoot.main.mainCam.fieldOfView;
        }
    }
}
