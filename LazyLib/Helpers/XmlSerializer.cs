﻿using System;
using System.IO;
using System.Xml.Serialization;

namespace LazyLib.Helpers
{
    public class XmlSerializer
    {
        public static T Deserialize<T>(string Path)
        {
            T local = Activator.CreateInstance<T>();
            try
            {
                FileStream stream = new FileStream(Path, FileMode.Open);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                local = (T)serializer.Deserialize(stream);
                stream.Close();
                return local;
            }
            catch (Exception)
            {
                return local;
            }
        }

        public static T DeserializeWithData<T>(string Data)
        {
            T local = Activator.CreateInstance<T>();
            try
            {
                StringReader textReader = new StringReader(Data);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(textReader);
            }
            catch (Exception)
            {
                return local;
            }
        }

        public static bool Serialize(string Path, object Object)
        {
            try
            {
                File.Delete(Path);
            }
            catch
            {
            }
            try
            {
                FileStream stream = new FileStream(Path, FileMode.Create);
                new System.Xml.Serialization.XmlSerializer(Object.GetType()).Serialize((Stream)stream, Object);
                stream.Close();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
            return false;
        }
    }
}
