using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveData.Core
{
    public static class DataLoader
    {
        public static T GetData<T>(string _saveFileName)
        {
            if (TryLoadData(_saveFileName, out T _data))
                return _data;

            T _newData = Activator.CreateInstance<T>();
            DataSaver.SaveData(_newData);
            return _newData;
        }

        public static T GetData<T>()
        {
            if (TryLoadData(typeof(T).Name, out T _data))
                return _data;

            T _newData = Activator.CreateInstance<T>();
            DataSaver.SaveData(_newData);
            return _newData;
        }

        private static bool TryLoadData<T>(string _name, out T _data)
        {
            string _path = Application.persistentDataPath + _name;

            _data = default;

            if (File.Exists(_path) == false)
                return false;

            BinaryFormatter _binaryFormatter = new BinaryFormatter();
            FileStream _stream = new FileStream(_path, FileMode.Open);
            _data = (T) _binaryFormatter.Deserialize(_stream);
            _stream.Close();

            return true;
        }
    }
}