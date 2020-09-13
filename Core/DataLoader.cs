using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveData.Core
{
    public static class DataLoader
    {
        /// <summary>
        /// Load data by file name and type.
        /// </summary>
        /// <param name="_saveFileName"> File name. </param>
        /// <typeparam name="T"> Data type. </typeparam>
        /// <returns> Returns loaded data or creates new default. </returns>
        public static T GetData<T>(string _saveFileName)
        {
            if (TryLoadData(_saveFileName, out T _data))
                return _data;

            return CreateDefaultInstance<T>();
        }

        /// <summary>
        /// Load data by its type name.
        /// </summary>
        /// <typeparam name="T"> Data type. </typeparam>
        /// <returns> Returns loaded data or creates new default. </returns>
        public static T GetData<T>()
        {
            if (TryLoadData(typeof(T).Name, out T _data))
                return _data;

            return CreateDefaultInstance<T>();
        }
        
        /// <summary>
        /// Try load data by file name and type.
        /// </summary>
        /// <param name="_saveFileName"> Name of save file. </param>
        /// <param name="_data"> Out data. </param>
        /// <typeparam name="T"> Data type </typeparam>
        /// <returns> Returns true if data if found or false if not. </returns>
        private static bool TryLoadData<T>(string _saveFileName, out T _data)
        {
            string _path = Application.persistentDataPath + _saveFileName;

            _data = default;

            if (File.Exists(_path) == false)
                return false;

            BinaryFormatter _binaryFormatter = new BinaryFormatter();
            FileStream _stream = new FileStream(_path, FileMode.Open);
            _data = (T) _binaryFormatter.Deserialize(_stream);
            _stream.Close();

            return true;
        }

        /// <summary>
        /// Creates default instance of data type.
        /// </summary>
        /// <typeparam name="T"> Data type. </typeparam>
        /// <returns> Returns created data. </returns>
        private static T CreateDefaultInstance<T>()
        {
            T _newData = Activator.CreateInstance<T>();
            DataSaver.SaveData(_newData);
            return _newData;
        }
    }
}