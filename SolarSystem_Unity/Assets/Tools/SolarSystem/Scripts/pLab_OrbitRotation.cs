/******************************************************************************
* File         : pLab_OrbitRotation.cs
* Authors      : Toni Westerlund (toni.westerlund@lapinamk.fi)
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
using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// pLab_OrbitRotation
/// </summary>
public class pLab_OrbitRotation : MonoBehaviour {


    #region // SerializeField

    /// <summary>
    /// Right ascension is the celestial equivalent of terrestrial longitude
    /// </summary>
    [SerializeField] float rightAscension = 0.0f;

    /// <summary>
    /// Declination in astronomy is comparable to geographic latitude, projected onto the celestial sphere
    /// </summary>
    [SerializeField] float declination = 0.0f;

    /// <summary>
    /// perioid
    /// </summary>
    [SerializeField] double period = 10.0;
    #endregion

    #region // Private Attributes

    /// <summary>
    /// timeScale, TODO use Global value
    /// </summary>
    private double timeScale = 1.0;

    /// <summary>
    /// Planet axis
    /// </summary>
    private Quaternion axis;

    /// <summary>
    /// Rate
    /// </summary>
    private double rate;

    /// <summary>
    /// Angle
    /// </summary>
    private double angle;



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
    #endregion

    /// <summary>
    /// WrapAngle
    /// </summary>
    /// <param name="aAngle"></param>
    /// <param name="aLower"></param>
    /// <param name="aUpper"></param>
    /// <returns></returns>
    public static double AngleFix(double aAngle, double aLower, double aUpper) {
        if (aAngle > aLower && aAngle < aUpper) {
            return aAngle;
        } else if (aAngle < aLower) {
            return aUpper - (aLower - aAngle) % (aUpper - aLower);
        } else {
            return aLower + (aAngle - aLower) % (aUpper - aLower);
        }
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable() {
        axis = Quaternion.Euler(declination, rightAscension, 0f);
        // rate = Math.Abs((-Math.PI - Math.PI) / period);
        rate = ((Mathf.PI * 2) / ((60 * 60 * 24 * period)) * 60 * 60 * 24 * pLab_TimeScale.timeScale);
        transform.localRotation = axis * Quaternion.Euler(0f, -(float)angle / Mathf.Deg2Rad, 0f);
    }


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
	void Update() {
        rate = ((Mathf.PI * 2) / ((60 * 60 * 24 * period)) * 60 * 60 * 24 * pLab_TimeScale.timeScale);
        angle = AngleFix(angle + Time.deltaTime * rate * timeScale, 0, 2 * Math.PI);
        transform.localRotation = axis * Quaternion.Euler(0f, -(float)angle / Mathf.Deg2Rad, 0f); ;
    }
}
