using SaveData.Core;
using UnityEngine;

namespace SaveData.Example
{
    public class Example : MonoBehaviour
    {
        private void Start()
        {
            CheckData _data = DataLoader.GetData<CheckData>();

            Debug.Log(_data.a);
            
            _data.a++;

            DataSaver.SaveData(_data);
        }
    }
}