using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveData.Core
{
    public static class DataSaver
    {
        /// <summary>
        /// Save your data by file name.
        /// Use this if you need different saves of one type.
        /// </summary>
        /// <param name="_data"> Data to save </param>
        /// <param name="_saveFileName"> File name </param>
        public static void SaveData<T>(T _data, string _saveFileName)
        {
            WriteInFile(_data, _saveFileName);
        }

        /// <summary>
        /// Save data in file with name data class.
        /// Use this if you need only one save file of this type.
        /// </summary>
        /// <param name="_data"> Data to save </param>
        /// <typeparam name="T"> Type of data </typeparam>
        public static void SaveData<T>(T _data)
        {
            WriteInFile(_data, typeof(T).Name);
        }

        /// <summary>
        /// Write your data in file.
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_saveFileName"></param>
        private static void WriteInFile<T>(T _data, string _saveFileName)
        {
            BinaryFormatter _binaryFormatter = new BinaryFormatter();

            string _filePath = Application.persistentDataPath + _saveFileName;

            FileStream _stream = new FileStream(_filePath, FileMode.Create);

            _binaryFormatter.Serialize(_stream, _data);
            _stream.Close();
        }
    }
}