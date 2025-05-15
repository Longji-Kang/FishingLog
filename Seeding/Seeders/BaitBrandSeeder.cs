using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;

namespace Fishing_API.Seeding.Seeders {
    public class BaitBrandSeeder : ISeeder<BaitBrandModel> {
        private List<BaitBrandModel> _baitBrandModels;

        private const string _FileLocation = "BaitBrands.json";

        public BaitBrandSeeder() {
            _baitBrandModels = new List<BaitBrandModel>();
        }

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
                            string brand = curr["Brand"]!.ToString();

                            BaitBrandModel baitBrandModel = new BaitBrandModel();
                            baitBrandModel.Id = id;
                            baitBrandModel.Brand = brand;

                            _baitBrandModels.Add(baitBrandModel);

                            modelBuilder.Entity<BaitBrandModel>(m => {
                                m.HasData(baitBrandModel);
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
