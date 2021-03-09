# SaveData
Easy manage of save data in unity. Create your own data types and load/save it in one line of code.

Quick guide:

1. Create data type. Dont forget to make class serializable!
```csharp
[Serializable]
   public class CheckData
   {
       public int a;

       public CheckData()
       {
           a = 0;
       }
   }
```

2. Create data and save it.
```csharp
CheckData _data = new CheckData();
_data.a = 128;

// You can save data with default name of its type
// if you need only one save file of this file.

DataSaver.SaveData(_data);

// Or you can save data by file name and handle different save files.

DataSaver.SaveData(_data, "fileName");
```

3. Load data
```csharp
DataLoader.GetData<CheckData>();

// Or if you save files by name

DataLoader.GetData<CheckData>("fileName");
```
