//-----------------------------------------------------------------------
// <copyright file="SimpleARGUIController.cs" company="Google">
//
// Copyright 2016 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// GUI controls.
/// </summary>
public class SimpleARGUIController : MonoBehaviour
{

    public TangoPoseController m_poseController;

    public GameObject tangoController;

    public TangoPointCloud m_pointCloud;

    MenuScript menuScript;

    public Vector3 itemSpawnPos;

    public void Start()
    {
        menuScript = tangoController.GetComponent<MenuScript>();
        m_pointCloud = FindObjectOfType<TangoPointCloud>();
    }


    /// <summary>
    /// Update this instance.
    /// </summary>
    public void Update()
    {
        //if (m_poseController != null)
        //{
        //    m_poseController.m_clutchEnabled = Input.GetMouseButton(0);
        //}





        if (Input.touchCount == 1)
        {
            // Trigger place kitten function when single touch ended.
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    Debug.Log("Not on UI");
                    PlaceItem(t.position);
                }
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            // This is a fix for a lifecycle issue where calling
            // Application.Quit() here, and restarting the application
            // immediately results in a deadlocked app.
            AndroidHelper.AndroidQuit();
        }
    }



    void PlaceItem(Vector2 touchPosition)
    {
        // Find the plane.
        Camera cam = Camera.main;
        Vector3 planeCenter;
        Plane plane;
        if (!m_pointCloud.FindPlane(cam, touchPosition, out planeCenter, out plane))
        {
            Debug.Log("cannot find plane.");
            return;
        }

        // Place kitten on the surface, and make it always face the camera.
        if (Vector3.Angle(plane.normal, Vector3.up) < 30.0f)
        {
            Vector3 up = plane.normal;
            Vector3 right = Vector3.Cross(plane.normal, cam.transform.forward).normalized;
            Vector3 forward = Vector3.Cross(right, plane.normal).normalized;
            GameObject temp = menuScript.currentItem;
            if (temp == null)
            {
                Debug.Log("Item not found.");
            }
            else
            {
                GameObject tempGameObject = Instantiate(menuScript.currentItem, planeCenter, Quaternion.LookRotation(forward, up));
                itemSpawnPos = planeCenter;
                menuScript.currentItem = null;
                //tempGameObject.c
            }
        }
        else
        {
            Debug.Log("surface is too steep for Object to stand on.");
        }
    }
}
