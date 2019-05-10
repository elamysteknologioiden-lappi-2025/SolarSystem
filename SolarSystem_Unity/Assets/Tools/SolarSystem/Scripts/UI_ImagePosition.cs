/******************************************************************************
* File         : UI_ImagePosition.cs
* Authors      : Aleksi Juopperi (aleksi.juopperi2@edu.lapinamk.fi)
* Lisence      : MIT Licence
* Copyright    : Lapland University of Applied Sciences
* 
 * MIT License
* 
 * Copyright (c) 2019 Lapland University of Applied Sciences
* 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
 * The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// UI_ImagePosition
/// </summary>
public class UI_ImagePosition : MonoBehaviour
{
    #region // SerializeField

    /// <summary>
    /// targetCamera
    /// </summary>
    [SerializeField] private Camera targetCamera;

    /// <summary>
    /// target
    /// </summary>
    [SerializeField] private Transform target;

    /// <summary>
    /// speed
    /// </summary>
    [SerializeField] private float speed;

    #endregion

    #region // Private Attributes

    #endregion

    #region // Public Attributes

    #endregion

    #region // Protected Attributes

    #endregion

    #region // Set/Get

    #endregion

    #region // Base Class Methods
    #endregion

    #region // Private Methods
    #endregion

    #region // Public Methods

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        transform.LookAt(transform.position + targetCamera.transform.rotation * Vector3.forward,
        targetCamera.transform.rotation * Vector3.up);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (transform.position.y < 1) {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
    }
    #endregion

}
