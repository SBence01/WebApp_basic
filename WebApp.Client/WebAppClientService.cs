using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models;
using WebApp.Client.Models.ApiModels;

namespace WebApp.Client
{
    public class WebAppClientService
    {
        private readonly HttpClient _httpClient;

        public WebAppClientService(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAddress);
        }

        public async Task<List<Department>?> GetDepartments()
        {
            return await _httpClient.GetFromJsonAsync<List<Department>?>("/api/Department/");
        }

        public async Task<Department?> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Department?>($"/api/Department/{id}");
        }

        public async Task SaveDepartment(Department department)
        {
            await _httpClient.PostAsJsonAsync("/api/Department", department);
        }

        public async Task UpdateDepartment(Department department)
        {
            await _httpClient.PutAsJsonAsync("/api/Department", department);
        }

        public async Task DeleteDepartment(int id)
        {
            await _httpClient.DeleteAsync($"/api/Department/{id}");
        }
    }
}
