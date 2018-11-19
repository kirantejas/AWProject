using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public  class  ApiRequest : MonoBehaviour
    {
        #region Variables
        private readonly string url = "http://ramesh8856.pythonanywhere.com/";
        #endregion

        #region custom methods
        public void MakeRequest(int UserId, int Level, int BtnId, int IsExercise)
        {
            StartCoroutine(MakeApiRequest(globalClass.Id, 0, 1, 0));
            
        }
        #endregion

        #region Couroutiune
       
        IEnumerator MakeApiRequest(int UserId, int Level, int BtnId, int IsExercise)
        {
            
            
                WWWForm Form = new WWWForm();
                Form.AddField("user_id", UserId);
                Form.AddField("level", Level);
                Form.AddField("btn_id", BtnId);
                Form.AddField("is_exercise", IsExercise);
                WWW CreateAccountWww = new WWW(url+"btnclicks", Form);
                yield return CreateAccountWww;

                if (CreateAccountWww.error != null)
                {
                    Debug.LogError("Cannot connect to Account creation");
                }
                else
                {
                    string CreateAccountReturn = CreateAccountWww.text;
                    if (CreateAccountReturn == "success")
                    {
                        Debug.Log("Success: Btn log entry");
                        
                    }
                }
            
        }
        #endregion


    }
}
