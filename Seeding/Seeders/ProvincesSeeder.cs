using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Nodes;

namespace Fishing_API.Seeding.Seeders {
    public class ProvincesSeeder : ISeeder<ProvinceModel> {
        private const string _FileLocation = "Provinces.json";

        public void seed(ModelBuilder modelBuilder, string execPath) {
            string seedDataPath = $"{execPath}/Seeding/Data/{_FileLocation}";

            if (File.Exists(seedDataPath)) {
                string fileData = File.ReadAllText(seedDataPath);

                JsonNode? seedBaseNode = JsonNode.Parse(fileData);

                if (seedBaseNode != null) {
                    JsonArray? seedDataNode = seedBaseNode["data"]?.AsArray();

                    if (seedDataNode != null) {
                        foreach (JsonNode curr in seedDataNode!) {
                            int id = curr["Id"]!.GetValue<int>();
                            string provinceName = curr["ProvinceName"]!.ToString();

                            ProvinceModel provinceModel = new ProvinceModel();
                            provinceModel.Id = id;
                            provinceModel.ProvinceName = provinceName;

                            modelBuilder.Entity<ProvinceModel>(m => {
                                m.HasData(provinceModel);
                            });
                        }
                    } else {
                        throw new InvalidDataException($"Data in {_FileLocation} data block is invalid");
                    }
                } else {
                    throw new InvalidDataException($"Data in {_FileLocation} is invalid");
                }

            } else {
                throw new FileNotFoundException($"Seed file '{_FileLocation}' does not exist at {seedDataPath}");
            }
        }
    }
}
