using BPCClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BPCMain.Persistency
{
    class RestCar
    {
        private const string URI = "";

        public async Task<IList<Car>> GetAllCarsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(URI + "Car");
                IList<Car> cars = JsonConvert.DeserializeObject<IList<Car>>(content);

                return cars;
            }
        }

        public async Task<Car> GetCarFromIdAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(URI + "Car/" + id);
                Car car = JsonConvert.DeserializeObject<Car>(content);
                return car;
            }
        }

        public async Task<bool> CreateCarAsync(Car car)
        {
            bool created = false;

            using (HttpClient client = new HttpClient())
            {
                string jstring = JsonConvert.SerializeObject(car);
                StringContent content = new StringContent(jstring, Encoding.UTF8, "application/json");

                HttpResponseMessage resultMessage = await client.PostAsync(URI + "Car", content);

                if (resultMessage.IsSuccessStatusCode)
                {
                    jstring = await resultMessage.Content.ReadAsStringAsync();
                    created = JsonConvert.DeserializeObject<bool>(jstring);
                }
            }
            return created;
        }

        public async Task<Car> DeleteCarAsync(int id)
        {
            Car car = await GetCarFromIdAsync(id);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resultMessage = await client.DeleteAsync(URI + "Car/" + id);

                if (resultMessage.IsSuccessStatusCode)
                    return car;
            }
            return null;
        }

        public async Task<bool> UpdateCarAsync(Car car)
        {
            bool updated = false;

            string jstring = JsonConvert.SerializeObject(car);
            StringContent content = new StringContent(jstring, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resultMessage = await client.PutAsync(URI + "Car/" + car.Id, content);

                if (resultMessage.IsSuccessStatusCode)
                    updated = true;
            }
            return updated;
        }
    }
}
