using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Linq;

namespace HApi.Storage {
    public class DataStorage<TEntity> : IDataStorage<TEntity> {
        private HashSet<TEntity> Entities;
        private readonly string DataPath;

        private object fileLock = new object();
        public DataStorage()
        {
            string clsName = typeof(TEntity).FullName;
            DataPath = string.Concat(clsName, ".bin");

            Entities = ReadData();

            if(Entities == null)
                Entities = new HashSet<TEntity>();
        }
        public void SaveToDisk()
        {
            lock (fileLock)
            {
                if (!File.Exists(DataPath))
                    File.Create(DataPath);

                using (Stream stream = File.OpenWrite(DataPath))
                {
                    var binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(stream, Entities);
                    stream.Close();
                }
            }
        }

        public HashSet<TEntity> ReadData(){
            lock (fileLock)
            {
                HashSet<TEntity> ret = null;

                if (!File.Exists(DataPath))
                    File.Create(DataPath);

                // Read the contents of the file into memory
                using (Stream stream = File.OpenRead(DataPath))
                {
                    if (stream.Length == 0)
                        return new HashSet<TEntity>();

                    var binaryFormatter = new BinaryFormatter();

                    ret = (HashSet<TEntity>)binaryFormatter.Deserialize(stream);
                }

                return ret;
            }
        }

        public TEntity Find(Func<TEntity, bool> predicate)
        {
            return Entities.FirstOrDefault(predicate);
        }

        public bool Contains(TEntity entity)
        {
            return Entities.Contains(entity);
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }
    }
}