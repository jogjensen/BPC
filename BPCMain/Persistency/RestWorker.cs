using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static BPCClassLibrary.Datastructures;

namespace BPCMain.Persistency
{
    class RestWorker
    {
        private const string URI = "https://bpc-rest.azurewebsites.net/api/";

        public async Task<IList<T>> GetAllObjectsAsync<T>(TableName tableName)// where T: class
        {
            string objectName = tableName.ToString();

            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(URI + objectName);
                IList<T> list = JsonConvert.DeserializeObject<IList<T>>(content);

                return list;
            }
        }

        public async Task<T> GetObjectFromIdAsync<T>(int id, TableName tableName)
        {
            string objectName = tableName.ToString();

            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(URI + objectName + "/" + id);
                T singleObject = JsonConvert.DeserializeObject<T>(content);
                return singleObject;
            }
        }

        public async Task<bool> CreateObjectAsync<T>(T newObject, TableName tableName)
        {
            string objectName = tableName.ToString();
            bool created = false;

            using (HttpClient client = new HttpClient())
            {
                string jstring = JsonConvert.SerializeObject(newObject);
                StringContent content = new StringContent(jstring, Encoding.UTF8, "application/json");

                HttpResponseMessage resultMessage = await client.PostAsync(URI + objectName, content);

                if (resultMessage.IsSuccessStatusCode)
                {
                    jstring = await resultMessage.Content.ReadAsStringAsync();
                    created = JsonConvert.DeserializeObject<bool>(jstring);
                }
            }

            return created;
        }

        public async Task<bool> DeleteObjectAsync<T>(int id, TableName tableName)
        {
            string objectName = tableName.ToString();
            bool deleted = false;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resultMessage = await client.DeleteAsync(URI + objectName + "/" + id);

                if (resultMessage.IsSuccessStatusCode)
                    deleted = true;
            }
            return deleted;
        }

        public async Task<bool> UpdateObjectAsync<T>(T upObject, int objectId, TableName tableName)
        {
            string objectName = tableName.ToString();
            bool updated = false;

            string jstring = JsonConvert.SerializeObject(upObject);
            StringContent content = new StringContent(jstring, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resultMessage = await client.PutAsync(URI + objectName + "/" + objectId, content);

                if (resultMessage.IsSuccessStatusCode)
                    updated = true;
            }
            return updated;
        }
    }
}
