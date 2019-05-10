/******************************************************************************
* File         : MoveCamera.cs
* Authors      : Toni Westerlund (toni.westerlund@lapinamk.fi),
*                Aleksi Juopperi (aleksi.juopperi2@edu.lapinamk.fi)
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
/// MoveCamera
/// </summary>
public class MoveCamera : MonoBehaviour{
    #region // SerializeField

    /// <summary>
    /// camTransform
    /// </summary>
    [SerializeField] private Transform camTransform;




    /// <summary>
    /// camTransform
    /// </summary>
    [SerializeField] private Transform camRigTransform;

    /// <summary>
    /// Camera Speed
    /// </summary>
    [SerializeField] private float cameraSpeed = 1;

    #endregion

    #region // Private Attributes

    /// <summary>
    /// Move Vector
    /// </summary>
    private Vector3 moveVector;

    /// <summary>
    /// Pan Vector
    /// </summary>
    private Vector3 panVector;


    private float axisValue = 0;
    #endregion

    #region // Public Attributes

    #endregion

    #region // Protected Attributes

    #endregion

    #region // Set/Get

    #endregion

    #region // Base Class Methods

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled
    /// </summary>
    void Update() {
        transform.Translate(moveVector * cameraSpeed * Time.deltaTime);
        transform.Translate(panVector * cameraSpeed * Time.deltaTime);
        camRigTransform.Rotate(Vector3.up, axisValue);
        // transform.RotateAround(camTransform.position,Vector3.up, axisValue);
    }
    #endregion

    #region // Private Methods
    #endregion

    #region // Public Methods

    /// <summary>
    /// GoUpPressed
    /// </summary>
    public void GoUpPressed() {
        panVector.y = -1;
    }

    /// <summary>
    /// GoDownPressed
    /// </summary>
    public void GoDownPressed() {
        panVector.y = 1;
    }

    /// <summary>
    /// GoUpReleased
    /// </summary>
    public void GoUpReleased() {
        panVector.y = 0;
    }

    /// <summary>
    /// GoDownReleased
    /// </summary>
    public void GoDownReleased() {
        panVector.y = 0;
    }

    /// <summary>
    /// TouchChange
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    public void TouchChange(object o, VRTK.ControllerInteractionEventArgs e) {
        Vector3 forwardVector = camTransform.forward * e.touchpadAxis.y;
        Vector3 sideVector = camTransform.right * e.touchpadAxis.x;
        moveVector = forwardVector + sideVector;


    }

    /// <summary>
    /// TouchChange
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    public void TouchChangeLeft(object o, VRTK.ControllerInteractionEventArgs e) {

        axisValue = e.touchpadAxis.x * 0.1f;

    }

    public void TouchEndLeft(object o, VRTK.ControllerInteractionEventArgs e) {

        axisValue = e.touchpadAxis.x * 0.0f;

    }

    /// <summary>
    /// TouchEnd
    /// </summary>
    public void TouchEnd() {
        moveVector = Vector3.zero;
    }

    #endregion

}
