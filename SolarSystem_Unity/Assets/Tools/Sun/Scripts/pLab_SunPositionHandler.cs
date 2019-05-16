/******************************************************************************
* File         : pLab_SunPositionHandler.cs
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
using System.Linq;
using System.Text;
using UnityEditor;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

/// <summary>
/// SunType
/// </summary>
public enum SunType {
    ENone = 0,
    ERealTime,
    EStart

};

/// <summary>
/// SunType
/// </summary>
public enum SunTime {
    ERealUTCTime = 0,
    ERealTime,
    EFixedTime

};
/// <summary>
/// SunPositionType
/// </summary>
public enum SunPositionType {
    EPreset = 0,
    EMapCentral,
    EPlayerPos
};

/// <summary>
/// pLab_SunPositionHandler
/// </summary>
public class pLab_SunPositionHandler : MonoBehaviour {

    #region // SerializeField

    /// <summary>
    /// timeType
    /// </summary>
    [SerializeField]
    private SunTime timeType;

    /// <summary>
    /// type
    /// </summary>
    [SerializeField]
    private SunType type;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private SunPositionType posType;

    /// <summary>
    /// lat
    /// </summary>
    [SerializeField]
    private double lat = 0;

    /// <summary>
    /// lon
    /// </summary>
    [SerializeField]
    private double lon = 0;

    /// <summary>
    /// interval
    /// </summary>
    [SerializeField]
    private int interval = 0;

    /// <summary>
    /// sun
    /// </summary>
    [SerializeField]
    private GameObject sun;

    /// <summary>
    /// year
    /// </summary>
    [SerializeField]
    private int year;

    /// <summary>
    /// month
    /// </summary>
    [SerializeField]
    private int month;

    /// <summary>
    /// day
    /// </summary>
    [SerializeField]
    private int day;


    /// <summary>
    /// hour
    /// </summary>
    [SerializeField]
    private int hour;

    /// <summary>
    /// min
    /// </summary>
    [SerializeField]
    private int min;


    #endregion

    #region // Private Attributes


    /// <summary>
    /// 
    /// </summary>
    private pLab_SunCalc sunCalc;

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



    /// <summary>
    /// Start
    /// </summary>
    void Start() {
        sunCalc = new pLab_SunCalc();


        switch (type) {
            case SunType.ENone: {
                    break;
                }
            case SunType.ERealTime: {
                    InvokeRepeating("UpdateSunPosition", 0, interval);
                    break;
                }
            case SunType.EStart: {
                    this.UpdateSunPosition();
                    break;
                }
            default: {
                    break;
                }
        }
    }


    #endregion

    #region // Private Methods


    /// <summary>
    /// UpdateSunPosition
    /// </summary>
    private void UpdateSunPosition() {

        double azi;
        double alt;

        DateTime dateTime = DateTime.UtcNow;

        if (timeType == SunTime.ERealTime) {
            dateTime = DateTime.UtcNow;
        } else if (timeType == SunTime.EFixedTime) {
            dateTime = new DateTime(year, month, day, hour, min, 0);
        }

        sunCalc.GetPosition(dateTime, lat, lon, out azi, out alt);

        Vector3 rot = sun.transform.eulerAngles;
        rot.y = (float)azi;
        rot.x = (float)alt;
        sun.transform.eulerAngles = rot;
    }
    #endregion

    #region // Public Methods


    /// <summary>
    /// Open
    /// </summary>
    /// <returns></returns>
    public pLab_SunPositionData Open() {
#if UNITY_EDITOR //Editor only tag
        pLab_SunPositionData asset = AssetDatabase.LoadAssetAtPath("Assets/SUNPosition_" + EditorSceneManager.GetActiveScene().name + ".asset", typeof(pLab_SunPositionData)) as pLab_SunPositionData;
        if (asset == null) {
            asset = Create();
        }
        if (asset == null) {
            return null;
        }
        return asset;
#endif
        return null;
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <returns></returns>
    public pLab_SunPositionData Create() {
#if UNITY_EDITOR //Editor only tag
        string scene = EditorSceneManager.GetActiveScene().name;
        pLab_SunPositionData asset = ScriptableObject.CreateInstance<pLab_SunPositionData>();
        AssetDatabase.CreateAsset(asset, "Assets/SUNPosition_" + scene + ".asset");
        AssetDatabase.SaveAssets();
        return asset;
#endif
        return null;
    }

    /// <summary>
    /// SaveOSMEditorData
    /// </summary>
    public void SaveSunEditorData() {
#if UNITY_EDITOR
        AssetDatabase.SaveAssets();
#endif
    }

    #endregion

}

