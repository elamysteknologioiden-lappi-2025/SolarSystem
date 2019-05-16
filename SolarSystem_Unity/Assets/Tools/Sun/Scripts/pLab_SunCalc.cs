/******************************************************************************
* File         : pLab_SunCalc.cs
* Authors      : Toni Westerlund (toni.westerlund@lapinamk.fi),
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// pLab_SunCalc
/// </summary>
public class pLab_SunCalc  {


    #region // SerializeField
    #endregion

    #region // Private Attributes

    /// <summary>
    /// rad
    /// </summary>
    private const double rad = Math.PI / 180;

    /// <summary>
    /// dayMs
    /// </summary>
    private const double dayMs = 1000 * 60 * 60 * 24;

    /// <summary>
    /// J1970
    /// </summary>
    private const double J1970 = 2440588;

    /// <summary>
    /// J2000
    /// </summary>
    private const double J2000 = 2451545;

    /// <summary>
    /// e
    /// </summary>
    private const double e = (Math.PI / 180) * 23.4397;

    #endregion

    #region // Class Attributes

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
    /// GetPosition
    /// </summary>
    /// <param name="aTime"></param>
    /// <param name="aLat"></param>
    /// <param name="aLon"></param>
    /// <param name="aAzimuth"></param>
    /// <param name="aAltitude"></param>
    public void GetPosition(DateTime aTime, double aLat, double aLon, out double aAzimuth, out double aAltitude) {
        double phi = rad * aLat;
        DateTime startDt = new DateTime(1970, 1, 1);
        TimeSpan timeSpan = aTime - startDt;
        double d = (((double)timeSpan.TotalMilliseconds) / dayMs - 0.5 + J1970) - J2000;
        double M = rad * (357.5291 + 0.98560028 * d);
        double L = M + (rad * (1.9148 * Math.Sin(M) + 0.02 * Math.Sin(2 * M) + 0.0003 * Math.Sin(3 * M))) + (rad * 102.9372) + Math.PI;
        double a = (Math.Asin(Math.Sin(0) * Math.Cos(e) + Math.Cos(0) * Math.Sin(e) * Math.Sin(L)));
        double b = (Math.Atan2(Math.Sin(L) * Math.Cos(e) - Math.Tan(0) * Math.Sin(e), Math.Cos(L)));
        double H = (rad * (280.16 + 360.9856235 * d) - (rad * -aLon)) - b;
        aAzimuth = (Math.Atan2(Math.Sin(H), Math.Cos(H) * Math.Sin(phi) - Math.Tan(a) * Math.Cos(phi))) * 180 / Math.PI;
        aAltitude = Math.Asin(Math.Sin(phi) * Math.Sin(a) + Math.Cos(phi) * Math.Cos(a) * Math.Cos(H)) * 180 / Math.PI;
    }
    #endregion
}
