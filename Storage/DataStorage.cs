using System.IO;
using System.Collections.Generic;

namespace HApi.Storage {
    public class DataStorage<TEntity> {
        private HashSet<TEntity> Entities;
        private readonly string DataPath;
        public DataStorage()
        {
            string clsName = typeof(TEntity).FullName;
            DataPath = string.Concat(clsName, ".bin");

            byte[] data = ReadData();

            Entities = new HashSet<TEntity>(new IEqualityComparer<TEntity>());
        }
        public SaveChanges();

        public byte[] ReadData(){
            // Read the contents of the file into memory
            if(!File.Exists(binFile))
                File.Create(binFile);

            var fStream = File.OpenRead(binFile);
            byte[] data;
            fStream.Read(data, 0, fStream.Length);
            fStream.Close();
        }
    }
}