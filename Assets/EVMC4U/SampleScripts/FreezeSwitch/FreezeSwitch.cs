﻿/*
 * ExternalReceiver
 * https://sabowl.sakura.ne.jp/gpsnmeajp/
 *
 * MIT License
 * 
 * Copyright (c) 2019 gpsnmeajp
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
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EVMC4U
{
    public class FreezeSwitch : MonoBehaviour
    {
        public ExternalReceiver externalReceiver;
        public InputReceiver inputReceiver;

        public string Key= "スペース";
        public string Button= "ClickMenu";
        void Start()
        {
            inputReceiver.KeyInputAction.AddListener(OnKey);
            inputReceiver.ControllerInputAction.AddListener(OnCon);
        }
        void OnKey(KeyInput key)
        {
            Debug.Log("1");
            if (key.name == Key) {
                if (key.active == 1) {
                    externalReceiver.Freeze = !externalReceiver.Freeze;
                }
            }
        }
        void OnCon(ControllerInput con)
        {
            if (con.name == Button)
            {
                if (con.active == 1)
                {
                    externalReceiver.Freeze = !externalReceiver.Freeze;
                }
            }
        }
        void Update()
        {
            // スペース押下で姿勢固定
            if (Input.GetKey(KeyCode.Space))
            {
                externalReceiver.Freeze = !externalReceiver.Freeze;
            }
        }
    }
}
