/******************************************************************************
* File         : UI_buttonScript.cs
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
using UnityEngine.UI;

public class UI_buttonScript : MonoBehaviour
{

    #region // SerializeField

    /// <summary>
    /// text
    /// </summary>
    [SerializeField] private Text text = null;

    #endregion

    #region // Private Attributes

    /// <summary>
    /// state
    /// </summary>
    private bool state = false;

    #endregion

    #region // Public Attributes

    #endregion

    #region // Protected Attributes

    #endregion

    #region // Set/Get

    #endregion

    #region // Base Class Methods

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        text.text = "Pois";
    }

    #endregion

    #region // Private Methods
    #endregion

    #region // Public Methods

    /// <summary>
    /// ButtonClicked
    /// </summary>
    public void ButtonClicked() {
        state = !state;
        text.text = (state) ? "Päällä" : "Pois";
    }

    #endregion
}
