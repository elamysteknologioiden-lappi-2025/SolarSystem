/******************************************************************************
* File         : pLab_Orbit.cs
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
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;


// Matematic Sources:
// http://www.bogan.ca/orbits/kepler/orbteqtn.html
// https://en.wikipedia.org/wiki/Orbital_inclination


/// <summary>
/// pLab_Orbit
/// </summary>
public class pLab_Orbit : MonoBehaviour {

    #region // SerializeField

    /// <summary>
    /// periapsis — nearest point to the Sun
    /// distance astronomic Unit
    /// </summary>
    [SerializeField] private double periapsis = 1.0;


    /// <summary>
    /// period
    /// </summary>
    [SerializeField] private double period = 10.0;

    /// <summary>
    /// Eccentricity is a measure of how an orbit deviates from circular
    /// </summary>
    [SerializeField] private double eccentricity = 0.1;

    /// <summary>
    /// longitude of perihelion
    /// </summary>
    [SerializeField] private float longitudeOfPerihelion = 0.0f;

    /// <summary>
    /// longitude Of Ascending
    /// </summary>
    [SerializeField] private float longitudeOfAscending = 0.0f;

    /// <summary>
    /// Inclination
    /// </summary>
    [SerializeField] private float inclination = 0.0f;

    #endregion

    #region // Private Attributes
    /// <summary>
    /// Rate
    /// </summary>
    private double rate;

    /// <summary>
    /// anomaly
    /// </summary>
    private double anomaly = 0;

    /// <summary>
    /// radius
    /// </summary>
    private double radius;

    private float globalScale = 10f;

    /// <summary>
    /// orientation
    /// </summary>
    Quaternion orientation;
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
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable() {
      //  Quaternion orientation = ComputeOrientation(argument, longitude, inclination);


        anomaly = ((anomaly % Mathf.PI * 2) + Mathf.PI * 2) % Mathf.PI * 2;
        orientation = Quaternion.Euler(inclination, -longitudeOfAscending, 0f) * Quaternion.Euler(0f, -longitudeOfPerihelion, 0f);
        rate = ((Mathf.PI * 2) / ((60 * 60 * 24 * period))*60*60*24 * pLab_TimeScale.timeScale);
        double eccentricAnomaly = KeplersEquation(anomaly, eccentricity);
        // https://en.wikipedia.org/wiki/True_anomaly
        double trueAnomaly = 2.0 * Math.Atan2(Math.Sqrt(1.0 + eccentricity) * Math.Sin(eccentricAnomaly / 2.0), Math.Sqrt(1.0 - eccentricity) * Math.Cos(eccentricAnomaly / 2.0));
        // l = a(1-e^2)
        double semiLatusRectum = periapsis * (1.0 - Math.Pow(eccentricity, 2))/(1.0- eccentricity);


        radius = semiLatusRectum / (1.0 + eccentricity * Math.Cos(trueAnomaly));
        transform.localRotation = orientation;
        // Compute position using by Unit Circle
        transform.localPosition = new Vector3((float)(radius * Math.Cos(trueAnomaly)), 0f, (float)(radius * Math.Sin(trueAnomaly))); ;
        LineRenderer lineRender = GetComponent<LineRenderer>();
        lineRender.positionCount = 201;
        for (int i = 0; i < 201; i++) {
            double tmpEccentricAnomaly = KeplersEquation((((Mathf.PI * 2) / 200f) * i), eccentricity);
            double tmpTrueAnomaly = 2.0 * Math.Atan2(Math.Sqrt(1.0 + eccentricity) * Math.Sin(tmpEccentricAnomaly / 2.0), Math.Sqrt(1.0 - eccentricity) * Math.Cos(tmpEccentricAnomaly / 2.0));
            double tmpRadius = semiLatusRectum / (1.0 + eccentricity * Math.Cos(tmpTrueAnomaly));
            // Compute points using by Unit Circle
            lineRender.SetPosition(i, orientation*new Vector3((float)(tmpRadius * Math.Cos(tmpTrueAnomaly))* globalScale, 0f, (float)(tmpRadius * Math.Sin(tmpTrueAnomaly))* globalScale));
        }
    }
    public static Quaternion ComputeOrientation(float o, float w, float i) {
        return Quaternion.Euler(i, -w, 0f) * Quaternion.Euler(0f, -o, 0f);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        rate = ((Mathf.PI * 2) / ((60 * 60 * 24 * period)) * 60 * 60 * 24 * pLab_TimeScale.timeScale) ;


        anomaly += Time.deltaTime * rate * 1;
        if (anomaly > Mathf.PI * 2){
            
            anomaly = anomaly % Mathf.PI * 2;
        }
        else if (anomaly < 0){
            anomaly = (anomaly % Mathf.PI * 2) + Mathf.PI * 2;
        }
        double eccentricAnomaly = KeplersEquation(anomaly, eccentricity);

        // https://en.wikipedia.org/wiki/True_anomaly
        double trueAnomaly = 2.0 * Math.Atan2(Math.Sqrt(1.0 + eccentricity) * Math.Sin(eccentricAnomaly / 2.0), Math.Sqrt(1.0 - eccentricity) * Math.Cos(eccentricAnomaly / 2.0));
        double semiLatusRectum = periapsis * (1.0 - Math.Pow(eccentricity, 2)) / (1.0 - eccentricity);
        double tmpRadius = semiLatusRectum / (1.0 + eccentricity * Math.Cos(trueAnomaly));
        // Compute position using by Unit Circle
        transform.localPosition = orientation * new Vector3((float)(tmpRadius * Math.Cos(trueAnomaly))* globalScale, 0f, (float)(tmpRadius * Math.Sin(trueAnomaly))* globalScale);
    }


    /// <summary>
    /// https://en.wikipedia.org/wiki/Kepler%27s_equation
    /// </summary>
    /// <param name="M"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    private double KeplersEquation(double aAnomaly, double aEccentricity) {
        double En = aAnomaly;
        double E = 0;
        for (int i = 0; i < 200; i++){

            // E = En - (En-esin(En) - M(t))%(1-ecos(En))
            E = En - (En - aEccentricity * Math.Sin(E) - aAnomaly) / (1.0 - aEccentricity * Math.Cos(E));
            if (Math.Abs(E - aEccentricity * Math.Sin(E) - aAnomaly) < 0.0001)
                return E;
            else
                En = E;
        }
        return E;
    }

}


