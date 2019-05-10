/******************************************************************************
* File         : UI_Slider.cs
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
using UnityEngine.UI;

public class UI_Slider : MonoBehaviour
{

    #region // SerializeField

    /// <summary>
    /// objectTransform
    /// </summary>
    [SerializeField] private Transform objectTransform;

    #endregion

    #region // Private Attributes

    /// <summary>
    /// previousValue
    /// </summary>
    private float previousValue;

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
    /// OnSliderChanged
    /// </summary>
    /// <param name="value"></param>
    public void OnSliderChanged(float value) {

        float delta = value - this.previousValue;
        this.objectTransform.transform.Rotate(Vector3.up * delta * 360);
        this.previousValue = value;
    }

    #endregion





}
