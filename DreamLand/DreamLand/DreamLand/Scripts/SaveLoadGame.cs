﻿using DreamLand.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


namespace DreamLand.Scripts
{
    class SaveLoadGame
    {
        //Player _player;
        //StorageDevice device;
        //string containerName = "MyGamesStorage";
        //string filename = "mysave.sav";
        //[Serializable]
        //public struct SaveGame
        //{
        //    public Vector2 PlayerPosition;
        //}


        ////Save Game
        //private void InitiateSave()
        //{
        //    if (!Guide.IsVisible)
        //    {
        //        device = null;
        //        StorageDevice.BeginShowSelector(PlayerIndex.One, this.SaveToDevice, null);
        //    }
        //}

        //void SaveToDevice(IAsyncResult result)
        //{
        //    device = StorageDevice.EndShowSelector(result);
        //    if (device != null && device.IsConnected)
        //    {
        //        SaveGame SaveData = new SaveGame()
        //        {
        //            PlayerPosition = _player.Position,
        //        };
        //        IAsyncResult r = device.BeginOpenContainer(containerName, null, null);
        //        result.AsyncWaitHandle.WaitOne();
        //        StorageContainer container = device.EndOpenContainer(r);
        //        if (container.FileExists(filename))
        //            container.DeleteFile(filename);
        //        Stream stream = container.CreateFile(filename);
        //        XmlSerializer serializer = new XmlSerializer(typeof(SaveGame));
        //        serializer.Serialize(stream, SaveData);
        //        stream.Close();
        //        container.Dispose();
        //        result.AsyncWaitHandle.Close();
        //    }
        //}

        //public Player Player
        //{
        //    get { return _player; }
        //    set { _player = value; }
        //}


        //  //Load Game
        //private void InitiateLoad()  
        //{
        //    if (!Guide.IsVisible)
        //    {
        //        device = null;
        //        StorageDevice.BeginShowSelector(PlayerIndex.One, this.LoadFromDevice, null);
        //    }
        //}


      
        //void LoadFromDevice(IAsyncResult result)
        //{
        //    device = StorageDevice.EndShowSelector(result);
        //    IAsyncResult r = device.BeginOpenContainer(containerName, null, null);
        //    result.AsyncWaitHandle.WaitOne();
        //    StorageContainer container = device.EndOpenContainer(r);
        //    result.AsyncWaitHandle.Close();
        //    if (container.FileExists(filename))
        //    {
        //        Stream stream = container.OpenFile(filename, FileMode.Open);
        //        XmlSerializer serializer = new XmlSerializer(typeof(SaveGame));
        //        SaveGame SaveData = (SaveGame)serializer.Deserialize(stream);
        //        stream.Close();
        //        container.Dispose();
        //        //Update the game based on the save game file
        //        _player.Position = SaveData.PlayerPosition;
        //    }
        //}
    }
}
